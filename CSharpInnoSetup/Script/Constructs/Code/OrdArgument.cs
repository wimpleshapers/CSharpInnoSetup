
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library;
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code
{
    /// <summary>
    /// The argument passed to the <see cref="Installation.Ord"/> method
    /// </summary>
    [BuiltInSymbol]
    public class OrdArgument
    {
        /// <summary>Convenience operator</summary>
        public static implicit operator OrdArgument(int arg) => null;
        /// <summary>Convenience operator</summary>
        public static implicit operator OrdArgument(Enum arg) => null;
    }
}
