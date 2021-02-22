
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public sealed class TFontStyles : Set<TFontStyle>
    {
        /// <summary>Convenience operator</summary>
        public static implicit operator TFontStyles(TFontStyle[] _) => default;
        /// <summary>Convenience operator</summary>
        public static TFontStyles operator +(TFontStyles _, TFontStyle[] unused) => default;
    }
}
