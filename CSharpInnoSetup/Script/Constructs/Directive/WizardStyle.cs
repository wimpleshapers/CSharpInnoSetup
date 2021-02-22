
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// The look of the installer UI
    /// </summary>
    public enum WizardStyle
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_wizardstyle.htm">Documentation</a>
        /// </summary>
        [Alias("classic")]
        Classic,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_wizardstyle.htm">Documentation</a>
        /// </summary>
        [Alias("modern")]
        Modern
    }
}
