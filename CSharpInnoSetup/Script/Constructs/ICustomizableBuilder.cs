
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs
{
    /// <summary>
    /// Builds an object that implements <see cref="ICustomizable"/>
    /// </summary>
    /// <typeparam name="TBuilder">The builder type</typeparam>
    internal interface ICustomizableBuilder<TBuilder> : IComponentCustomizableBuilder<TBuilder>
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_componentstasksparams.htm">Documentation</a>
        /// </summary>
        public TBuilder Tasks(Expression<Func<ITask[]>> tasks);

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_componentstasksparams.htm">Documentation</a>
        /// </summary>
        public TBuilder Tasks(Expression<Func<ITask>> task);
    }
}
