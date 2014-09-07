using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ImeijiQueue
{
    class TagSuggestionLibrary
    {
        private Dictionary<String, String[]> dicks;

        private TagSuggestionLibrary(Dictionary<String, String[]> dic)
        {
            dicks = dic;
        }

        public static TagSuggestionLibrary generate()
        {
            return new TagSuggestionLibrary(new Dictionary<String, String[]>());
        }

        public static TagSuggestionLibrary load(Stream strum)
        {
            BinaryFormatter boyfriend = new BinaryFormatter();
            try
            {
                return new TagSuggestionLibrary((Dictionary<String, String[]>)boyfriend.Deserialize(strum));
            }catch(InvalidCastException sEx)
            {
                throw new Exception("Stream deserialized not Dictionary<String, String[]>");
            }
        }

        public void write(Stream strum)
        {
            BinaryFormatter boyfriend = new BinaryFormatter();
            boyfriend.Serialize(strum, dicks);
            return;
        }

        public String[] suggest(String tag)
        {
            if(dicks.ContainsKey(tag))
            {
                return dicks[tag];
            }
            else
            {
                return new String[]{""};
            }
        }

        public void editSuggestion(String tagIf, String[] tagsThen)
        {
            if(dicks.ContainsKey(tagIf))
            {
                dicks[tagIf] = tagsThen;
            }
            else
            {
                dicks.Add(tagIf, tagsThen);
            }
        }

        public void removeSuggestion(String tagIf)
        {
            dicks.Remove(tagIf);
        }

        public String[] listValidTagIf()
        {
            return dicks.Keys.ToArray();
        }
    }
}
