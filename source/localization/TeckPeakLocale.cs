using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace Teck.PeakLocale {
    [BepInPlugin("teck.peak.bilingual","Teck PEAK — Tiếng Việt / English","1.0.0")]
    [BepInProcess("PEAK.exe")]
    public sealed class LocalePlugin : BaseUnityPlugin {
        static LocalePlugin instance;
        static readonly LocaleDictionary words=new LocaleDictionary();
        static readonly HashSet<string> supported=new HashSet<string>(StringComparer.OrdinalIgnoreCase){"PeakTrollMod","PEAKUnlimited","com.github.yueby.ItemInfo","Start With Backpacks","HealingCampfires","Healing Campfires"};
        [ThreadStatic] static int drawScope;
        [ThreadStatic] static bool refreshing;
        ConfigEntry<string> language;
        ConfigEntry<KeyboardShortcut> shortcut;
        Harmony harmony;
        float nextNames,toastUntil;
        static readonly HashSet<string> names=new HashSet<string>(StringComparer.Ordinal);
        static readonly Dictionary<int,TextRecord> textRecords=new Dictionary<int,TextRecord>();
        sealed class TextRecord {public WeakReference Target;public string English;public MethodBase Setter;}
        public static bool Vietnamese {get{return instance!=null&&instance.language!=null&&instance.language.Value=="vi";}}
        void Awake(){
            instance=this;
            try{
                language=Config.Bind("Language","Language","vi",new ConfigDescription("vi = Tiếng Việt, en = English. F10 switches language without restarting.",new AcceptableValueList<string>("vi","en")));
                shortcut=Config.Bind("Language","SwitchLanguageKey",new KeyboardShortcut(KeyCode.F10),"Change mod display language; default F10. F8 remains spectator free camera.");
                words.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("teck.translations"));
                harmony=new Harmony("teck.peak.bilingual");
            }catch(Exception error){Logger.LogError("Localization initialization failed: "+error);enabled=false;}
        }
        void Start(){
            if(harmony==null)return;
            int gui=0,scopes=0;
            try{
                var captionNames=new HashSet<string>{"Label","Box","Button","RepeatButton","Toggle","Window","ModalWindow","SelectionGrid","Toolbar","DoLabel","DoBox","DoButton","DoRepeatButton","DoToggle","DoWindow"};
                foreach(Type type in new[]{typeof(GUI),typeof(GUILayout)})foreach(MethodInfo method in type.GetMethods(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.DeclaredOnly)){
                    if(captionNames.Contains(method.Name)&&method.GetParameters().Any(p=>p.ParameterType==typeof(GUIContent)||p.ParameterType==typeof(GUIContent[])))
                        if(TryPatch(method,"CaptionPrefix",null,null))gui++;
                }
                foreach(var info in Chainloader.PluginInfos.Values){
                    Assembly assembly=info.Instance==null?null:info.Instance.GetType().Assembly;
                    if(assembly==null||!supported.Contains(assembly.GetName().Name))continue;
                    foreach(Type type in SafeTypes(assembly)){
                        foreach(var method in type.GetMethods(BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.DeclaredOnly)){
                            if(method.Name=="OnGUI"&&method.GetParameters().Length==0&&TryPatch(method,"ScopePrefix",null,"ScopeFinalizer"))scopes++;
                            if(type.FullName=="PeakTrollMod.TrollUIManager"&&method.Name=="DrawHeader")TryPatch(method,null,"HeaderPostfix",null);
                        }
                    }
                }
                foreach(string typeName in new[]{"TMPro.TMP_Text","UnityEngine.UI.Text"}){
                    Type type=AccessTools.TypeByName(typeName);if(type==null)continue;
                    MethodInfo setter=AccessTools.PropertySetter(type,"text");
                    if(setter!=null)TryPatch(setter,"TextPrefix",null,null);
                }
                Logger.LogInfo("Loaded "+words.Count+" offline translations; "+gui+" caption hooks, "+scopes+" mod draw scopes. Language="+language.Value+". "+shortcut.Value+" switches languages.");
            }catch(Exception error){Logger.LogError("Localization patch setup failed; reverting only Teck localization: "+error);harmony.UnpatchSelf();enabled=false;}
        }
        bool TryPatch(MethodBase method,string prefix,string postfix,string finalizer){
            try{harmony.Patch(method,prefix==null?null:new HarmonyMethod(typeof(LocalePlugin),prefix),postfix==null?null:new HarmonyMethod(typeof(LocalePlugin),postfix),null,finalizer==null?null:new HarmonyMethod(typeof(LocalePlugin),finalizer),null);return true;}
            catch(Exception error){Logger.LogWarning("Skipped localization hook "+method.DeclaringType.FullName+"."+method.Name+": "+error.Message);return false;}
        }
        static Type[] SafeTypes(Assembly assembly){try{return assembly.GetTypes();}catch(ReflectionTypeLoadException error){return error.Types.Where(t=>t!=null).ToArray();}}
        void Update(){
            if(shortcut!=null&&shortcut.Value.IsDown())Switch();
            if(Time.unscaledTime>=nextNames){nextNames=Time.unscaledTime+2f;RefreshNames();}
        }
        void Switch(){
            language.Value=Vietnamese?"en":"vi";Config.Save();toastUntil=Time.unscaledTime+4f;
            // Existing ItemInfo text is refreshed from its original, never reverse-translated.
            refreshing=true;
            try{foreach(var record in textRecords.Values.ToArray()){var target=record.Target.Target as UnityEngine.Object;if(target!=null)try{record.Setter.Invoke(target,new object[]{record.English});}catch{}}}
            finally{refreshing=false;}
        }
        static void RefreshNames(){
            names.Clear();
            try{
                foreach(var info in Chainloader.PluginInfos.Values){
                    if(info.Instance==null||info.Instance.GetType().Assembly.GetName().Name!="PeakTrollMod")continue;
                    var manager=AccessTools.Field(info.Instance.GetType(),"Players").GetValue(info.Instance);
                    if(manager==null)continue;
                    var entries=AccessTools.Property(manager.GetType(),"Entries").GetValue(manager,null) as IEnumerable;
                    if(entries==null)continue;
                    foreach(var entry in entries){var field=AccessTools.Field(entry.GetType(),"Name");if(field!=null){string name=field.GetValue(entry) as string;if(!String.IsNullOrEmpty(name))names.Add(name);}}
                }
            }catch{}
        }
        static string Display(string text){
            if(String.IsNullOrEmpty(text))return text;
            string clean=text.Trim().TrimEnd('▾').Trim();
            if(names.Contains(clean))return text;
            return Vietnamese?words.Translate(text,true).Replace('\ufffd','•'):text;
        }
        static void ScopePrefix(){drawScope++;}
        static Exception ScopeFinalizer(Exception __exception){drawScope=Math.Max(0,drawScope-1);return __exception;}
        static void CaptionPrefix(MethodBase __originalMethod,object[] __args){
            if(drawScope<=0||!Vietnamese)return;
            try{
                var parameters=__originalMethod.GetParameters();int styleIndex=-1;Rect? rectangle=null;GUIContent first=null;
                for(int i=0;i<parameters.Length;i++){
                    if(parameters[i].ParameterType==typeof(GUIStyle))styleIndex=i;
                    if(parameters[i].ParameterType==typeof(Rect))rectangle=(Rect)__args[i];
                    if(parameters[i].ParameterType==typeof(GUIContent)){
                        var content=__args[i] as GUIContent;if(content==null)continue;
                        string translated=Display(content.text),tooltip=Display(content.tooltip);
                        if(translated!=content.text||tooltip!=content.tooltip){var copy=new GUIContent(content);copy.text=translated;copy.tooltip=tooltip;__args[i]=copy;first=copy;}
                    }else if(parameters[i].ParameterType==typeof(GUIContent[])){
                        var content=__args[i] as GUIContent[];if(content==null)continue;
                        __args[i]=content.Select(c=>c==null?null:new GUIContent(Display(c.text),c.image,Display(c.tooltip))).ToArray();
                    }
                }
                if(first!=null&&styleIndex>=0&&rectangle.HasValue){
                    var style=__args[styleIndex] as GUIStyle;var rect=rectangle.Value;
                    if(style!=null&&rect.width>20&&style.fontSize>0){
                        if(style.CalcHeight(first,rect.width)>rect.height+1&&style.fontSize>10){
                            var copy=new GUIStyle(style);
                            while(copy.fontSize>10&&copy.CalcHeight(first,rect.width)>rect.height+1)copy.fontSize--;
                            copy.clipping=TextClipping.Clip;__args[styleIndex]=copy;
                        }
                    }
                }
            }catch{} // A translation failure never replaces the gameplay method.
        }
        static bool ModCaller(){
            foreach(var frame in new StackTrace(false).GetFrames()??new StackFrame[0]){
                var method=frame.GetMethod();if(method!=null&&method.DeclaringType!=null&&supported.Contains(method.DeclaringType.Assembly.GetName().Name))return true;
            }
            return false;
        }
        static void TextPrefix(object __instance,MethodBase __originalMethod,ref string __0){
            if(__instance==null||String.IsNullOrEmpty(__0))return;
            try{
                var target=__instance as UnityEngine.Object;if(target==null)return;
                int id=target.GetInstanceID();
                if(!refreshing&&drawScope<=0&&!textRecords.ContainsKey(id)){
                    // Skip unrelated game text before taking a stack trace.
                    if(words.Translate(__0,true)==__0||!ModCaller())return;
                }
                if(!refreshing){if(textRecords.Count>512)foreach(int key in textRecords.Where(p=>!p.Value.Target.IsAlive||p.Value.Target.Target as UnityEngine.Object==null).Select(p=>p.Key).ToArray())textRecords.Remove(key);textRecords[id]=new TextRecord{Target=new WeakReference(target),English=__0,Setter=__originalMethod};}
                __0=Display(__0);
            }catch{}
        }
        static void HeaderPostfix(){
            if(instance==null)return;
            // Uses F7's own design-space transform; no separate panel obscures gameplay.
            var style=new GUIStyle(GUI.skin.button){fontSize=13,wordWrap=false};
            if(GUI.Button(new Rect(1000,80,235,27),(Vietnamese?"Tiếng Việt  |  English":"English  |  Tiếng Việt")+"  ["+instance.shortcut.Value+"]",style))instance.Switch();
        }
        void OnGUI(){
            if(Time.unscaledTime>=toastUntil)return;
            var style=new GUIStyle(GUI.skin.box){fontSize=16,alignment=TextAnchor.MiddleCenter};
            GUI.Box(new Rect(Math.Max(10,(Screen.width-340)/2),12,340,40),Vietnamese?"Đã chọn Tiếng Việt":"English selected",style);
        }
        void OnDestroy(){if(harmony!=null)harmony.UnpatchSelf();if(instance==this)instance=null;textRecords.Clear();drawScope=0;}
    }
}
