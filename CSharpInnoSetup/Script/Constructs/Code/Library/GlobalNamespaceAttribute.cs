
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Attribute applied to types whose script symbols that appear
    /// in the global namespace and should not be fully qualified
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Enum)]
    public sealed class GlobalNamespaceAttribute : Attribute
    {
    }
}
