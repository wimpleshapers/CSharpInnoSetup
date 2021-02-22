
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_architecturesallowed">Documentation</a>
    /// </summary>
    [Flags]
    public enum Architecture
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_architecturesallowed">Documentation</a>
        /// </summary>
        [Alias("x86")]
        X86 = 0x1,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_architecturesallowed">Documentation</a>
        /// </summary>
        [Alias("x64")]
        X64 = 0x2,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_architecturesallowed">Documentation</a>
        /// </summary>
        [Alias("arm64")]
        Arm64 = 0x4,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_architecturesallowed">Documentation</a>
        /// </summary>
        [Alias("ia64")]
        IA64 = 0x8
    }
}
