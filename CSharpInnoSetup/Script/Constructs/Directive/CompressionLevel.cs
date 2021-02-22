
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Compression level
    /// </summary>
    public enum CompressionLevel
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        [Alias("normal")]
        Normal,
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        [Alias("fast")]
        Fast,
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        [Alias("max")]
        Max,
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        [Alias("ultra")]
        Ultra,
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        [Alias("ultra2")]
        Ultra2
    }
}
