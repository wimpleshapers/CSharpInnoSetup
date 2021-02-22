
using CodingMuscles.CSharpInnoSetup.Converter;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.Linq.Expressions;
using Xunit;

namespace CodingMuscles.CSharpInnoSetup.Test.Converter
{
    public class TypesExpressionToStringConverterTests
    {
        [Fact]
        public void TestConversion()
        {
            var type1 = SetupType.Builder.Create().Build();
            var type2 = SetupType.Builder.Create().Build();
            var type3 = SetupType.Builder.Create().Build();

            TestConversionInner("type1", () => new [] { type1 });
            TestConversionInner("type1 type2", () => new[] { type1, type2 });
            TestConversionInner("type1 type2 type3", () => new[] { type1, type2, type3 });
        }

        [Fact]
        public void TestNoTypes()
        {
            TestConversionInner("", () => new SetupType[] { });
        }

        private void TestConversionInner(string expected, Expression<Func<SetupType[]>> expression)
        {
            var converter = new TypesExpressionToStringConverter();
            Assert.Equal(expected, converter.ConvertTo(expression, typeof(string)) as string);
        }
    }
}
