
using CodingMuscles.CSharpInnoSetup.Converter;
using CodingMuscles.CSharpInnoSetup.Script;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Xunit;

namespace CodingMuscles.CSharpInnoSetup.Test.Converter
{
    public class PropertiesToNameValuePairsConverterTests
    {
        [Fact]
        public void TestSimpleConversion()
        {
            var expected = new NameValueCollection();
            expected.Add("One", "1");
            expected.Add("Two", "2");
            expected.Add("Three", "True");

            TestConversion(expected, new Simple
            {
                One = "1",
                Two = "2",
                Three = true
            });
        }

        [Fact]
        public void TestAliasConversion()
        {
            var expected = new NameValueCollection();
            expected.Add("One", "1");
            expected.Add("Two", "2");
            expected.Add("Four", "True");

            TestConversion(expected, new WithAlias
            {
                One = "1",
                Two = "2",
                Three = true
            });
        }

        [Fact]
        public void TestTypeConverterConversion()
        {
            var expected = new NameValueCollection();
            expected.Add("One", "1");
            expected.Add("Two", "2");
            expected.Add("Three", "sure");

            TestConversion(expected, new WithTypeConverter
            { 
                One = 1, 
                Two = 2 ,
                Three = true
            });
        }


        private void TestConversion<T>(NameValueCollection expected, T obj)
        {
            var converter = new PropertiesToNameValuePairsConverter();
            var values = converter.ConvertTo(obj, typeof(NameValueCollection)) as NameValueCollection;

            Assert.True(expected.AllKeys.OrderBy(k => k).Select(k => (k, expected[k]))
                .SequenceEqual(values.AllKeys.OrderBy(k => k).Select(k => (k, values[k]))));
        }

        class TestConverter : ToStringConverter<bool>
        {
            protected override string Convert(bool value)
            {
                return value ? "sure" : "never";
            }
        }

        class Simple
        {
            public string One { get; set; }
            public string Two { get; set; }
            public bool Three { get; set; }
        }

        class WithAlias
        {
            public string One { get; set; }
            public string Two { get; set; }
            [Alias("Four")]
            public bool Three { get; set; }
        }

        class WithTypeConverter
        {
            public int One { get; set; }
            public int Two { get; set; }
            [TypeConverter(typeof(TestConverter))]
            public bool Three { get; set; }
        }
    }
}
