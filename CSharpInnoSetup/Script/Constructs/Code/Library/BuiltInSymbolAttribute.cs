
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Applied to a symbol that is pre-defined by the Inno Setup Pascal compiler
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct|AttributeTargets.Enum|AttributeTargets.Delegate|AttributeTargets.Interface|AttributeTargets.Method|AttributeTargets.Property, Inherited = true)]
    public sealed class BuiltInSymbolAttribute : Attribute
    {
    }
}
