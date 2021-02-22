
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code
{
    /// <summary>
    /// Flags for the <see cref="ExternalSymbolOptionsAttribute"/>
    /// </summary>
    [Flags]
    public enum ExternalSymbolOption
    {
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptdll.htm">Documentation</a>
        [Alias("delayload")]
        DelayLoad = 0x1,

        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptdll.htm">Documentation</a>
        [Alias("loadwithalteredsearchpath")]
        LoadWithAlteredSearchPath = 0x2,

        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptdll.htm">Documentation</a>
        [Alias("setuponly")]
        SetupOnly = 0x4,

        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptdll.htm">Documentation</a>
        [Alias("uninstallonly")]
        UninstallOnly = 0x8
    }
}
