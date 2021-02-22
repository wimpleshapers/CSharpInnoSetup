
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_filessection.htm">Documentation</a>
    /// </summary>
    [Flags]
    public enum FileFlags : long
    {
        /// <summary>
        /// Causes the {sys} constant to map to the 32-bit System directory when used in the Source and DestDir parameters
        /// </summary>
        [Alias("32bit")]
        _32Bit = 0x1,

        /// <summary>
        /// Causes the { sys} constant to map to the 64-bit System directory when used in the Source and DestDir parameters
        /// </summary>
        [Alias("64bit")]
        _64Bit = 0x2,

        /// <summary>
        /// Disables the compiler's automatic checking for unsafe files
        /// </summary>
        /// <remarks>
        /// It is strongly recommended that you DO NOT use this flag, unless you are absolutely sure you know what you're doing
        /// </remarks>
        [Alias("allowunsafefiles")]
        AllowUnsafeFiles = 0x4,

        /// <summary>
        /// Instructs Setup to proceed to comparing time stamps if the file being installed already exists on the user's system, and at least one of the following conditions is true:
        ///
        ///  Neither the existing file nor the file being installed has version info.
        ///  The ignoreversion flag is also used on the entry.
        ///  The replacesameversion flag isn't used, and the existing file and the file being installed have the same version number (as determined by the files' version info).
        ///
        /// If the existing file has an older time stamp than the file being installed, the existing file will replaced.Otherwise, it will not be replaced.
        /// </summary>
        /// <remarks>
        /// Use of this flag is not recommended except as a last resort, because there is an inherent issue with it: NTFS partitions store time stamps in UTC (unlike FAT partitions),
        /// which causes local time stamps -- what Inno Setup works with by default -- to shift whenever a user changes their system's time zone or when daylight saving time goes into or out of effect. This can create a situation where files are replaced when the user doesn't expect them to be, or not replaced when the user expects them to be.
        /// </remarks>
        [Alias("comparetimestamp")]
        CompareTimeStamp = 0x8,

        /// <summary>
        /// Always ask the user to confirm before replacing an existing file.
        /// </summary>
        [Alias("confirmoverwrite")]
        ConfirmOverwrite = 0x10,

        /// <summary>
        /// By default the compiler skips empty directories when it recurses subdirectories searching for the Source filename/wildcard.
        /// This flag causes these directories to be created at install time (just like if you created [Dirs] entries for them).
        /// Must be combined with recursesubdirs.
        /// </summary>
        [Alias("createallsubdirs")]
        CreateAllSubdirs = 0x20,

        /// <summary>
        /// Instructs Setup to install the file as usual, but then delete it once the installation is completed(or aborted).  This can be
        /// useful for extracting temporary data needed by a program executed in the script's [Run] section.
        /// This flag will not cause existing files that weren't replaced during installation to be deleted.
        /// This flag cannot be combined with the isreadme, regserver, regtypelib, restartreplace, sharedfile, or uninsneveruninstall flags.
        /// </summary>
        [Alias("deleteafterinstall")]
        DeleteAfterInstall = 0x40,

        /// <summary>
        /// Don't copy the file to the user's system during the normal file copying stage but do statically compile the file into the installation.
        /// This flag is useful if the file is handled by the[Code] section exclusively and extracted using ExtractTemporaryFile.
        /// </summary>
        [Alias("dontcopy")]
        DoNotCopy = 0x80,

        /// <summary>
        /// Prevents Setup from verifying the file checksum after extraction.  Use this flag on files you wish to modify while already compiled
        /// into Setup.  Must be combined with nocompression.
        /// </summary>
        [Alias("dontverifychecksum")]
        DoNotVerifyChecksum = 0x100,

        /// <summary>
        /// This flag instructs Inno Setup not to statically compile the file specified by the Source parameter into the installation files,
        /// but instead copy from an existing file on the distribution media or the user's system. See the <see cref="FileEntry.Source"/>
        /// parameter description for more information.
        /// </summary>
        [Alias("external")]
        External = 0x200,

        /// <summary>
        /// Specify this flag if the entry is installing a non-TrueType font with the FontInstall parameter.
        /// </summary>
        [Alias("fontisnttruetype")]
        FontIsNotTrueType = 0x400,

        /// <summary>
        /// Install the file into the .NET Global Assembly Cache. When used in combination with sharedfile, the file will only be uninstalled
        /// when the reference count reaches zero.  To uninstall the file Uninstaller uses the strong assembly name specified by parameter
        /// StrongAssemblyName.  An exception will be raised if an attempt is made to use this flag on a system with no .NET Framework present.
        /// </summary>
        [Alias("gacinstall")]
        GacInstall = 0x800,

        /// <summary>
        /// Don't compare version info at all; replace existing files regardless of their version number.  This flag should only be used on files
        /// private to your application, never on shared system files.
        /// </summary>
        [Alias("ignoreversion")]
        IgnoreVersion = 0x1000,

        /// <summary>
        /// File is the "README" file.Only one file in an installation can have this flag.  When a file has this flag, the user will asked if
        /// he/she would like to view the README file after the installation has completed.If Yes is chosen, Setup will open the file, using
        /// the default program for the file type.For this reason, the README file should always end with an extension like .txt, .wri, or.doc.
        /// </summary>
        /// <remarks>
        /// ote that if Setup has to restart the user's computer (as a result of installing a file with the flag restartreplace or if the
        /// <see cref="Installation.AlwaysRestart"/> directive is yes), the user will not be given an option to view the README file.
        /// </remarks>
        [Alias("isreadme")]
        IsReadme = 0x2000,

        /// <summary>
        /// Prevents the compiler from attempting to compress the file. Use this flag on file types that you know can't benefit from compression
        /// (for example, JPEG images) to speed up the compilation process and save a few bytes in the resulting installation.
        /// </summary>
        [Alias("nocompression")]
        NoCompression = 0x4000,

        /// <summary>
        /// Prevents the file from being stored encrypted. Use this flag if you have enabled encryption (using the [Setup] section directive Encryption)
        /// but want to be able to extract the file using the [Code] section support function ExtractTemporaryFile before the user has entered the
        /// correct password.
        /// </summary>
        [Alias("noencryption")]
        NoEncryption = 0x8000,

        /// <summary>
        /// When combined with either the regserver or regtypelib flags, Setup will not display any error message if the registration fails.
        /// </summary>
        [Alias("noregerror")]
        NoRegError = 0x10000,

        /// <summary>
        /// Only install the file if a file of the same name already exists on the user's system. This flag may be useful if your installation
        /// is a patch to an existing installation, and you don't want files to be installed that the user didn't already have.
        /// </summary>
        [Alias("onlyifdestfileexists")]
        OnlyIfDestinationFileExists = 0x20000,

        /// <summary>
        /// Only install the file if it doesn't already exist on the user's system.
        /// </summary>
        [Alias("onlyifdoesntexist")]
        OnlyIfDoesNotExist = 0x40000,

        /// <summary>
        /// Always overwrite a read-only file. Without this flag, Setup will ask the user if an existing read-only file should be overwritten.
        /// </summary>
        [Alias("overwritereadonly")]
        OverwriteReadOnly = 0x80000,

        /// <summary>
        /// By default, when a file being installed has an older version number (or older time stamp, when the comparetimestamp flag is used)
        /// than an existing file, Setup will not replace the existing file. (See the Remarks section at the bottom of this topic for more details.)
        /// When this flag is used, Setup will ask the user whether the file should be replaced, with the default answer being to keep the existing
        /// file.
        /// </summary>
        [Alias("promptifolder")]
        PromptIfOlder = 0x100000,

        /// <summary>
        /// Instructs the compiler or Setup to also search for the Source filename/wildcard in subdirectories under the Source directory.
        /// </summary>
        [Alias("recursesubdirs")]
        RecurseSubDirectories = 0x200000,

        /// <summary>
        /// Register the DLL/OCX file. With this flag set, Setup will call the DllRegisterServer function exported by the DLL/OCX file, and
        /// the uninstaller will call DllUnregisterServer prior to removing the file.When used in combination with sharedfile, the DLL/OCX file
        /// will only be unregistered when the reference count reaches zero.
        /// </summary>
        /// <remarks>
        /// In 64-bit install mode, the file is assumed to be a 64-bit image and will be registered inside a 64-bit process. You can override
        /// this by specifying the 32bit flag.
        /// </remarks>
        [Alias("regserver")]
        RegServer = 0x400000,

        /// <summary>
        /// Register the type library (.tlb). The uninstaller will unregister the type library (unless the flag uninsneveruninstall is specified).
        /// As with the regserver flag, when used in combination with sharedfile, the file will only be unregistered by the uninstaller when the
        /// reference count reaches zero.
        /// </summary>
        /// <remarks>
        /// In 64-bit install mode running on an x64 edition of Windows, the type library will be registered inside a 64-bit process. You can
        /// override this by specifying the 32bit flag.  Registering type libraries in 64-bit mode on Itanium editions of Windows is not supported.
        /// </remarks>
        [Alias("regtypelib")]
        RegTypeLibrary = 0x800000,

        /// <summary>
        /// When this flag is used and the file already exists on the user's system and it has the same version number as the file being installed,
        /// Setup will compare the files and replace the existing file if their contents differ.
        /// </summary>
        /// <remarks>
        /// The default behavior (i.e. when this flag isn't used) is to not replace an existing file with the same version number.
        /// </remarks>
        [Alias("replacesameversion")]
        ReplaceSameVersion = 0x1000000,

        /// <summary>
        /// When an existing file needs to be replaced, and it is in use (locked) by another running process, Setup will by default display an
        /// error message. This flag tells Setup to instead register the file to be replaced the next time the system is restarted (by calling
        /// MoveFileEx or by creating an entry in WININIT.INI). When this happens, the user will be prompted to restart their computer at the
        /// end of the installation process.
        /// </summary>
        /// <remarks>
        /// NOTE: This flag has no effect if the user does not have administrative privileges. Therefore, when using this flag, it is recommended
        /// that you leave the PrivilegesRequired [Setup] section directive at the default setting of admin.
        /// </remarks>
        [Alias("restartreplace")]
        RestartReplace = 0x2000000,

        /// <summary>
        /// Instructs Setup to enable NTFS compression on the file (even if it didn't replace the file). If it fails to set the compression
        /// state for any reason (for example, if compression is not supported by the file system), no error message will be displayed.
        /// </summary>
        [Alias("setntfscompression")]
        SetNTFSCompression = 0x4000000,

        /// <summary>
        /// Specifies that the file is shared among multiple applications, and should only be removed at uninstall time if no other applications
        /// are using it. Most files installed to the Windows System directory should use this flag, including.OCX, .BPL, and.DPL files.
        /// </summary>
        /// <remarks>
        /// Windows' standard shared file reference-counting mechanism (located in the registry under
        /// HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\SharedDLLs) is used to keep track of how many applications depend on
        /// the file. Each time the file is installed, the reference count for the file is incremented. (This happens regardless of whether
        /// the installer actually replaces the file on disk.) When an application using the file is uninstalled, the reference count is
        /// decremented. If the count reaches zero, the file is deleted (with the user's confirmation, unless the uninsnosharedfileprompt flag
        /// is also specified).
        /// </remarks>
        [Alias("sharedfile")]
        SharedFile = 0x8000000,

        /// <summary>
        /// This flag instructs the compiler to digitally sign the original source files before storing them.Ignored if [Setup] section
        /// directive SignTool is not set.
        /// </summary>
        [Alias("sign")]
        Sign = 0x10000000,

        /// <summary>
        /// This flag instructs the compiler to digitally sign the original source files before storing them, but only if the files are
        /// not already signed. Ignored if [Setup] section directive SignTool is not set.
        /// </summary>
        [Alias("signonce")]
        SignOnce = 0x20000000,

        /// <summary>
        /// This flag instructs the compiler -- or Setup, if the external flag is also used -- to silently skip over the entry if the source
        /// file does not exist, instead of displaying an error message.
        /// </summary>
        [Alias("skipifsourcedoesntexist")]
        SkipIfSourceDoesNotExist = 0x40000000,

        /// <summary>
        /// When solid compression is enabled, this flag instructs the compiler to finalize the current compression stream and begin a new
        /// one before compressing the file(s) matched by Source.This allows Setup to seek to the file instantly without having to decompress
        /// any preceding files first.May be useful in a large, multi-component installation if you find too much time is being spent decompressing
        /// files belonging to components that weren't selected.
        /// </summary>
        [Alias("solidbreak")]
        SolidBreak = 0x80000000,

        /// <summary>
        /// This flag instructs the compiler to compress the found files sorted by extension before it sorts by path name.  This potentially decreases
        /// the size of Setup if solid compression is also used. 
        /// </summary>
        [Alias("sortfilesbyextension")]
        SortFilesByExtension = 0x100000000,

        /// <summary>
        /// This flag instructs the compiler to compress the found files sorted by name before it sorts by path name. This potentially decreases the
        /// size of Setup if solid compression is also used. If sortfilesbyextension is also used, files are first sorted by extension.
        /// </summary>
        [Alias("sortfilesbyname")]
        SortFilesByName = 0x200000000,

        /// <summary>
        /// This flag causes Setup to set the time/date stamp of the installed file(s) to that which is specified by the TouchDate and TouchTime
        /// [Setup] section directives.
        /// </summary>
        /// <remarks>
        /// This flag has no effect if combined with the external flag.
        /// </remarks>
        [Alias("touch")]
        Touch = 0x400000000,

        /// <summary>
        /// When uninstalling the shared file, automatically remove the file if its reference count reaches zero instead of asking the user. Must
        /// be combined with the sharedfile flag to have an effect. 
        /// </summary>
        [Alias("uninsnosharedfileprompt")]
        UninstallNoSharedFilePrompt = 0x800000000,

        /// <summary>
        /// When uninstalling the file, remove any read-only attribute from the file before attempting to delete it.
        /// </summary>
        [Alias("uninsremovereadonly")]
        UninstallRemoveReadOnly = 0x1000000000,

        /// <summary>
        /// When this flag is used and the file is in use at uninstall time, the uninstaller will queue the file to be deleted when the system
        /// is restarted, and at the end of the uninstallation process ask the user if he/she wants to restart. This flag can be useful when
        /// uninstalling things like shell extensions which cannot be programmatically stopped. Note that administrative privileges are required
        /// for this flag to have an effect. 
        /// </summary>
        [Alias("uninsrestartdelete")]
        UninstallRestartDelete = 0x2000000000,

        /// <summary>
        /// Never remove the file.  This flag can be useful when installing very common shared files that shouldn't be deleted under any
        /// circumstances, such as MFC DLLs. 
        /// </summary>
        /// <remarks>
        /// Note that if this flag is combined with the sharedfile flag, the file will never be deleted at uninstall time but the reference
        /// count will still be properly decremented.
        /// </remarks>
        [Alias("uninsneveruninstall")]
        UninstallNeverRemove = 0x4000000000,

        /// <summary>
        /// Instructs Setup to disable NTFS compression on the file (even if it didn't replace the file). If it fails to set the compression
        /// state for any reason (for example, if compression is not supported by the file system), no error message will be displayed. 
        /// </summary>
        [Alias("unsetntfscompression")]
        DisableNTFSCompression = 0x8000000000
    }
}
