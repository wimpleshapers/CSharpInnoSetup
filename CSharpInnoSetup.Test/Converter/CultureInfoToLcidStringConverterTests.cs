
using CodingMuscles.CSharpInnoSetup.Converter;
using System.Globalization;
using Xunit;

namespace CodingMuscles.CSharpInnoSetup.Test.Converter
{
    public class CultureInfoToLcidStringConverterTests
    {
        [Theory]
        [InlineData(0, "$0000")]
        [InlineData(1033, "$0409")]
        [InlineData(65535, "$FFFF")]
        public void TestLCIDConversion(int lcid, string expected)
        {
            var converter = new CultureInfoToLcidStringConverter();
            Assert.Equal(expected, converter.ConvertTo(new TestCulture(lcid), typeof(string)) as string);
        }

        class TestCulture : CultureInfo
        {
            private readonly int _lcid;

            public TestCulture(int lcid) : base(1033)
            {
                _lcid = lcid;
            }

            public override int LCID => _lcid;
        }
    }
}
