
using CodingMuscles.CSharpInnoSetup.Converter;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.Linq.Expressions;
using Xunit;

namespace CodingMuscles.CSharpInnoSetup.Test.Converter
{
    public class LanguagesToSpaceSeparatedStringConverterTests
    {
        private Language Language1 { get; }
        private Language Language2 { get; }

        [Fact]
        public void TestNoLanguages()
        {
            var converter = new LanguagesToSpaceSeparatedStringConverter();
            Assert.Equal(string.Empty, Convert(converter, () => new Language[] { }));
        }

        [Fact]
        public void TestOneLanguage()
        {
            var converter = new LanguagesToSpaceSeparatedStringConverter();
            Assert.Equal("Language1", Convert(converter, () => new [] { Language1 }));
        }

        [Fact]
        public void TestMultipleLanguages()
        {
            var converter = new LanguagesToSpaceSeparatedStringConverter();
            Assert.Equal("Language1 Language2", Convert(converter, () => new[] { Language1, Language2 }));
        }

        private string Convert(LanguagesToSpaceSeparatedStringConverter converter, Expression<Func<Language[]>> expression)
        {
            return converter.ConvertTo(expression, typeof(string)) as string;
        }
    }
}
