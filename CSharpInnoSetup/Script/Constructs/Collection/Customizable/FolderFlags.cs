
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_dirssection.htm">Documentation</a>
    /// </summary>
    [Flags]
    public enum FolderFlags
    {
        /// <summary>
        /// Create the folder as usual, but then delete it once the installation is completed (or aborted) if it's empty. 
        /// This can be useful when extracting temporary data needed by a program executed in the script's [Run] section.
        /// </summary>
        /// <remarks>
        /// This flag will not cause folders that already existed before installation to be deleted.
        /// </remarks>
        [Alias("deleteafterinstall")]
        DeleteAfterInstall = 0x1,

        /// <summary>
        /// enable NTFS compression on the folder. If it fails to set the compression state for any reason (for example, 
        /// if compression is not supported by the file system), no error message will be displayed.
        /// </summary>
        /// <remarks>
        /// If the folder already exists, the compression state of any files present in the folder will not be changed.
        /// </remarks>
        [Alias("setntfscompression")]
        SetNtfsCompression = 0x2,

        /// <summary>
        /// During uninstall, deletes the folder if it's empty. Normally the uninstaller will only try to delete the 
        /// folder if it didn't already exist prior to installation.
        /// </summary>
        [Alias("uninsalwaysuninstall")]
        AlwaysUninstall = 0x4,

        /// <summary>
        /// During uninstall, the folder will not be deleted.  By default, the uninstaller deletes any folder specified 
        /// by a <see cref="FolderEntry"/> if it is empty.
        /// </summary>
        [Alias("uninsneveruninstall")]
        NeverUninstall = 0x8,

        /// <summary>
        /// Disable NTFS compression on the folder. If it fails to set the compression state for any reason (for example, 
        /// if compression is not supported by the file system), no error message will be displayed.
        /// </summary>
        /// <remarks>
        /// If the folder already exists, the compression state of any files present in the folder will not be changed.
        /// </remarks>
        [Alias("unsetntfscompression")]
        UnsetNtfsCompression = 0x10
    }
}
