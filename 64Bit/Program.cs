
using CodingMuscles.CSharpInnoSetup.Example;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive;
using System;
using System.IO;

namespace CodingMuscles.CSharpInnoSetup.Example64Bit
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
        //ArchitecturesAllowed=x64
        //ArchitecturesInstallIn64BitMode=x64
        public override string AppName => "My Program";
        public override string AppVersion => "1.5";
        public override WizardStyle WizardStyle => WizardStyle.Modern;
        public override DirectoryInfo DefaultDirName => new DirectoryInfo($"{__autopf}\\My Program");
        public override string DefaultGroupName => "My Program";
        public override IconFile UninstallDisplayIcon => new IconFile(new FileInfo($"{__app}\\MyProg.exe"));
        public override Compression Compression => Compression.Lzma2;
        public override bool SolidCompression => true;
        public override OutputDirectory OutputDir => OutputDirectory.UserDocs("Inno Setup Examples Output");
        public override Architecture ArchitecturesAllowed => Architecture.X64;
        public override InstallMode64Bit ArchitecturesInstallIn64BitMode => InstallMode64Bit.X64;

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
                    //Source: "MyProg-x64.exe"; DestDir: "{app}"; DestName: "MyProg.exe"
                    //Source: "MyProg.chm"; DestDir: "{app}"
                    //Source: "Readme.txt"; DestDir: "{app}"; Flags: isreadme
                    builder().Source(_source, "MyProg-x64.exe").Destination(__app).DestinationName("MyProg.exe").Build(),
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
        };
    }
}
