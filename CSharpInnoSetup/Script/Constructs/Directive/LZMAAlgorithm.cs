
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Controls the algorithm used by the LZMA and LZMA2 compressors
    /// </summary>
    public enum LZMAAlgorithm
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_lzmaalgorithm">Documentation</a>
        /// </summary>
        [Alias("0")]
        Fast,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_lzmaalgorithm">Documentation</a>
        /// </summary>
        [Alias("1")]
        Normal
    }
}
