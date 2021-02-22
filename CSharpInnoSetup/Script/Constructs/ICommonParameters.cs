
using CodingMuscles.CSharpInnoSetup.Converter;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_commonparams.htm">Documentation</a>
    /// </summary>
    internal interface ICommonParameters
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_commonparams.htm">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(LanguagesToSpaceSeparatedStringConverter))]
        Expression<Func<Language[]>> Languages { get; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_commonparams.htm">Documentation</a>
        /// </summary>
        Version MinVersion { get; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_commonparams.htm">Documentation</a>
        /// </summary>
        Version OnlyBelowVersion { get; }
    }
}
