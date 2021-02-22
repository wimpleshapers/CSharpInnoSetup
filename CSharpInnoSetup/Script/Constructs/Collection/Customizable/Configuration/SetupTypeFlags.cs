
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_typessection.htm">Documentation</a>
    /// </summary>
    [Flags]
    public enum SetupTypeFlags
    {
        /// <summary>
        /// Instructs Setup that the type is a custom type. Whenever the end user manually changes the components selection during 
        /// installation, Setup will set the setup type to the custom type. Note that if you don't define a custom type, Setup will 
        /// only allow the user to choose a setup type and he/she can no longer manually select/unselect components.
        /// </summary>
        /// <remarks>
        /// Only one type may include this flag.
        /// </remarks>
        [Alias("iscustom")]
        IsCustom = 0x1
    }
}
