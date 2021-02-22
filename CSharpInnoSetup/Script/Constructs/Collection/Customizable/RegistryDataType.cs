
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
    /// </summary>
    public enum RegistryDataType
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
        /// </summary>
        [Alias("none")]
        None,

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
        /// </summary>
        [Alias("string")]
        String,

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
        /// </summary>
        [Alias("expandsz")]
        ExpandedString,

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
        /// </summary>
        [Alias("multisz")]
        MultiString,

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
        /// </summary>
        [Alias("dword")]
        Dword,

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
        /// </summary>
        [Alias("qword")]
        Qword,

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
        /// </summary>
        [Alias("binary")]
        Binary
    }
}
