
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// How LZMA compression should be executed
    /// </summary>
    public enum X86Triad
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_lzmauseseparateprocess.htm">Documentation</a>
        /// </summary>
        [Alias("yes")]
        Yes,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_lzmauseseparateprocess.htm">Documentation</a>
        /// </summary>
        [Alias("no")]
        No,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_lzmauseseparateprocess.htm">Documentation</a>
        /// </summary>
        [Alias("x86")]
        X86
    }
}
