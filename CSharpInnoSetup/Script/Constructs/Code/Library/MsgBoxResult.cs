
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    [GlobalNamespace]
    [DeclaredAs(typeof(int))]
    public sealed class MsgBoxResult
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("IDOK")]
        public static MsgBoxResult Ok = default;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("IDCANCEL")]
        public static MsgBoxResult Cancel = default;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("IDABORT")]
        public static MsgBoxResult Abort = default;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("IDRETRY")]
        public static MsgBoxResult Retry = default;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("IDIGNORE")]
        public static MsgBoxResult Ignore = default;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("IDYES")]
        public static MsgBoxResult Yes = default;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("IDNO")]
        public static MsgBoxResult No = default;

        /// <summary>Convenience operator</summary>
        public static implicit operator int(MsgBoxResult _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator MsgBoxResult(int _) => default;

        private MsgBoxResult()
        {
        }
    }
}
