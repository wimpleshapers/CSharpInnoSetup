
using CodingMuscles.CSharpInnoSetup.Converter;
using System;
using Xunit;

namespace CodingMuscles.CSharpInnoSetup.Test.Converter
{
    public class EnumToStringConverterTests
    {
        [Theory]
        [InlineData("One", Test.One)]
        [InlineData("Three", Test.Three)]
        public void TestConversion(string expected, Test value)
        {
            var converter = new EnumToStringConverter<Test>();
            Assert.Equal(expected, converter.ConvertTo(value, typeof(string)) as string);
        }

        [Theory]
        [InlineData("One", TestFlags.One)]
        [InlineData("Two Three", TestFlags.Two|TestFlags.Three)]
        public void TestFlagsConversion(string expected, TestFlags value)
        {
            var converter = new EnumToStringConverter<TestFlags>();
            Assert.Equal(expected, converter.ConvertTo(value, typeof(string)) as string);
        }

        [Fact]
        public void TestEmptyFlagsConversion()
        {
            TestFlags value = 0;
            var converter = new EnumToStringConverter<TestFlags>();
            Assert.Null(converter.ConvertTo(value, typeof(string)));
        }

        public enum Test
        {
            One,
            Two,
            Three
        }

        [Flags]
        public enum TestFlags
        {
            One = 1,
            Two = 2,
            Three = 4
        }
    }
}
