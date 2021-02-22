
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// The Pascal DWORD type
    /// </summary>
    [BuiltInSymbol]
    public struct DWORD
    {
        /// <summary>Convenience operator</summary>
        public static implicit operator int(DWORD _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator long(DWORD _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator DWORD(int _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator DWORD(long _) => default;
    }
}
