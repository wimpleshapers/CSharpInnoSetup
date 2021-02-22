
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library;
using System;

namespace CodingMuscles.CSharpInnoSetup
{
    public partial class Installation
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_sleep.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void Sleep(long Milliseconds) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_random.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public int Random(int Range) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_beep.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void Beep() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_set8087cw.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void Set8087CW(ushort NewCW) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_get8087cw.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public ushort Get8087CW() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_bringtofrontandrestore.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void BringToFrontAndRestore() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://wiki.freepascal.org/Set">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void Include<T>(Set<T> set, params T[] items) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://wiki.freepascal.org/Set">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void Exclude<T>(Set<T> set, params T[] items) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="xxxxxxxxxxxxxxx">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public long SizeOf(object value) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getarraylength.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public long GetArrayLength<TElement>(TElement[] Arr) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_setarraylength.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void SetArrayLength<TElement>(ref TElement[] Arr, long I) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createoleobject.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public dynamic CreateOleObject(string ClassName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getactiveoleobject.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public dynamic GetActiveOleObject(string ClassName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_idispatchinvoke.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public dynamic IDispatchInvoke(IDispatch Self, bool PropertySet, string Name, ArrayOf<dynamic> Par) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createcomobject.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public IUnknown CreateComObject(TGUID ClassID) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_stringtoguid.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TGUID StringToGuid(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_olecheck.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void OleCheck(HResult Result) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_cofreeunusedlibraries.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void CoFreeUnusedLibraries() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_msgbox.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public MsgBoxResult MsgBox(string Text, TMsgBoxType Typ, MB Buttons) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_suppressiblemsgbox.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public MsgBoxResult SuppressibleMsgBox(string Text, TMsgBoxType Typ, MB Buttons, MsgBoxResult Default) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_taskdialogmsgbox.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public MsgBoxResult TaskDialogMsgBox(string Instruction, string Text, TMsgBoxType Typ, MB Buttons, TArrayOfString ButtonLabels, MsgBoxResult ShieldButton) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_suppressibletaskdialogmsgbox.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public MsgBoxResult SuppressibleTaskDialogMsgBox(string Instruction, string Text, TMsgBoxType Typ, MB Buttons, TArrayOfString ButtonLabels, MsgBoxResult ShieldButton, MsgBoxResult Default) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getopenfilename.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool GetOpenFileName(string Prompt, ref string FileName, string InitialDirectory, string Filter, string DefaultExtension) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getopenfilenamemulti.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool GetOpenFileNameMulti(string Prompt, ref TStrings FileNameList, string InitialDirectory, string Filter, string DefaultExtension) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getsavefilename.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool GetSaveFileName(string Prompt, ref string FileName, string InitialDirectory, string Filter, string DefaultExtension) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_browseforfolder.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool BrowseForFolder(string Prompt, ref string Directory, bool NewFolderButton) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_exitsetupmsgbox.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool ExitSetupMsgBox() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_selectdisk.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool SelectDisk(int DiskNumber, string AFilename, ref string Path) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_abort.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void Abort() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_raiseexception.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void RaiseException(string Msg) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getexceptionmessage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetExceptionMessage() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_showexceptionmessage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void ShowExceptionMessage() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_exec.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool Exec(string Filename, string Params, string WorkingDir, ShowWindow ShowCmd, TExecWait Wait, ref int ResultCode) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_execasoriginaluser.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool ExecAsOriginalUser(string Filename, string Params, string WorkingDir, ShowWindow ShowCmd, TExecWait Wait, ref int ResultCode) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_shellexec.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool ShellExec(string Verb, string Filename, string Params, string WorkingDir, ShowWindow ShowCmd, TExecWait Wait, ref int ErrorCode) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_shellexecasoriginaluser.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool ShellExecAsOriginalUser(string Verb, string Filename, string Params, string WorkingDir, ShowWindow ShowCmd, TExecWait Wait, ref int ErrorCode) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_extracttemporaryfile.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void ExtractTemporaryFile(string FileName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_extracttemporaryfiles.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public int ExtractTemporaryFiles(string Pattern) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_downloadtemporaryfilesize.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public Int64 DownloadTemporaryFile(string Url, string FileName, string RequiredSHA256OfFile, TOnDownloadProgress OnDownloadProgress) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_downloadtemporaryfilesize.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public Int64 DownloadTemporaryFileSize(string Url) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_renamefile.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RenameFile(string OldName, string NewName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_filecopy.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool FileCopy(string ExistingFile, string NewFile, bool FailIfExists) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_deletefile.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool DeleteFile(string FileName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_delaydeletefile.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void DelayDeleteFile(string Filename, int Tries) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_setntfscompression.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool SetNTFSCompression(string FileOrDir, bool Compress) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_loadstringfromfile.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool LoadStringFromFile(string FileName, ref AnsiString S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_loadstringsfromfile.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool LoadStringsFromFile(string FileName, ref AnsiString S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_savestringtofile.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool SaveStringToFile(string FileName, AnsiString S, bool Append) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_savestringstofile.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool SaveStringsToFile(string FileName, TArrayOfString S, bool Append) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="xxxxxxxxxxxxxxx">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool SaveStringsToUTF8File(string FileName, TArrayOfString S, bool Append) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createdir.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool CreateDir(string Dir) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_forcedirectories.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool ForceDirectories(string Dir) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_removedir.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RemoveDir(string Dir) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_deltree.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool DelTree(string Path, bool IsDir, bool DeleteFiles, bool DeleteSubdirsAlso) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createshelllink.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string CreateShellLink(string Filename, string Description, string ShortcutTo, string Parameters, string WorkingDir, string IconFilename, int IconIndex, ShowWindow ShowCmd) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_unpinshelllink.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool UnpinShellLink(string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_registerserver.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void RegisterServer(bool Is64Bit, string Filename, bool FailCriticalErrors) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_unregisterserver.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool UnregisterServer(bool Is64Bit, string Filename, bool FailCriticalErrors) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_registertypelibrary.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void RegisterTypeLibrary(bool Is64Bit, string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_unregistertypelibrary.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool UnregisterTypeLibrary(bool Is64Bit, string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="xxxxxxxxxxxxxxx">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void IncrementSharedCount(bool Is64Bit, string Filename, bool AlreadyExisted) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_incrementsharedcount.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool DecrementSharedCount(bool Is64Bit, string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_restartreplace.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void RestartReplace(string TempFile, string DestFile) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_unregisterfont.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void UnregisterFont(string FontName, string FontFilename, bool PerUserFont) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_modifypiffile.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool ModifyPifFile(string Filename, bool CloseOnExit) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_direxists.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool DirExists(string Name) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_fileexists.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool FileExists(string Name) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_fileordirexists.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool FileOrDirExists(string Name) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_filesize.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool FileSize(string Name, int Size) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_filesize64.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool FileSize64(string Name, Int64 Size) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getspaceondisk.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool GetSpaceOnDisk(string Path, bool InMegabytes, ref Cardinal Free, ref Cardinal Total) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getspaceondisk64.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool GetSpaceOnDisk64(string Path, ref Int64 Free, ref Int64 Total) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_filesearch.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string FileSearch(string Name, string DirList) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_findfirst.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool FindFirst(string FileName, ref TFindRec FindRec) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_findnext.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool FindNext(ref TFindRec FindRec) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_findclose.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void FindClose(ref TFindRec FindRec) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getcurrentdir.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetCurrentDir() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_setcurrentdir.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool SetCurrentDir(string Dir) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getwindir.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetWinDir() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getsystemdir.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetSystemDir() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getsyswow64dir.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetSysWow64Dir() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_gettempdir.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetTempDir() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getshellfolderbycsidl.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetShellFolderByCSIDL(int Folder, bool Create) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getshortname.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetShortName(string LongName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_generateuniquename.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GenerateUniqueName(string Path, string Extension) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_isprotectedsystemfile.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool IsProtectedSystemFile(string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getmd5offile.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetMD5OfFile(string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getsha1offile.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetSHA1OfFile(string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getsha256offile.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetSHA256OfFile(string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_enablefsredirection.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool EnableFsRedirection(bool Enable) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getversionnumbers.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool GetVersionNumbers(string Filename, ref Cardinal VersionMS, ref Cardinal VersionLS) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getversioncomponents.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool GetVersionComponents(string Filename, ref ushort Major, ref ushort Minor, ref ushort Revision, ref ushort Build) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getversionnumbersstring.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool GetVersionNumbersString(string Filename, ref string Version) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getpackedversion.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool GetPackedVersion(string Filename, ref Int64 Version) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_packversionnumbers.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public Int64 PackVersionNumbers(Cardinal VersionMS, Cardinal VersionLS) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_packversioncomponents.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public Int64 PackVersionComponents(ushort Major, ushort Minor, ushort Revision, ushort Build) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_comparepackedversion.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public int ComparePackedVersion(Int64 Version1, Int64 Version2) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_samepackedversion.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool SamePackedVersion(Int64 Version1, Int64 Version2) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="xxxxxxxxxxxxxxx">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void UnpackVersionNumbers(Int64 Version, ref Cardinal VersionMS, ref Cardinal VersionLS) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_unpackversioncomponents.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void UnpackVersionComponents(Int64 Version, ref ushort Major, ref ushort Minor, ref ushort Revision, ref ushort Build) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_versiontostr.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string VersionToStr(Int64 Version) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_inikeyexists.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool IniKeyExists(string Section, string Key, string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_isinisectionempty.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool IsIniSectionEmpty(string Section, string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getinibool.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool GetIniBool(string Section, string Key, string Default, string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getiniint.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public long GetIniInt(string Section, string Key, long Default, long Min, long Max, string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getinistring.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetIniString(string Section, string Key, string Default, string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_setinibool.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool SetIniBool(string Section, string Key, string Value, string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_setiniint.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool SetIniInt(string Section, string Key, long Value, string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_setinistring.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool SetIniString(string Section, string Key, string Value, string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_deleteinisection.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void DeleteIniSection(string Section, string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_deleteinientry.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void DeleteIniEntry(string Section, string Key, string Filename) => throw new NotImplementedException();

        /// <summary>
        /// No documentation
        /// </summary>
        [BuiltInSymbol]
        public double Sin(double e) => throw new NotImplementedException();

        /// <summary>
        /// No documentation
        /// </summary>
        [BuiltInSymbol]
        public double Cos(double e) => throw new NotImplementedException();

        /// <summary>
        /// No documentation
        /// </summary>
        [BuiltInSymbol]
        public double Sqrt(double e) => throw new NotImplementedException();

        /// <summary>
        /// No documentation
        /// </summary>
        [BuiltInSymbol]
        public long Round(double e) => throw new NotImplementedException();

        /// <summary>
        /// No documentation
        /// </summary>
        [BuiltInSymbol]
        public long Trunc(double e) => throw new NotImplementedException();

        /// <summary>
        /// No documentation
        /// </summary>
        [BuiltInSymbol]
        public double Int(double e) => throw new NotImplementedException();

        /// <summary>
        /// No documentation
        /// </summary>
        [BuiltInSymbol]
        public double Pi() => throw new NotImplementedException();

        /// <summary>
        /// No documentation
        /// </summary>
        [BuiltInSymbol]
        public double Abs(double e) => throw new NotImplementedException();

        /// <summary>
        /// No documentation
        /// </summary>
        [BuiltInSymbol]
        public string FloatToStr(double e) => throw new NotImplementedException();

        /// <summary>
        /// No documentation
        /// </summary>
        [BuiltInSymbol]
        public string Padl(string s, long i) => throw new NotImplementedException();

        /// <summary>
        /// No documentation
        /// </summary>
        [BuiltInSymbol]
        public string Padr(string s, long i) => throw new NotImplementedException();

        /// <summary>
        /// No documentation
        /// </summary>
        [BuiltInSymbol]
        public string Padz(string s, long i) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_regkeyexists.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegKeyExists(RegistryHive RootKey, string SubKeyName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_regvalueexists.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegValueExists(RegistryHive RootKey, string SubKeyName, string ValueName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_reggetsubkeynames.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegGetSubkeyNames(RegistryHive RootKey, string SubKeyName, ref TArrayOfString Names) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_reggetvaluenames.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegGetValueNames(RegistryHive RootKey, string SubKeyName, ref TArrayOfString Names) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_regquerystringvalue.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegQueryStringValue(RegistryHive RootKey, string SubKeyName, string ValueName, ref string ResultStr) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_regquerymultistringvalue.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegQueryMultiStringValue(RegistryHive RootKey, string SubKeyName, string ValueName, ref string ResultStr) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_regquerydwordvalue.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegQueryDWordValue(RegistryHive RootKey, string SubKeyName, string ValueName, ref Cardinal ResultDWord) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_regquerybinaryvalue.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegQueryBinaryValue(RegistryHive RootKey, string SubKeyName, string ValueName, ref AnsiString ResultStr) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_regwritestringvalue.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegWriteStringValue(RegistryHive RootKey, string SubKeyName, string ValueName, string Data) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_regwriteexpandstringvalue.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegWriteExpandStringValue(RegistryHive RootKey, string SubKeyName, string ValueName, string Data) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_regwritemultistringvalue.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegWriteMultiStringValue(RegistryHive RootKey, string SubKeyName, string ValueName, string Data) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_regwritedwordvalue.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegWriteDWordValue(RegistryHive RootKey, string SubKeyName, string ValueName, Cardinal Data) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_regwritebinaryvalue.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegWriteBinaryValue(RegistryHive RootKey, string SubKeyName, string ValueName, AnsiString Data) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_regdeletekeyincludingsubkeys.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegDeleteKeyIncludingSubkeys(RegistryHive RootKey, string SubkeyName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_regdeletekeyifempty.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegDeleteKeyIfEmpty(RegistryHive RootKey, string SubkeyName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_regdeletevalue.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegDeleteValue(RegistryHive RootKey, string SubKeyName, string ValueName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getcmdtail.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetCmdTail() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_paramcount.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public int ParamCount() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_paramstr.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string ParamStr(int Index) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_activelanguage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string ActiveLanguage() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_custommessage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string CustomMessage(string MsgName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_fmtmessage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string FmtMessage(string S, ArrayOf<string> args) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_setupmessage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string SetupMessage(TSetupMessageID ID) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_wizarddirvalue.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string WizardDirValue() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_wizardgroupvalue.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string WizardGroupValue() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_wizardnoicons.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool WizardNoIcons() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_wizardsetuptype.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string WizardSetupType(bool Description) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_wizardselectedcomponents.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string WizardSelectedComponents(bool Descriptions) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_wizardiscomponentselected.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool WizardIsComponentSelected(string Components) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_wizardselectcomponents.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void WizardSelectComponents(string Components) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_wizardselectedtasks.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string WizardSelectedTasks(bool Descriptions) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_wizardistaskselected.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool WizardIsTaskSelected(string Tasks) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_wizardselecttasks.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void WizardSelectTasks(string Tasks) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_wizardsilent.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool WizardSilent() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_isuninstaller.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool IsUninstaller() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_uninstallsilent.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool UninstallSilent() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_currentfilename.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string CurrentFilename() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_currentsourcefilename.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string CurrentSourceFilename() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_expandconstant.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string ExpandConstant(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_expandconstantex.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string ExpandConstantEx(string S, string CustomConst, string CustomValue) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getpreviousdata.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetPreviousData(string ValueName, string DefaultValueData) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_setpreviousdata.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool SetPreviousData(int PreviousDataKey, string ValueName, string ValueData) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_terminated.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool Terminated() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_registerextracloseapplicationsresource.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RegisterExtraCloseApplicationsResource(bool DisableFsRedir, string AFilename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_rmsessionstarted.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool RmSessionStarted() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getwizardform.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TWizardForm GetWizardForm() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getuninstallprogressform.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TUninstallProgressForm GetUninstallProgressForm() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getmainform.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TMainForm GetMainForm() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getuninstallprogressform.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TUninstallProgressForm UninstallProgressForm => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getwizardform.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TWizardForm WizardForm => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getmainform.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TMainForm MainForm => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_chr.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public char Chr(byte B) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_ord.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public byte Ord(OrdArgument value) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_copy.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string Copy(string S, int Index, int Count) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_length.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public long Length(string s) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_lowercase.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string Lowercase(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_uppercase.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string Uppercase(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_ansilowercase.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string AnsiLowercase(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_ansiuppercase.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string AnsiUppercase(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_stringofchar.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string StringOfChar(char c, long I) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_delete.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void Delete(string S, int Index, int Count) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_insert.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void Insert(string Source, string Dest, int Index) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_stringchange.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public int StringChange(string S, string FromStr, string ToStr) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_stringchangeex.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public int StringChangeEx(string S, string FromStr, string ToStr, bool SupportDBCS) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_pos.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public int Pos(string SubStr, string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_addquotes.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string AddQuotes(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_removequotes.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string RemoveQuotes(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_convertpercentstr.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool ConvertPercentStr(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_comparetext.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public int CompareText(string S1, string S2) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_comparestr.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public int CompareStr(string S1, string S2) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_sametext.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool SameText(string S1, string S2) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_samestr.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool SameStr(string S1, string S2) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_iswildcard.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool IsWildcard(string Pattern) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_wildcardmatch.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool WildcardMatch(string Text, string Pattern) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_format.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string Format(string Format, params object[] args) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_trim.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string Trim(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_trimleft.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string TrimLeft(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_trimright.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string TrimRight(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_strtointdef.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public long StrToIntDef(string s, long def) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_strtoint.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public long StrToInt(string s) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_strtoint64def.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public Int64 StrToInt64Def(string s, Int64 def) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_strtoint64.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public Int64 StrToInt64(string s) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_strtofloat.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public decimal StrToFloat(string s) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_inttostr.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string IntToStr(Int64 i) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_floattostr.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string FloatToStr(decimal e) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_charlength.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public int CharLength(string S, int Index) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_addbackslash.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string AddBackslash(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_removebackslashunlessroot.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string RemoveBackslashUnlessRoot(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_removebackslash.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string RemoveBackslash(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_addperiod.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string AddPeriod(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_changefileext.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string ChangeFileExt(string FileName, string Extension) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_extractfileext.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string ExtractFileExt(string FileName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_extractfiledir.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string ExtractFileDir(string FileName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_extractfilepath.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string ExtractFilePath(string FileName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_extractfilename.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string ExtractFileName(string FileName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_extractfiledrive.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string ExtractFileDrive(string FileName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_extractrelativepath.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string ExtractRelativePath(string BaseName, string DestName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_expandfilename.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string ExpandFileName(string FileName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_expanduncfilename.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string ExpandUNCFileName(string FileName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getdatetimestring.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetDateTimeString(string DateTimeFormat, char DateSeparator, char TimeSeparator) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_setlength.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void SetLength(string S, long L) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_chartooembuff.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void CharToOemBuff(AnsiString S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_oemtocharbuff.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void OemToCharBuff(AnsiString S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getmd5ofstring.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetMD5OfString(AnsiString S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getmd5ofunicodestring.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetMD5OfUnicodeString(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getsha1ofstring.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetSHA1OfString(AnsiString S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getsha1ofunicodestring.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetSHA1OfUnicodeString(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getsha1ofstring.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetSHA256OfString(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getsha1ofunicodestring.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetSHA256OfUnicodeString(string S) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_syserrormessage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string SysErrorMessage(int ErrorCode) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_minimizepathname.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string MinimizePathName(string Filename, TFont Font, int MaxLen) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_isadmin.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool IsAdmin() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_isadmininstallmode.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool IsAdminInstallMode() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getwindowsversion.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public Cardinal GetWindowsVersion() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getwindowsversionex.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void GetWindowsVersionEx(ref TWindowsVersion Version) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getwindowsversionstring.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetWindowsVersionString() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_iswin64.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool IsWin64() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_is64bitinstallmode.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool Is64BitInstallMode() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_processorarchitecture.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TSetupProcessorArchitecture ProcessorArchitecture() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_isx86.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool IsX86() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_isx64.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool IsX64() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_isx64.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool IsIA64() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_isarm64.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool IsARM64() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_installonthisversion.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool InstallOnThisVersion(string MinVersion, string OnlyBelowVersion) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_isdotnetinstalled.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool IsDotNetInstalled(TDotNetVersion MinVersion, Cardinal MinServicePack) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getenv.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetEnv(string EnvVar) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getusernamestring.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetUserNameString() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getcomputernamestring.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string GetComputerNameString() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_getuilanguage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public int GetUILanguage() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_fontexists.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool FontExists(string FaceName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_findwindowbyclassname.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public HWND FindWindowByClassName(string ClassName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_findwindowbywindowname.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public HWND FindWindowByWindowName(string WindowName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_sendmessage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public long SendMessage(HWND Wnd, uint Msg, long LParam) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_postmessage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool PostMessage(HWND Wnd, uint Msg, long LParam) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_sendnotifymessage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool SendNotifyMessage(HWND Wnd, uint Msg, long LParam) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_registerwindowmessage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public long RegisterWindowMessage(string Name) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_sendbroadcastmessage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public long SendBroadcastMessage(long Msg, long WParam, long LParam) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_postbroadcastmessage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool PostBroadcastMessage(long Msg, long WParam, long LParam) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_sendbroadcastnotifymessage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool SendBroadcastNotifyMessage(long Msg, long WParam, long LParam) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createmutex.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void CreateMutex(string Name) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_checkformutexes.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool CheckForMutexes(string Mutexes) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_makependingfilerenameoperationschecksum.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public string MakePendingFileRenameOperationsChecksum() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createcallback.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public uint CreateCallback([Callback] string Method) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_unloaddll.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void UnloadDLL(string Filename) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_dllgetlasterror.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public long DLLGetLastError() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_null.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public dynamic Null => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_unassigned.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public dynamic Unassigned => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_varisempty.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool VarIsEmpty(dynamic V) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_varisclear.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool VarIsClear(dynamic V) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_varisnull.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool VarIsNull(dynamic V) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_vartype.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public bool VarType(dynamic V) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createinputquerypage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TInputQueryWizardPage CreateInputQueryPage(int AfterID, string ACaption, string ADescription, string ASubCaption) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createinputoptionpage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TInputOptionWizardPage CreateInputOptionPage(int AfterID, string ACaption, string ADescription, string ASubCaption, bool Exclusive, bool ListBox) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createinputdirpage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TInputDirWizardPage CreateInputDirPage(int AfterID, string ACaption, string ADescription, string ASubCaption, bool AAppendDir, string ANewFolderName) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createinputfilepage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TInputFileWizardPage CreateInputFilePage(int AfterID, string ACaption, string ADescription, string ASubCaption) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createoutputmsgpage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TOutputMsgWizardPage CreateOutputMsgPage(int AfterID, string ACaption, string ADescription, string AMsg) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createoutputmsgmemopage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TOutputMsgMemoWizardPage CreateOutputMsgMemoPage(int AfterID, string ACaption, string ADescription, string ASubCaption, AnsiString AMsg) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createoutputprogresspage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TOutputProgressWizardPage CreateOutputProgressPage(string ACaption, string ADescription) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createdownloadpage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TDownloadWizardPage CreateDownloadPage(string ACaption, string ADescription, TOnDownloadProgress OnDownloadProgress) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createcustompage.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TWizardPage CreateCustomPage(int AfterID, string ACaption, string ADescription) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_createcustomform.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TSetupForm CreateCustomForm() => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_pagefromid.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public TWizardPage PageFromID(int ID) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_pageindexfromid.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public int PageIndexFromID(int ID) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_scalex.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public int ScaleX(int X) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_scaley.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public int ScaleY(int Y) => throw new NotImplementedException();

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_isxfunc_log.htm">Documentation</a>
        /// </summary>
        [BuiltInSymbol]
        public void Log(string S) => throw new NotImplementedException();
    }
}
