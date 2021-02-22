
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public sealed class TArrayOfString
    {
        /// <summary>Convenience operator</summary>
        public static implicit operator string[](TArrayOfString _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator TArrayOfString(string[] _) => default;
        /// <summary>Convenience operator</summary>
        public string this[int index] { get => default; set { } }

        private TArrayOfString()
        {
        }
    }
}
