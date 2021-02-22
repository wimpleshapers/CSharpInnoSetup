
using CodingMuscles.CSharpInnoSetup.Converter;
using System;
using System.Linq.Expressions;
using Xunit;

namespace CodingMuscles.CSharpInnoSetup.Test.Converter
{
    public class MethodCallExpressionToStringConverterTests
    {
        [Fact]
        public void TestFuncConversion()
        {
            TestConversion<Func<bool>>("Function()", () => Function());
        }

        [Fact]
        public void TestActionConversion()
        {
            TestConversion<Action<string>>("Procedure('test')", s => Procedure("test"));
        }

        private void TestConversion<T>(string expected, Expression<T> expression) where T : Delegate
        {
            var converter = new DelegateExpressionToStringConverter<T>();
            Assert.Equal(expected, converter.ConvertTo(expression, typeof(string)) as string);

        }

        private bool Function()
        {
            return true;
        }

        private void Procedure(string action)
        {

        }
    }
}
