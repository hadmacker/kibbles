using NUnit.Framework;

namespace TDot.Kibbles.Extensions.Tests
{
    [TestFixture]
    public class StringAsciiSubstitutionExtensionTests
    {
        [TestCase("abcde","abcde")]
        [TestCase("", "")]
        public void NoSubstitution(string input, string expected)
        {
            Assert.AreEqual(expected, input.AsciiSubstitution());
        }
        [TestCase("[FS]abcde", "\x001Cabcde")]
        [TestCase("abc[FS]de", "abc\x001Cde")]
        [TestCase("abcde[FS]", "abcde\x001C")]
        public void SingleSubstitution(string input, string expected)
        {
            Assert.AreEqual(expected, input.AsciiSubstitution());
        }

        [TestCase("[FS][FS]abcde", "\x001C\x001Cabcde")]
        [TestCase("[FS][GS]abcde", "\x001C\x001Dabcde")]
        [TestCase("[FS]abcde[GS]", "\x001Cabcde\x001D")]
        [TestCase("abc[FS]de[GS]", "abc\x001Cde\x001D")]
        [TestCase("abcde[FS][GS]", "abcde\x001C\x001D")]
        [TestCase("[FS][FS][GS][GS]", "\x001C\x001C\x001D\x001D")]
        public void MultipleSubstitution(string input, string expected)
        {
            Assert.AreEqual(expected, input.AsciiSubstitution());
        }

        [TestCase("abc[de]fg", "abc[de]fg")]
        public void InvalidSubstitution(string input, string expected)
        {
            Assert.AreEqual(expected, input.AsciiSubstitution());
        }
    }
}