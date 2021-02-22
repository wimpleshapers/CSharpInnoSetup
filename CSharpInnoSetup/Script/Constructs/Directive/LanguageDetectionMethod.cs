
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// How setup determines the language
    /// </summary>
    public enum LanguageDetectionMethod
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_languagedetectionmethod">Documentation</a>
        /// </summary>
        [Alias("none")]
        None,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_languagedetectionmethod">Documentation</a>
        /// </summary>
        [Alias("uilanguage")]
        UILanguage,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_languagedetectionmethod">Documentation</a>
        /// </summary>
        [Alias("locale")]
        Locale
    }
}
