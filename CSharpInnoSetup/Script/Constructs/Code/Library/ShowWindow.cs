
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptfunctions">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    [GlobalNamespace]
    public sealed class ShowWindow
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptfunctions">Documentation</a>
        /// </summary>
        [Alias("SW_SHOW")]
        public static ShowWindow Show;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptfunctions">Documentation</a>
        /// </summary>
        [Alias("SW_SHOWNORMAL")]
        public static ShowWindow Normal;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptfunctions">Documentation</a>
        /// </summary>
        [Alias("SW_SHOWMAXIMIZED")]
        public static ShowWindow Maximized;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptfunctions">Documentation</a>
        /// </summary>
        [Alias("SW_SHOWMINIMIZED")]
        public static ShowWindow Minimized;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptfunctions">Documentation</a>
        /// </summary>
        [Alias("SW_SHOWMINNOACTIVE")]
        public static ShowWindow MinNoActive;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptfunctions">Documentation</a>
        /// </summary>
        [Alias("SW_HIDE")]
        public static ShowWindow Hide;

        /// <summary>Convenience operator</summary>
        public static implicit operator int(ShowWindow _) => default;

        private ShowWindow()
        {
        }
    }
}
