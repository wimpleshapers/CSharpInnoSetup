
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Controls the match finder method used by the LZMA and LZMA2 compressors
    /// </summary>
    public enum LZMAMatchFinder
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_lzmamatchfinder.htm">Documentation</a>
        /// </summary>
        [Alias("HC")]
        HashChain,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_lzmamatchfinder.htm">Documentation</a>
        /// </summary>
        [Alias("BT")]
        BinaryTree
    }
}
