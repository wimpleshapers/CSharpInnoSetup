
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// The 64-bit processor architectures
    /// </summary>
    [Flags]
    public enum InstallMode64Bit
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_architecturesinstallin64bitmode.htm">Documentation</a>
        /// </summary>
        [Alias("x64")]
        X64 = 0x1,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_architecturesinstallin64bitmode.htm">Documentation</a>
        /// </summary>
        [Alias("arm64")]
        ARM64 = 0x2,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_architecturesinstallin64bitmode.htm">Documentation</a>
        /// </summary>
        [Alias("ia64")]
        IA64 = 0x4
    }
}
