
using System;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs
{
    /// <summary>
    /// Builds an object that implements <see cref="IComponentCustomizable"/>
    /// </summary>
    /// <typeparam name="TBuilder">The builder type</typeparam>
    internal interface IComponentCustomizableBuilder<TBuilder>
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_componentstasksparams.htm">Documentation</a>
        /// </summary>
        public TBuilder Components(Expression<Func<bool>> components);
    }
}
