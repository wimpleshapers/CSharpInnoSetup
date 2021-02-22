
using CodingMuscles.CSharpInnoSetup.Converter;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs
{
    interface IComponentCustomizable
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_componentstasksparams.htm">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(ComponentsExpressionToStringConverter))]
        Expression<Func<bool>> Components { get; }
    }
}
