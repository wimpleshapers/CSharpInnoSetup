
using System;
using System.Linq.Expressions;
using CodingMuscles.CSharpInnoSetup.Converter;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using Xunit;

namespace CodingMuscles.CSharpInnoSetup.Test.Converter
{
    public class ComponentsExpressionToStringConverterTests
    {
        public Component<ComponentFactory.LeafComponent> First { get; }
        public Component<ComponentFactory.LeafComponent> Second { get; }
        public Component<ComponentFactory.LeafComponent> Third { get; }

        [Fact]
        public void TestSingleComponent()
        {
            var converter = new ComponentsExpressionToStringConverter();

            Assert.Equal("First", Convert(() => First, converter));
        }

        [Fact]
        public void TestAndedComponents()
        {
            var converter = new ComponentsExpressionToStringConverter();

            Assert.Equal("First and Second", Convert(() => First && Second, converter));
        }

        [Fact]
        public void TestOredComponents()
        {
            var converter = new ComponentsExpressionToStringConverter();

            Assert.Equal("First or Second", Convert(() => First || Second, converter));
        }

        [Fact]
        public void TestThreeOredComponents()
        {
            var converter = new ComponentsExpressionToStringConverter();

            Assert.Equal("(First or Second) or Third", Convert(() => First || Second || Third, converter));
        }

        [Fact]
        public void TestNottedComponents()
        {

        }

        private string Convert(Expression<Func<bool>> expression, ComponentsExpressionToStringConverter converter)
        {
            return converter.ConvertTo(expression, typeof(string)) as string;
        }
    }
}
