using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Teck.PeakLocale {
    public sealed class LocaleDictionary {
        readonly Dictionary<string,string> entries=new Dictionary<string,string>(StringComparer.Ordinal);
        KeyValuePair<string,string>[] phrases;
        Dictionary<char,KeyValuePair<string,string>[]> byFirst;
        readonly Dictionary<string,string> cache=new Dictionary<string,string>(StringComparer.Ordinal);
        public int Count {get{return entries.Count;}}
        public void Load(Stream input){
            using(var reader=new StreamReader(input,Encoding.UTF8)){
                string line;
                while((line=reader.ReadLine())!=null){
                    if(line.StartsWith("#",StringComparison.Ordinal))continue;
                    int split=line.IndexOf("=>",StringComparison.Ordinal);if(split<1)continue;
                    string key=line.Substring(0,split).Trim(),value=line.Substring(split+2).Trim();
                    if(key.Length>0&&value.Length>0)entries[key]=value;
                }
            }
            phrases=entries.OrderByDescending(p=>p.Key.Length).ToArray();byFirst=phrases.GroupBy(p=>p.Key[0]).ToDictionary(g=>g.Key,g=>g.ToArray());cache.Clear();
        }
        public string Translate(string original,bool vietnamese){
            if(!vietnamese||String.IsNullOrEmpty(original))return original;
            string result;if(cache.TryGetValue(original,out result))return result;
            string clean=original.Trim(),exact;
            if(entries.TryGetValue(clean,out exact))result=original.Substring(0,original.Length-original.TrimStart().Length)+exact+original.Substring(original.TrimEnd().Length);
            else result=Compose(original);
            if(cache.Count>=2048)cache.Clear();cache[original]=result;return result;
        }
        string Compose(string text){
            // A single pass over ORIGINAL text prevents re-translating Vietnamese output.
            var output=new StringBuilder(text.Length+20);
            for(int index=0;index<text.Length;){
                if(text[index]=='<'){
                    int end=text.IndexOf('>',index);if(end>=index){output.Append(text,index,end-index+1);index=end+1;continue;}
                }
                bool found=false;
                KeyValuePair<string,string>[] candidates;
                if(!byFirst.TryGetValue(text[index],out candidates)){output.Append(text[index]);index++;continue;}
                foreach(var phrase in candidates){
                    int length=phrase.Key.Length;
                    if(index+length>text.Length||String.CompareOrdinal(text,index,phrase.Key,0,length)!=0)continue;
                    if(index>0&&Char.IsLetterOrDigit(phrase.Key[0])&&Char.IsLetterOrDigit(text[index-1]))continue;
                    if(index+length<text.Length&&Char.IsLetterOrDigit(phrase.Key[length-1])&&Char.IsLetterOrDigit(text[index+length]))continue;
                    output.Append(phrase.Value);index+=length;found=true;break;
                }
                if(!found){output.Append(text[index]);index++;}
            }
            return output.ToString();
        }
    }
}
