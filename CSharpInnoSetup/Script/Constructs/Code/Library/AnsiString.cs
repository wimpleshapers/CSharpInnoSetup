
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// The Pascal AnsiString type 
    /// </summary>
    [BuiltInSymbol]
    public sealed class AnsiString
    {
        /// <summary>Convenience operator</summary>
        public static implicit operator string(AnsiString _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator AnsiString(string _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator PAnsiChar(AnsiString _) => default;
    }
}
