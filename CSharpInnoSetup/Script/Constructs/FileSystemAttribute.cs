
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs
{
    /// <summary>
    /// Flags used by files
    /// </summary>
    [Flags]
    public enum FileSystemAttribute
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=filessection">Documentation</a>
        /// </summary>
        [Alias("readonly")]
        ReadOnly = 0x1,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=filessection">Documentation</a>
        /// </summary>
        [Alias("hidden")]
        Hidden = 0x2,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=filessection">Documentation</a>
        /// </summary>
        [Alias("system")]
        System = 0x4,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=filessection">Documentation</a>
        /// </summary>
        [Alias("notcontentindexed")]
        NotContentIndexed = 0x8
    }
}
