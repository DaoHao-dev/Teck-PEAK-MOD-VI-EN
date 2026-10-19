using System;
using System.IO;
using Teck.PeakLocale;
class LocaleTests {
 static void Check(bool condition,string message){if(!condition)throw new Exception(message);}
 static int Main(string[] args){
  try{
   var dictionary=new LocaleDictionary();dictionary.Load(File.OpenRead(args[0]));
   if(args.Length>3){File.WriteAllLines(args[2],Array.ConvertAll(File.ReadAllLines(args[1]),line=>Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(dictionary.Translate(System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(line)),true)))));return 0;}
   Check(dictionary.Count>500,"Translation dictionary incomplete");
   Check(dictionary.Translate("GIVE TO ME",true)=="NHẬN VỀ MÌNH","Item spawner translation");
   Check(dictionary.Translate("IMMORTALITY: OFF",true)=="BẤT TỬ: TẮT","Composite status translation");
   Check(dictionary.Translate("♟  Player",true)=="♟  Người chơi","Symbol preservation");
   Check(dictionary.Translate("Quantity  12",true)=="Số lượng  12","Dynamic quantity");
   Check(dictionary.Translate("Banana",false)=="Banana","English mode identity");
   Check(dictionary.Translate("GIVE TO ME",false)=="GIVE TO ME","English mode must restore source");
   Check(dictionary.Translate("<color=#ffaa00>Hunger</color> +25%",true)=="<color=#ffaa00>Đói</color> +25%","Rich-text tags and numeric values");
   Check(dictionary.Translate("No playername123",true)=="Không playername123","Word boundaries");
   Check(dictionary.Translate("未知の項目",true)=="未知の項目","Unknown text fallback");
   Check(dictionary.Translate("  Home  ",true)=="  Trang chủ  ","Whitespace preservation");
   Check(dictionary.Translate("Home\nPlayer",true)=="Trang chủ\nNgười chơi","Multiline captions");
   Check(dictionary.Translate("MaxPlayers",true)=="Số người tối đa","Display-only configuration labels");
   Check(dictionary.Translate("teck.peak.bilingual",true)=="teck.peak.bilingual","Stable machine identifier");
   string source="Status: Hunger 5 • Quantity 3 • Player Bob123";for(int i=0;i<5000;i++){Check(dictionary.Translate(source,false)==source,"English round trip");dictionary.Translate(source,true);}
   File.WriteAllText(args[1],"PASS: "+dictionary.Count+" dictionary entries, Vietnamese UI captions, English identity/round trip, dynamic values, word boundaries, rich-text tags, multiline text, unknown fallback, stable identifiers.\r\nTests exercise translation logic, not Unity rendering or a live PEAK session.\r\n");
   Console.WriteLine("PASS: "+dictionary.Count+" translation entries");return 0;
  }catch(Exception error){Console.Error.WriteLine(error);return 1;}
 }
}
