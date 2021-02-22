
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public struct THandle
    {
        /// <summary>Convenience operator</summary>
        public static implicit operator long(THandle _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator THandle(long _) => default;
    }
}
