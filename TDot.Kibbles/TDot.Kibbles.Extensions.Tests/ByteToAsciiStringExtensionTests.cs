using NUnit.Framework;

namespace TDot.Kibbles.Extensions.Tests
{
    [TestFixture]
    public class ByteToAsciiStringExtensionTests
    {
        [TestCase(new byte[] {0x0, 0x1, 0x2}, "[NUL][SOH][STX]")]
        [TestCase(new byte[] {0x0, 0x1, 0x32, 0x33, 0x34, 0x35, 0x36}, "[NUL][SOH]23456")]
        public void DefaultOptions(byte[] input, string expected)
        {
            Assert.AreEqual(expected, input.ToAsciiString());
        }
        [TestCase(new byte[] { 0x0, 0x1, 0x2 }, "<NUL><SOH><STX>")]
        [TestCase(new byte[] { 0x0, 0x1, 0x32, 0x33, 0x34, 0x35, 0x36 }, "<NUL><SOH>23456")]
        public void SpecialFormatting(byte[] input, string expected)
        {
            Assert.AreEqual(expected, input.ToAsciiString(ByteToAsciiStringOptions.Special("<{0}>")));
        }
    }
}