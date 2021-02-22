
using System;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs
{
    /// <summary>
    /// Builds an object that implements <see cref="IPredicated"/>
    /// </summary>
    /// <typeparam name="TBuilder">The builder type</typeparam>
    internal interface IPredicatedBuilder<TBuilder>
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_scriptcheck.htm">Documentation</a>
        /// </summary>
        public TBuilder Check(Expression<Func<string, bool>> check);
    }
}
