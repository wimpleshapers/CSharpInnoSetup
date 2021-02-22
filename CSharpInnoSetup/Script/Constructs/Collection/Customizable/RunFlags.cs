
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_runsection.htm">Documentation</a>
    /// </summary>
    [Flags]
    public enum RunFlags
    {
        /// <summary>
        /// Causes the {sys} constant to map to the 32-bit System directory when used in the Filename and WorkingDir 
        /// parameters.  This is the default behavior in 32-bit install mode.
        /// </summary>
        /// <remarks>
        /// This flag cannot be combined with the <see cref="ShellExec"/> flag.
        /// </remarks>
        [Alias("32bit")]
        _32bit = 0x1,

        /// <summary>
        /// Causes the {sys} constant to map to the 64-bit System directory when used in the Filename and WorkingDir 
        /// parameters.  This is the default behavior in 64-bit install mode install.
        /// </summary>
        /// <remarks>
        /// This flag can only be used when Setup is running on 64-bit Windows, otherwise an error will occur.  On an 
        /// installation supporting both 32- and 64-bit architectures, it is possible to avoid the error by adding a 
        /// Check: IsWin64 parameter, which will cause the entry to be silently skipped when running on 32-bit Windows.
        /// This flag cannot be combined with the <see cref="ShellExec"/> flag.
        /// </remarks>
        [Alias("64bit")]
        _64bit = 0x2,

        /// <summary>
        /// Excludes the command line parameters for the program from the log file.
        /// </summary>
        [Alias("dontlogparameters")]
        DoNotLogParameters = 0x4,

        /// <summary>
        /// Hides the wizard while the program is running
        /// </summary>
        [Alias("hidewizard")]
        HideWizard = 0x8,

        /// <summary>
        /// Causes the program to execute asynchronously with the installer
        /// </summary>
        [Alias("nowait")]
        NoWait = 0x10,

        /// <summary>
        /// Causes a checkbox to appear on the Setup Completed wizard page. The user can uncheck or check this checkbox 
        /// and thereby choose whether this entry should be processed or not.  If Setup has to restart the user's computer 
        /// (as a result of installing a file with the flag restartreplace or if the AlwaysRestart [Setup] section 
        /// directive is yes), there will not be an opportunity for the checkbox to be displayed and therefore the entry 
        /// will never be processed.
        /// </summary>
        /// <remarks>
        /// The isreadme flag for entries in the [Files] section is now obsolete. If the compiler detects a entry with 
        /// an isreadme flag, it strips the isreadme flag from the[Files] entry and inserts a generated [Run] entry at 
        /// the head of the list of [Run] entries.This generated [Run] entry runs the README file and has flags shellexec, 
        /// skipifdoesntexist, postinstall and skipifsilent.
        /// </remarks>
        [Alias("postinstall")]
        PostInstall = 0x20,

        /// <summary>
        /// Causes the spawned process to inherit Setup/Uninstall's user credentials (typically, full administrative 
        /// privileges).  This is the default behavior when the <see cref="PostInstall"/> flag is not used.
        /// </summary>
        /// <remarks>
        /// This flag is only valid in the Run section and cannot be combined with the <see cref="RunAsOriginalUser"/> flag.
        /// </remarks>
        [Alias("runascurrentuser")]
        RunAsCurrentUser = 0x40,

        /// <summary>
        /// Causes the spawned process to execute with the (normally non-elevated) credentials of the user that started 
        /// Setup initially(i.e., the "pre-UAC dialog" credentials).  This is the default behavior when the 
        /// <see cref="PostInstall"/> flag is used.
        /// </summary>
        /// <remarks>
        /// If a user launches Setup by right-clicking its EXE file and selecting "Run as administrator", then this flag, 
        /// unfortunately, will have no effect, because Setup has no opportunity to run any code with the original user 
        /// credentials. The same is true if Setup is launched from an already-elevated process. Note, however, that this 
        /// is not an Inno Setup-specific limitation; Windows Installer-based installers cannot return to the original user 
        /// credentials either in such cases.  This flag cannot be combined with the <see cref="RunAsCurrentUser"/> flag.
        /// </remarks>
        [Alias("runasoriginaluser")]
        RunAsOriginalUser = 0x80,

        /// <summary>
        /// Launches the program in a hidden window.  Never use this flag when executing a program that may prompt for user input.
        /// </summary>
        [Alias("runhidden")]
        RunHidden = 0x100,

        /// <summary>
        /// Launches the program or document in a maximized window.
        /// </summary>
        [Alias("runmaximized")]
        RunMaximized = 0x200,

        /// <summary>
        /// Launch the program or document in a minimized window.
        /// </summary>
        [Alias("runminimized")]
        RunMinimized = 0x400,

        /// <summary>
        /// This flag is required if Filename is not a directly executable file (an.exe or .com file). When this flag is 
        /// set, Filename can be a folder or any registered file type -- including.chm, .doc, and so on.The file will be 
        /// opened with the application associated with the file type on the user's system, the same way it would be if 
        /// the user double-clicked the file in Explorer.
        /// </summary>
        /// <remarks>
        /// By default, when the shellexec flag is used it will not wait until the spawned process terminates. If you need 
        /// that, you must add the flag waituntilterminated.Note that it cannot and will not wait if a new process isn't 
        /// spawned -- for example, if Filename specifies a folder.
        /// </remarks>
        [Alias("shellexec")]
        ShellExec = 0x800,

        /// <summary>
        /// In the [Run] section, Setup won't display an error message if Filename doesn't exist.  In the[UninstallRun] 
        /// section, the uninstaller won't display the "some elements could not be removed" warning if Filename doesn't 
        /// exist.  When this flag is used, Filename must be an absolute path.
        /// </summary>
        [Alias("skipifdoesntexist")]
        SkipIfDoesNotExist = 0x1000,

        /// <summary>
        /// Entry is skipped if Setup is not running (very)silent.  Valid only in the [Run] section.
        /// </summary>
        [Alias("skipifnotsilent")]
        SkipIfNotSilent = 0x2000,

        /// <summary>
        /// Entry is skipped if Setup is running (very)silent.  Valid only in the [Run] section.
        /// </summary>
        [Alias("skipifsilent")]
        SkipIfSilent = 0x4000,

        /// <summary>
        /// Causes the checkbox to be initially unchecked.  The user can still check the checkbox if he/she wishes 
        /// to process the entry.  This flag is ignored if the <see cref="PostInstall"/> flag isn't also specified.
        /// Valid only in the [Run] section.
        /// </summary>
        [Alias("unchecked")]
        Unchecked = 0x8000,

        /// <summary>
        /// Waits until the process is waiting for user input with no input pending, instead of waiting for the process 
        /// to terminate. (This calls the WaitForInputIdle Win32 function.) Cannot be combined with <see cref="NoWait"/> or 
        /// <see cref="WaitUntilTerminated"/>.
        /// </summary>
        [Alias("waituntilidle")]
        WaitUntilIdle = 0x10000,

        /// <summary>
        /// Waits until the process has completely terminated.  Note that this is the default behavior (i.e. you don't need 
        /// to specify this flag) unless you're using <see cref="ShellExec"/> flag, in which case you do need to specify this 
        /// flag if you want it to wait. Cannot be combined with <see cref="NoWait"/> or <see cref="WaitUntilIdle"/>.
        /// </summary>
        [Alias("waituntilterminated")]
        WaitUntilTerminated = 0x20000
    }
}
