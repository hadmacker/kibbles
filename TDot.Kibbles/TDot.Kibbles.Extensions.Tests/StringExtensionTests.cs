using System;
using NUnit.Framework;

namespace TDot.Kibbles.Extensions.Tests
{
    [TestFixture]
    public class StringExtensionTests
    {
        [Test]
        public void ToByteArray_MultipleFullBytes()
        {
            var actual = "E0E8F0".ToByteArray();
            Assert.AreEqual(new[] {0xE0, 0xE8, 0xF0}, actual);
        }
        [Test]
        public void ToByteArray_PartialFirstByte()
        {
            var actual = "EE8F0".ToByteArray();
            Assert.AreEqual(new[] { 0x0E, 0xE8, 0xF0 }, actual);
        }
        [Test]
        public void ToByteArray_SingleFullByte()
        {
            var actual = "F0".ToByteArray();
            Assert.AreEqual(new[] { 0xF0 }, actual);
        }
        [Test]
        public void ToByteArray_SinglePartialByte()
        {
            var actual = "F".ToByteArray();
            Assert.AreEqual(new[] { 0x0F }, actual);
        }
    }
}