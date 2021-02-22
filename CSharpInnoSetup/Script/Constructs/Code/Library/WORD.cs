
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Pascal WORD data type
    /// </summary>
    [BuiltInSymbol]
    public struct WORD
    {
        /// <summary>Convenience operator</summary>
        public static implicit operator ushort(WORD _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator WORD(ushort _) => default;
    }
}
