using System;

namespace TDot.Kibbles.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Takes a hex string and returns the appropriate bytes. "E8E0" will return byte[] {0xE8, 0xE0}
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string source)
        {
            if (source.Length%2 == 1)
                source = "0" + source;
            var length = source.Length;
            var bytes = new byte[length / 2];
            for (var i = 0; i < length; i += 2)
                bytes[i / 2] = Convert.ToByte(source.Substring(i, 2), 16);
            return bytes;
        }
    }
}