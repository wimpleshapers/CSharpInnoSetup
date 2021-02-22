
using System;

namespace CodingMuscles.CSharpInnoSetup
{
    /// <summary>
    /// Applied to properties that appear in the Inno Setup [Setup] section
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class SetupDirectiveAttribute : Attribute
    {
    }
}
