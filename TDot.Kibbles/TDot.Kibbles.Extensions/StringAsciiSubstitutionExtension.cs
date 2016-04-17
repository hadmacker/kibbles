using System;
using System.Linq;
using System.Text;

namespace TDot.Kibbles.Extensions
{
    public static class StringAsciiSubstitutionExtension
    {
        // Lower 32 (0 to 31) control characters named
        private static string[] ControlChars =
        {
            "NUL", "SOH", "STX", "ETX", "EOT", "ENQ", "ACK", "BEL", "BS", "HT", "LF", "VT", "FF", "CR", "SO", "SI",
            "DLE", "DC1", "DC2", "DC3", "DC4", "NAK", "SYN", "ETB", "CAN", "EM", "SUB", "ESC", "FS", "GS", "RS", "US"
        };

        public static string AsciiSubstitution(this string source, AsciiSubstitutionOptions options = null)
        {
            if(options == null)
                options = AsciiSubstitutionOptions.Default();

            var sb = new StringBuilder(source);
            ControlChars.Select((c, i) =>
                new Tuple<string, string>(options.Frame(c), new string((char)i, 1)))
                .ToList()
                .ForEach(t => sb.Replace(t.Item1, t.Item2));

            return sb.ToString();
        }
    }
}