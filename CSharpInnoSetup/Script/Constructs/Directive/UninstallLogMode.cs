
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Controls how the uninstall log are written
    /// </summary>
    public enum UninstallLogMode
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_uninstalllogmode.htm">Documentation</a>
        /// </summary>
        [Alias("append")]
        Append,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_uninstalllogmode.htm">Documentation</a>
        /// </summary>
        [Alias("new")]
        New,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_uninstalllogmode.htm">Documentation</a>
        /// </summary>
        [Alias("overwrite")]
        Overwrite
    }
}
