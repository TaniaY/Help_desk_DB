using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Help_desk.Helpers
{
    public static class SlugGenerator
    {
        //public static string ToUrlSlug(string value)
        //{

        //    //First to lower case
        //    value = value.ToLowerInvariant();

        //    //Remove all accents
        //    var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
        //    value = Encoding.ASCII.GetString(bytes);

        //    //Replace spaces
        //    value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

        //    //Remove invalid chars
        //    value = Regex.Replace(value, @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);

        //    //Trim dashes from end
        //    value = value.Trim('-', '_');

        //    //Replace double occurences of - or _
        //    value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

        //    return value;
        //}
        
            public static string GenerateSlug(this string phrase)
            {
                string str = phrase.RemoveAccent().ToLower();
                // invalid chars           
                str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
                // convert multiple spaces into one space   
                str = Regex.Replace(str, @"\s+", " ").Trim();
                // cut and trim 
                str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
                str = Regex.Replace(str, @"\s", "-"); // hyphens   
                return str;
            }
            public static string RemoveAccent(this string txt)
            {
                byte[] bytes = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(txt);
                return System.Text.Encoding.ASCII.GetString(bytes);
            }
        }
}
