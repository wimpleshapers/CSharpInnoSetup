
using CodingMuscles.CSharpInnoSetup.Converter;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs
{
    internal interface ICustomizable : IComponentCustomizable
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_componentstasksparams.htm">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(TasksExpressionToStringConverter))]
        Expression<Func<ITask[]>> Tasks { get; }
    }
}
