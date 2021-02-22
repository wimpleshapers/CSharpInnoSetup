
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public sealed class TAnchors : Set<TAnchorKind>
    {
        /// <summary>Convenience operator</summary>
        public static implicit operator TAnchors(TAnchorKind[] _) => default;
    }
}
