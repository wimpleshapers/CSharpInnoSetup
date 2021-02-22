
using CodingMuscles.CSharpInnoSetup.Converter;
using CodingMuscles.CSharpInnoSetup.Script;
using CodingMuscles.CSharpInnoSetup.Script.Constructs;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive;
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup
{
    public partial class Installation
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_aslrcompatible.htm">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual bool ASLRCompatible { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_compression.htm">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual Compression Compression { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_compressionthreads.htm">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual CompressionThreads CompressionThreads { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_depcompatible.htm">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool DEPCompatible { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_diskclustersize">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual uint DiskClusterSize { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_diskslicesize">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual DiskSliceSize DiskSliceSize { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_diskspanning">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool DiskSpanning { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_encryption">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool Encryption { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_internalcompresslevel">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<CompressionLevel>))]
        [SetupDirective]
        public virtual CompressionLevel InternalCompressLevel { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_lzmaalgorithm">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<LZMAAlgorithm>))]
        [SetupDirective]
        public virtual LZMAAlgorithm LZMAAlgorithm { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_lzmablocksize">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual uint LZMABlockSize { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_lzmadictionarysize">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual uint LZMADictionarySize { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_lzmamatchfinder">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<LZMAMatchFinder>))]
        [SetupDirective]
        public virtual LZMAMatchFinder LZMAMatchFinder { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_lzmanumblockthreads">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual uint LZMANumBlockThreads { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_lzmanumfastbytes">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual uint LZMANumFastBytes { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_lzmauseseparateprocess">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<X86Triad>))]
        [SetupDirective]
        public virtual X86Triad LZMAUseSeparateProcess { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_mergeduplicatefiles">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool MergeDuplicateFiles { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_missingrunonceidswarning">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool MissingRunOnceIdsWarning { get; }

        ///// <summary>
        ///// Probably can't be used, since this project would fail without the output
        ///// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_output">Documentation</a>
        ///// </summary>
        //bool Output { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_outputbasefilename">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual FileInfo OutputBaseFilename { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_outputdir.htm">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual OutputDirectory OutputDir { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_outputmanifestfile">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual FileInfo OutputManifestFile { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_reservebytes">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual uint ReserveBytes { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_signeduninstaller">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool SignedUninstaller { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_signeduninstallerdir">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual DirectoryInfo SignedUninstallerDir { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_signtool">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(SignToolCommandToStringConverter))]
        [SetupDirective]
        public virtual SignToolCommand SignTool { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_signtoolminimumtimebetween">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(TimeSpanToMillisecondsStringConverter))]
        [SetupDirective]
        public virtual TimeSpan SignToolMinimumTimeBetween { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_signtoolretrycount">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual uint SignToolRetryCount { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_signtoolretrydelay">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(TimeSpanToMillisecondsStringConverter))]
        [SetupDirective]
        public virtual TimeSpan SignToolRetryDelay { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_signtoolrunminimized">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool SignToolRunMinimized { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_slicesperdisk">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual uint SlicesPerDisk { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_solidcompression">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool SolidCompression { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_sourcedir">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual DirectoryInfo SourceDir { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_terminalservicesaware">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool TerminalServicesAware { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_useduserareaswarning">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool UsedUserAreasWarning { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_usesetupldr">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool UseSetupLdr { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_versioninfocompany">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string VersionInfoCompany { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_versioninfocopyright">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string VersionInfoCopyright { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_versioninfodescription">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string VersionInfoDescription { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_versioninfooriginalfilename">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual FileInfo VersionInfoOriginalFileName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_versioninfoproductname">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string VersionInfoProductName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_versioninfoproducttextversion">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string VersionInfoProductTextVersion { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_versioninfoproductversion">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual Version VersionInfoProductVersion { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_versioninfotextversion">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string VersionInfoTextVersion { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_versioninfoversion">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual Version VersionInfoVersion { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_allowcancelduringinstall">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool AllowCancelDuringInstall { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_allownetworkdrive">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool AllowNetworkDrive { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_allownoicons">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool AllowNoIcons { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_allowrootdirectory">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool AllowRootDirectory { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_allowuncpath">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool AllowUNCPath { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_alwaysrestart">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool AlwaysRestart { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_alwaysshowcomponentslist">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool AlwaysShowComponentsList { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_alwaysshowdironreadypage">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool AlwaysShowDirOnReadyPage { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_alwaysshowgrouponreadypage">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool AlwaysShowGroupOnReadyPage { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_alwaysusepersonalgroup">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool AlwaysUsePersonalGroup { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_appenddefaultdirname">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool AppendDefaultDirName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_appenddefaultgroupname">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool AppendDefaultGroupName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_appcomments">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string AppComments { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_appcontact">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string AppContact { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_appid">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string AppId { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_appmodifypath">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string AppModifyPath { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_appmutex">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string AppMutex { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_appname">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string AppName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_apppublisher">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string AppPublisher { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_apppublisherurl">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual Uri AppPublisherURL { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_appreadmefile">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string AppReadmeFile { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_appsupportphone">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string AppSupportPhone { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_appsupporturl">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual Uri AppSupportURL { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_appupdatesurl">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual Uri AppUpdatesURL { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_appvername">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string AppVerName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_appversion">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string AppVersion { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_architecturesallowed">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<Architecture>))]
        [SetupDirective]
        public virtual Architecture ArchitecturesAllowed { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_architecturesinstallin64bitmode">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<InstallMode64Bit>))]
        [SetupDirective]
        public virtual InstallMode64Bit ArchitecturesInstallIn64BitMode { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_changesassociations">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(DirectiveMethodCallExpressionToStringConverter<Func<bool>>))]
        [SetupDirective]
        public virtual Expression<Func<bool>> ChangesAssociations { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_changesenvironment">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(DirectiveMethodCallExpressionToStringConverter<Func<bool>>))]
        [SetupDirective]
        public virtual Expression<Func<bool>> ChangesEnvironment { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_closeapplications">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<ForceTriad>))]
        [SetupDirective]
        public virtual ForceTriad CloseApplications { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_closeapplicationsfilter">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumerableToCommaSeparatedStringConverter))]
        [SetupDirective]
        public virtual string[] CloseApplicationsFilter { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_createappdir">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool CreateAppDir { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_createuninstallregkey">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(DirectiveMethodCallExpressionToStringConverter<Func<bool>>))]
        [SetupDirective]
        public virtual Expression<Func<bool>> CreateUninstallRegKey { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_defaultdialogfontname">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string DefaultDialogFontName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_defaultdirname">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual DirectoryInfo DefaultDirName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_defaultgroupname">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string DefaultGroupName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_defaultuserinfoname">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string DefaultUserInfoName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_defaultuserinfoorg">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string DefaultUserInfoOrg { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_defaultuserinfoserial">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string DefaultUserInfoSerial { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_direxistswarning">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<AutoTriad>))]
        [SetupDirective]
        public virtual AutoTriad DirExistsWarning { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_disabledirpage">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<AutoTriad>))]
        [SetupDirective]
        public virtual AutoTriad DisableDirPage { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_disablefinishedpage">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool DisableFinishedPage { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_disableprogramgrouppage">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<AutoTriad>))]
        [SetupDirective]
        public virtual AutoTriad DisableProgramGroupPage { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_disablereadymemo">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool DisableReadyMemo { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_disablereadypage">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool DisableReadyPage { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_disablestartupprompt">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool DisableStartupPrompt { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_disablewelcomepage">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool DisableWelcomePage { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_enabledirdoesntexistwarning">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool EnableDirDoesntExistWarning { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_extradiskspacerequired">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual ulong ExtraDiskSpaceRequired { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_infoafterfile">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual FileInfo InfoAfterFile { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_infobeforefile">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual FileInfo InfoBeforeFile { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_languagedetectionmethod">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<LanguageDetectionMethod>))]
        [SetupDirective]
        public virtual LanguageDetectionMethod LanguageDetectionMethod { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_licensefile">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual FileInfo LicenseFile { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_minversion">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual WindowsVersion MinVersion { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_onlybelowversion">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual WindowsVersion OnlyBelowVersion { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_password">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string Password { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_privilegesrequired">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<PrivilegesRequired>))]
        [SetupDirective]
        public virtual PrivilegesRequired PrivilegesRequired { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_privilegesrequiredoverridesallowed">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<PrivilegesRequiredOverride>))]
        [SetupDirective]
        public virtual PrivilegesRequiredOverride PrivilegesRequiredOverridesAllowed { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_restartapplications">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool RestartApplications { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_restartifneededbyrun">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool RestartIfNeededByRun { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_setuplogging">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool SetupLogging { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_setupmutex">Documentation</a>
        /// </summary>
        [Alias("SetupMutex")]
        [TypeConverter(typeof(EnumerableToCommaSeparatedStringConverter))]
        [SetupDirective]
        public virtual string[] SetupMutexes { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_showlanguagedialog">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<AutoTriad>))]
        [SetupDirective]
        public virtual AutoTriad ShowLanguageDialog { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_timestamprounding">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(TimeSpanToSecondsStringConverter))]
        [SetupDirective]
        public virtual TimeSpan TimeStampRounding { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_timestampsinutc">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool TimeStampsInUTC { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_touchdate">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual Timestamp TouchDate { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_touchtime">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual Timestamp TouchTime { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_uninstallable">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(DirectiveMethodCallExpressionToStringConverter<Func<bool>>))]
        [SetupDirective]
        public virtual Expression<Func<bool>> Uninstallable { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_uninstalldisplayicon">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual IconFile UninstallDisplayIcon { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_uninstalldisplayname">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string UninstallDisplayName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_uninstalldisplaysize">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual ulong UninstallDisplaySize { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_uninstallfilesdir">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual DirectoryInfo UninstallFilesDir { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_uninstalllogmode">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<UninstallLogMode>))]
        [SetupDirective]
        public virtual UninstallLogMode UninstallLogMode { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_uninstallrestartcomputer">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool UninstallRestartComputer { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_updateuninstalllogappname">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool UpdateUninstallLogAppName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_usepreviousappdir">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool UsePreviousAppDir { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_usepreviousgroup">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool UsePreviousGroup { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_usepreviouslanguage">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool UsePreviousLanguage { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_usepreviousprivileges">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool UsePreviousPrivigeles { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_useprevioussetuptype">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool UsePreviousSetupType { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_useprevioustasks">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool UsePreviousTasks { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_useprevioususerinfo">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool UsePreviousUserInfo { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_userinfopage">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool UserInfoPage { get; }

        //// Cosmetic: These directives only affect the appearance of the Setup program.
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_appcopyright">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual string AppCopyright { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_backcolor">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual Color BackColor { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_backcolor">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual Color BackColor2 { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_backcolordirection">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<BackColorDirection>))]
        [SetupDirective]
        public virtual BackColorDirection BackColorDirection { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_backsolid">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool BackSolid { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_flatcomponentslist">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool FlatComponentsList { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_setupiconfile">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual FileInfo SetupIconFile { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_showcomponentsizes">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool ShowComponentSizes { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_showtaskstreelines">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool ShowTasksTreeLines { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_windowshowcaption">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool WindowShowCaption { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_windowstartmaximized">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool WindowStartMaximized { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_windowresizable">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool WindowResizable { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_windowvisible">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool WindowVisible { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardimagealphaformat">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<WizardImageAlphaFormat>))]
        [SetupDirective]
        public virtual WizardImageAlphaFormat WizardImageAlphaFormat { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardimagefile">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual SourcedFile WizardImageFile { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardimagestretch">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool WizardImageStretch { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardresizable">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [SetupDirective]
        public virtual bool WizardResizable { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardsizepercent">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual Size WizardSizePercent { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardsmallimagefile">Documentation</a>
        /// </summary>
        [SetupDirective]
        public virtual SourcedFile WizardSmallImageFile { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_wizardstyle">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<WizardStyle>))]
        [SetupDirective]
        public virtual WizardStyle WizardStyle { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=langoptionssection">Documentation</a>
        /// </summary>
        [Alias("LanguageName")]
        [AmbiguousProperty("LanguageCodePage", typeof(CultureInfoToLcidStringConverter))]
        [AmbiguousProperty("RightToLeft", typeof(CultureInfoToRightToLeftStringConverter))]
        [LanguageDirective]
        public virtual CultureInfo Locale { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=langoptionssection">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(BoolToStringConverter))]
        [LanguageDirective]
        public virtual bool RightToLeft { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=langoptionssection">Documentation</a>
        /// </summary>
        [LanguageDirective]
        public virtual string DialogFontName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=langoptionssection">Documentation</a>
        /// </summary>
        [LanguageDirective]
        public virtual int DialogFontSize { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=langoptionssection">Documentation</a>
        /// </summary>
        [LanguageDirective]
        public virtual string WelcomeFontName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=langoptionssection">Documentation</a>
        /// </summary>
        [LanguageDirective]
        public virtual int WelcomeFontSize { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=langoptionssection">Documentation</a>
        /// </summary>
        [LanguageDirective]
        public virtual string TitleFontName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=langoptionssection">Documentation</a>
        /// </summary>
        [LanguageDirective]
        public virtual int TitleFontSize { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=langoptionssection">Documentation</a>
        /// </summary>
        [LanguageDirective]
        public virtual string CopyrightFontName { get; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=langoptionssection">Documentation</a>
        /// </summary>
        [LanguageDirective]
        public virtual int CopyrightFontSize { get; }
    }
}
