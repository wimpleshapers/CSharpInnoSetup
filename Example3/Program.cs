
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive;
using System;
using System.IO;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Example.Example3
{
    class Program
    {
        static int Main(string[] args)
        {
            return ExampleConsole.Run(() => new ExampleInstallation(new DirectoryInfo(args[0])), new FileInfo(args[1]));
        }
    }

    internal class ExampleInstallation : Installation
    {
        private readonly DirectoryInfo _source;

        public ExampleInstallation(DirectoryInfo source)
        {
            _source = source;
        }

        //AppName=My Program
        //AppVersion=1.5
        //WizardStyle=modern
        //DefaultDirName={autopf}\My Program
        //DefaultGroupName=My Program
        //UninstallDisplayIcon={app}\MyProg.exe
        //Compression=lzma2
        //SolidCompression=yes
        //OutputDir=userdocs:Inno Setup Examples Output
        //ChangesAssociations=yes
        //UserInfoPage=yes
        //PrivilegesRequiredOverridesAllowed=dialog
        public override string AppName => "My Program";
        public override string AppVersion => "1.5";
        public override DirectoryInfo DefaultDirName => new DirectoryInfo($"{__autopf}\\My Program");
        public override string DefaultGroupName => "My Program";
        public override IconFile UninstallDisplayIcon => new IconFile(new FileInfo($"{__app}\\MyProg.exe"));
        public override Compression Compression => Compression.Lzma2;
        public override bool SolidCompression => true;
        public override OutputDirectory OutputDir => OutputDirectory.UserDocs("Inno Setup Examples Output");
        public override Expression<Func<bool>> ChangesAssociations => () => true;
        public override bool UserInfoPage => true;
        public override WizardStyle WizardStyle => WizardStyle.Modern;
        public override PrivilegesRequiredOverride PrivilegesRequiredOverridesAllowed => PrivilegesRequiredOverride.Dialog;

        public override Action<IParameterizedEntriesBuilder> ParameterizedEntriesBuilderHandler => builder =>
        {
            var languageDependentBuilder = builder.LanguagesBuilder.AddLanguages(builder => new { });
            var componentsBuilder = languageDependentBuilder.Add((builder, languages) => new { }, languages => new { }, languages => new { });
            var tasksBuilder = componentsBuilder.AddComponents((languages, types, customMessages, messages) => new { });
            var contentBuilder = tasksBuilder.AddTasks((languages, types, customMessages, messages, components) => new { });

            contentBuilder.AddFiles((builder, languages, types, customMessage, messages, components, tasks) =>
            {
                return new[]
                {
                    //Source: "MyProg.exe"; DestDir: "{app}"
                    //Source: "MyProg.chm"; DestDir: "{app}"
                    //Source: "Readme.txt"; DestDir: "{app}"; Flags: isreadme
                    builder().Source(_source, "MyProg.exe").Destination(__app).Build(),
                    builder().Source(_source, "MyProg.chm").Destination(__app).Build(),
                    builder().Source(_source, "Readme.txt").Destination(__app).Flags(FileFlags.IsReadme).Build()
                };
            });

            contentBuilder.AddIcons((builder, languages, types, customMessage, messages, components, tasks) =>
            {
                return new[]
                {
                    //Name: "{group}\My Program"; Filename: "{app}\MyProg.exe"
                    builder().Name($"{__group}\\My Program").FileName($"{__app}\\MyProg.exe").Build()
                };
            });

            contentBuilder.AddRegistryEntries((builder, languages, types, customMessage, messages, components, tasks) =>
            {
                //Root: HKA; Subkey: "Software\My Company"; Flags: uninsdeletekeyifempty
                //Root: HKA; Subkey: "Software\My Company\My Program"; Flags: uninsdeletekey
                //Root: HKA; Subkey: "Software\My Company\My Program\Settings"; ValueType: string; ValueName: "Language"; ValueData: "{language}"
                //Root: HKA; Subkey: "Software\Classes\.myp"; ValueType: string; ValueName: ""; ValueData: "MyProgramFile.myp"; Flags: uninsdeletevalue
                //Root: HKA; Subkey: "Software\Classes\.myp\OpenWithProgids"; ValueType: string; ValueName: "MyProgramFile.myp"; ValueData: ""; Flags: uninsdeletevalue
                //Root: HKA; Subkey: "Software\Classes\MyProgramFile.myp"; ValueType: string; ValueName: ""; ValueData: "My Program File"; Flags: uninsdeletekey
                //Root: HKA; Subkey: "Software\Classes\MyProgramFile.myp\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\MyProg.exe,0"
                //Root: HKA; Subkey: "Software\Classes\MyProgramFile.myp\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\MyProg.exe"" ""%1"""
                //Root: HKLM; Subkey: "Software\My Company"; Flags: uninsdeletekeyifempty; Check: IsAdminInstallMode
                //Root: HKLM; Subkey: "Software\My Company\My Program"; Flags: uninsdeletekey; Check: IsAdminInstallMode
                //Root: HKLM; Subkey: "Software\My Company\My Program\Settings"; ValueType: string; ValueName: "InstallPath"; ValueData: "{app}"; Check: IsAdminInstallMode
                //Root: HKCU; Subkey: "Software\My Company\My Program\Settings"; ValueType: string; ValueName: "UserName"; ValueData: "{userinfoname}"; Check: not IsAdminInstallMode
                //Root: HKCU; Subkey: "Software\My Company\My Program\Settings"; ValueType: string; ValueName: "UserOrganization"; ValueData: "{userinfoorg}"; Check: not IsAdminInstallMode
                return new[]
                {
                    builder().Subkey(@"Software\My Company").Flags(RegistryFlags.UninstallDeleteKeyIfEmpty).Build(),
                    builder().Subkey(@"Software\My Company\My Program").Flags(RegistryFlags.UninstallDeleteKey).Build(),
                    builder().Subkey(@"Software\My Company\My Program\Settings").ValueType(RegistryDataType.String).ValueName("Language").ValueData(__language).Build(),
                    builder().Subkey(@"Software\Classes\.myp").ValueType(RegistryDataType.String).ValueName("").ValueData("MyProgramFile.myp").Flags(RegistryFlags.UninstallDeleteValue).Build(),
                    builder().Subkey(@"Software\Classes\.myp\OpenWithProgids").ValueType(RegistryDataType.String).ValueName("MyProgramFile.myp").ValueData("").Flags(RegistryFlags.UninstallDeleteValue).Build(),
                    builder().Subkey(@"Software\Classes\MyProgramFile.myp").ValueType(RegistryDataType.String).ValueName("").ValueData("My Program File").Flags(RegistryFlags.UninstallDeleteKey).Build(),
                    builder().Subkey(@"Software\Classes\MyProgramFile.myp\DefaultIcon").ValueType(RegistryDataType.String).ValueName("").ValueData($"{__app}\\MyProg.exe,0").Build(),
                    builder().Subkey(@"Software\Classes\MyProgramFile.myp\shell\open\command").ValueType(RegistryDataType.String).ValueName("").ValueData($"\"{__app}\\MyProg.exe\" \"%1\"").Build(),
                    builder().Subkey(@"Software\My Company").Flags(RegistryFlags.UninstallDeleteKeyIfEmpty).Check(e => IsAdminInstallMode()).Build(),
                    builder().Subkey(@"Software\My Company\My Program").Flags(RegistryFlags.UninstallDeleteKey).Check(e => IsAdminInstallMode()).Build(),
                    builder().Subkey(@"Software\My Company\My Program\Settings").ValueType(RegistryDataType.String).ValueName("InstallPath").ValueData(__app).Check(e => IsAdminInstallMode()).Build(),
                    builder().Subkey(@"Software\My Company\My Program\Settings").ValueType(RegistryDataType.String).ValueName("UserName").ValueData(__userinfoname).Check(e => !IsAdminInstallMode()).Build(),
                    builder().Subkey(@"Software\My Company\My Program\Settings").ValueType(RegistryDataType.String).ValueName("UserOrganization").ValueData(__userinfoorg).Check(e => !IsAdminInstallMode()).Build()
                };
            });
        };

        public override bool ShouldSkipPage(int pageId)
        {
            // User specific pages should be skipped in administrative install mode
            return IsAdminInstallMode() && (pageId == PageID.UserInfo);
        }
    }
}
