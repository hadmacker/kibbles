namespace TDot.Kibbles.Extensions
{
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