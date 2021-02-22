
using System;

namespace CodingMuscles.CSharpInnoSetup.Script
{
    /// <summary>
    /// Applied to a property that should not be transformed into script
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class IgnoreAttribute : Attribute
    {
    }
}
