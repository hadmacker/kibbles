using System;
using System.Linq;
using System.Text;

namespace TDot.Kibbles.Extensions
{
    public static class StringAsciiSubstitutionExtension
    {
        
        /// <summary>
        /// Replaces ASCII control characters framed in [] with their true representation. 
        /// 
        /// For example, a string of "000[FS]100200" would be turned into "000\x0028100200"
        /// </summary>
        /// <param name="source"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string AsciiSubstitution(this string source, AsciiSubstitutionOptions options = null)
        {
            if(options == null)
                options = AsciiSubstitutionOptions.Default();

            var sb = new StringBuilder(source);
            Constants.LowerControlChars.Select((c, i) =>
                new Tuple<string, string>(options.Frame(c), new string((char) i, 1)))
                .ToList()
                .ForEach(t => sb.Replace(t.Item1, t.Item2));

            return sb.ToString();
        }
    }
    public class AsciiSubstitutionOptions
    {
        public string Format { get; set; }

        public static AsciiSubstitutionOptions Default()
        {
            return new AsciiSubstitutionOptions
            {
                Format = "[{0}]"
            };
        }

        public string Frame(string s)
        {
            return string.Format(Format, s);
        }
    }
}