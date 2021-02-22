
using System;

namespace CodingMuscles.CSharpInnoSetup.Script
{
    /// <summary>
    /// Applied to a property value that, if it contains a blank, should be surrounded by double quotes 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class DoubleQuoteAttribute : Attribute
    {

    }
}
