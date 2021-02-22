
using CodingMuscles.CSharpInnoSetup.Converter;
using Xunit;

namespace CodingMuscles.CSharpInnoSetup.Test.Converter
{
    public class BoolToStringConverterTests
    {
        [Theory]
        [InlineData(true, "yes")]
        [InlineData(false, "no")]
        public void TestConversions(bool input, string output)
        {
            var converter = new BoolToStringConverter();
            Assert.Equal(output, converter.ConvertTo(input, typeof(string)));
        }
    }
}