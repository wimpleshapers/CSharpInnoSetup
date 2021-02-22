
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_iconssection.htm">Documentation</a>
    /// </summary>
    [Flags]
    public enum IconFlags
    {
        /// <summary>
        /// Sets the "Close on Exit" property of the shortcut. This flag only has an effect if the shortcut points to an 
        /// MS-DOS application (if it has a .pif extension, to be specific). If neither this flag nor the dontcloseonexit 
        /// flags are specified, Setup will not attempt to change the "Close on Exit" property.
        /// </summary>
        [Alias("closeonexit")]
        CloseOnExit = 0x1,

        /// <summary>
        /// When this flag is set, the installer will only try to create the icon if the file specified by the Filename 
        /// parameter exists. 
        /// </summary>
        [Alias("createonlyiffileexists")]
        CreateOnlyIfFileExists = 0x2,

        /// <summary>
        /// Same as <see cref="CloseOnExit"/>, except it causes Setup to uncheck the "Close on Exit" property.
        /// </summary>
        [Alias("dontcloseonexit")]
        DoNotCloseOnExit = 0x4,

        /// <summary>
        /// Prevents the Start menu entry for the new shortcut from receiving a highlight on Windows 7 and additionally 
        /// prevents the new shortcut from being automatically pinned the Start screen on Windows 8 (or later). Ignored 
        /// on earlier Windows versions. 
        /// </summary>
        [Alias("excludefromshowinnewinstall")]
        ExcludeFromShowInNewInstall = 0x8,

        /// <summary>
        /// Creates a special type of shortcut known as a "Folder Shortcut". Normally, when a shortcut to a folder is 
        /// present on the Start Menu, clicking the item causes a separate Explorer window to open showing the target 
        /// folder's contents. In contrast, a "folder shortcut" will show the contents of the target folder as a submenu 
        /// instead of opening a separate window.  This flag is currently ignored when running on Windows 7 (or later), 
        /// as folder shortcuts do not expand properly on the Start Menu anymore.It is not known whether this is a bug in 
        /// Windows 7 or a removed feature.  When this flag is used, a folder name must be specified in the Filename parameter.
        /// Specifying the name of a file will result in a non-working shortcut.
        /// </summary>
        [Alias("foldershortcut")]
        FolderShortcut = 0x10,

        /// <summary>
        /// Prevents a Start menu entry from being pinnable to Taskbar or the Start Menu on Windows 7 (or later). This also 
        /// makes the entry ineligible for inclusion in the Start menu's Most Frequently Used (MFU) list. Ignored on earlier 
        /// Windows versions.
        /// </summary>
        [Alias("preventpinning")]
        PreventPinning = 0x20,

        /// <summary>
        /// Sets the "Run" setting of the icon to "Maximized" so that the program will be initially maximized when it is 
        /// started.
        /// </summary>
        [Alias("runmaximized")]
        RunMaximized = 0x40,

        /// <summary>
        /// Sets the "Run" setting of the icon to "Minimized" so that the program will be initially minimized when it 
        /// is started.
        /// </summary>
        [Alias("runminimized")]
        RunMinimized = 0x80,

        /// <summary>
        /// Instructs the uninstaller not to delete the icon.
        /// </summary>
        [Alias("uninsneveruninstall")]
        NeverUninstall = 0x100,

        /// <summary>
        /// Specifies just a filename (no path) in the Filename parameter, and Setup will retrieve the pathname from the 
        /// "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths" registry key and prepend it to the 
        /// filename automatically. 
        /// </summary>
        [Alias("useapppaths")]
        UseApplicationPaths = 0x200
    }
}
