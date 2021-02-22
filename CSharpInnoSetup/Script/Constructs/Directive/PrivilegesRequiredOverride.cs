
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Overrides for the default <see cref="Installation.PrivilegesRequired"/> value
    /// </summary>
    [Flags]
    public enum PrivilegesRequiredOverride
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_privilegesrequiredoverridesallowed.htm">Documentation</a>
        /// </summary>
        [Alias("commandline")]
        CommandLine = 0x1,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_privilegesrequiredoverridesallowed.htm">Documentation</a>
        /// </summary>
        [Alias("dialog")]
        Dialog = 0x2
    }
}
