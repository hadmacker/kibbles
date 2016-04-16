using System;
using System.Diagnostics;
using NUnit.Framework;

namespace TDot.Kibbles.Extensions.Tests
{
    [TestFixture]
    public class MapEnumExtensionsTests
    {
        [TestCase((uint)1, Feature1.Bit1)]
        [TestCase((uint)2, Feature1.Bit2)]
        [TestCase((uint)3, Feature1.Bit1 | Feature1.Bit2)]
        [TestCase((uint)14, Feature1.Bit2 | Feature1.Bit3 | Feature1.Bit4)]
        public void MapEnum(uint source, Feature1 expected)
        {
            source.MapEnum<Feature1>((u, b) =>
            {
                Debug.WriteLine("{0}.{1}:{2}", typeof(Feature1).Name, Enum.GetName(typeof(Feature1), u), b);
                if ((expected | (Feature1)u) == expected)
                    Assert.True(b);
                else
                    Assert.False(b);
            });
        }
    }

    [Flags]
    public enum Feature1 : uint
    {
        None = 0,
        Bit1 = 1, 
        Bit2 = 2,
        Bit3 = 4,
        Bit4 = 8,
        Bit5 = 16,
        Bit6 = 32,
        Bit7 = 64,
        Bit8 = 128,
        Bit9 = 256,
        Bit10 = 512,
        Bit11 = 1024,
        Bit12 = 2048,
        Bit13 = 4096,
        Bit14 = 8192,
        Bit15 = 16384,
        Bit16 = 32768
    }

    [Flags]
    public enum Feature2 : uint
    {
        None = 0,
        Bit1 = 1,
        Bit2 = 2,
        Bit3 = 4,
        Bit4 = 8,
        Bit5 = 16,
        Bit6 = 32,
        Bit7 = 64,
        Bit8 = 128,
        Bit9 = 256,
        Bit10 = 512,
        Bit11 = 1024,
        Bit12 = 2048,
        Bit13 = 4096,
        Bit14 = 8192,
        Bit15 = 16384,
        Bit16 = 32768
    }
}