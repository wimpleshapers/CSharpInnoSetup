
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    [GlobalNamespace]
    [DeclaredAs(typeof(int))]
    public sealed class MB
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("MB_OK")]
        public static MB Ok;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("MB_OKCANCEL")]
        public static MB OkCancel;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("MB_ABORTRETRYIGNORE")]
        public static MB AbortRetryIgnore;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("MB_YESNOCANCEL")]
        public static MB YesNoCancel;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("MB_YESNO")]
        public static MB YesNo;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("MB_RETRYCANCEL")]
        public static MB RetryCancel;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("MB_DEFBUTTON1")]
        public static MB DefaultButton1;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("MB_DEFBUTTON2")]
        public static MB DefaultButton2;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("MB_DEFBUTTON3")]
        public static MB DefaultButton3;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("MB_SETFOREGROUND")]
        public static MB SetForeground;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("MB_ICONWARNING")]
        public static MB IconWarning;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("MB_ICONINFORMATION")]
        public static MB IconInformation;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("MB_ICONQUESTION")]
        public static MB IconQuestion;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_msgbox">Documentation</a>
        /// </summary>
        [Alias("MB_ICONERROR")]
        public static MB IconError;

        /// <summary>Convenience operator</summary>
        public static implicit operator int(MB _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator Cardinal(MB _) => default;
        /// <summary>Convenience operator</summary>
        public static MB operator |(MB _, MB unused) => default;

        private MB()
        {
        }
    }
}
