
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs
{
    /// <summary>
    /// Builds an object that implements <see cref="ICommonParameters"/>
    /// </summary>
    /// <typeparam name="TBuilder">The builder type</typeparam>
    internal interface ICommonParametersBuilder<TBuilder>
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_commonparams.htm">Documentation</a>
        /// </summary>
        public TBuilder Languages(Expression<Func<Language[]>> languages);

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_commonparams.htm">Documentation</a>
        /// </summary>
        public TBuilder Languages(Expression<Func<Language>> language);

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_commonparams.htm">Documentation</a>
        /// </summary>
        public TBuilder MinVersion(Version minVersion);

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_commonparams.htm">Documentation</a>
        /// </summary>
        public TBuilder OnlyBelowVersion(Version onlyBelowVersion);
    }
}
