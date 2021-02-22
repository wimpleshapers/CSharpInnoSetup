
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_installdeletesection.htm">Documentation</a>, or
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_uninstalldeletesection.htm">Documentation</a>
    /// </summary>
    [Flags]
    public enum DeleteFlags
    {
        /// <summary>
        /// The <see cref="DeleteEntry.Pattern"/> parameter specifies a name of a particular file, or a filename with 
        /// wildcards.
        /// </summary>
        [Alias("files")]
        Files = 0x1,

        /// <summary>
        /// Functions the same as files except it matches directory names also, and any directories matching the name are 
        /// deleted including all files and subdirectories in them.
        /// </summary>
        [Alias("filesandordirs")]
        FilesAndOrFolders = 0x2,

        /// <summary>
        /// When this is used, the <see cref="DeleteEntry.Pattern"/> parameter must be the name of a directory, but it 
        /// cannot include wildcards. The directory will only be deleted if it contains no files or subdirectories.
        /// </summary>
        [Alias("dirifempty")]
        FolderIfEmpty = 0x4
    }
}
