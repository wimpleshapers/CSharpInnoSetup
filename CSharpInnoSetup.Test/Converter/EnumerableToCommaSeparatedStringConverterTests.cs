
using CodingMuscles.CSharpInnoSetup.Converter;
using Xunit;

namespace CodingMuscles.CSharpInnoSetup.Test.Converter
{
    public class EnumerableToCommaSeparatedStringConverterTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("1, 2, 3", 1, 2, 3)]
        [InlineData("1, 2, 3", 1, "2", 3)]
        [InlineData("1", 1)]
        [InlineData("1, System.String", 1, typeof(string))]
        public void TestConversion(string expected, params object[] values)
        {
            var converter = new EnumerableToCommaSeparatedStringConverter();
            Assert.Equal(expected, converter.ConvertTo(values, typeof(string)) as string);
        }
    }
}
