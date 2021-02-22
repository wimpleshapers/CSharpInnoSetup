
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_inisection.htm">Documentation</a>
    /// </summary>
    [Flags]
    public enum IniFlags
    {
        /// <summary>
        /// Assign to the key only if the key doesn't already exist in the file. If this flag is not specified, the key will 
        /// be set regardless of whether it already existed.
        /// </summary>
        [Alias("createkeyifdoesntexist")]
        CreateKeyIfDoesNotExist = 0x1,

        /// <summary>
        /// Delete the entry when the program is uninstalled. This can be combined with the 
        /// <see cref="UninstallDeleteSectionIfEmpty"/> flag.
        /// </summary>
        [Alias("uninsdeleteentry")]
        UninstallDeleteEntry = 0x2,

        /// <summary>
        /// When the program is uninstalled, delete the entire section in which the entry is located. It obviously wouldn't 
        /// be a good idea to use this on a section that is used by Windows itself (like some of the sections in WIN.INI). 
        /// You should only use this on sections private to your application.
        /// </summary>
        [Alias("uninsdeletesection")]
        UninstallDeleteSection = 0x4,

        /// <summary>
        /// Same as uninsdeletesection, but deletes the section only if there are no keys left in it. This can be combined 
        /// with the <see cref="UninstallDeleteEntry"/> flag.
        /// </summary>
        [Alias("uninsdeletesectionifempty")]
        UninstallDeleteSectionIfEmpty = 0x8
    }
}
