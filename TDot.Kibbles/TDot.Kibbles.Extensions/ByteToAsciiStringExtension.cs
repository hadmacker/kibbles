using System;
using System.Linq;
using System.Text;

namespace TDot.Kibbles.Extensions
{
    public static class ByteToAsciiStringExtension
    {
        public static string ToAsciiString(this byte[] source, ByteToAsciiStringOptions options = null)
        {
            if(options == null)
                options = ByteToAsciiStringOptions.Default();

            return source.Select(b =>
                options.Render(b)).Aggregate((s, s1) => s + s1);
        }
    }

    public class ByteToAsciiStringOptions
    {
        public string Format { get; set; }
        public static ByteToAsciiStringOptions Default()
        {
            return new ByteToAsciiStringOptions
            {
                Format = "[{0}]"
            };
        }

        public static ByteToAsciiStringOptions Special(string format)
        {
            return new ByteToAsciiStringOptions
            {
                Format = format
            };
        }
        
        public string Render(byte b)
        {
            return (uint) b < Constants.LowerControlChars.Length
                ? string.Format(Format, Constants.LowerControlChars[(uint) b])
                : Convert.ToChar((uint)b).ToString();
        }
    }
}