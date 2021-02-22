
using System;

namespace CodingMuscles.CSharpInnoSetup
{
    /// <summary>
    /// Applied to properties that appear in the Inno Setup [Language] section
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class LanguageDirectiveAttribute : Attribute
    {
    }
}
