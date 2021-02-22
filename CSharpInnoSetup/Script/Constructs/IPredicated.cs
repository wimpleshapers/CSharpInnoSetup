
using CodingMuscles.CSharpInnoSetup.Converter;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs
{
    internal interface IPredicated
    {
        [TypeConverter(typeof(DelegateExpressionToStringConverter<Func<string, bool>>))]
        Expression<Func<string, bool>> Check { get; }
    }
}
