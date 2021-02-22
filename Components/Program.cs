
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive;
using System;
using System.IO;

namespace CodingMuscles.CSharpInnoSetup.Example.Components
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
        //OutputDir=userdocs:Inno Setup Examples Output
        public override string AppName => "My Program";
        public override string AppVersion => "1.5";
        public override WizardStyle WizardStyle => WizardStyle.Modern;
        public override DirectoryInfo DefaultDirName => new DirectoryInfo($"{__autopf}\\My Program");
        public override string DefaultGroupName => "My Program";
        public override IconFile UninstallDisplayIcon => new IconFile(new FileInfo($"{__app}\\MyProg.exe"));
        public override OutputDirectory OutputDir => OutputDirectory.UserDocs("Inno Setup Examples Output");

        public override Action<IParameterizedEntriesBuilder> ParameterizedEntriesBuilderHandler => builder =>
        {
            var languageDependentBuilder = builder.LanguagesBuilder.AddLanguages(builder => new { });
            
            var componentsBuilder = languageDependentBuilder.Add((builder, languages) => 
                new 
                {
                    //Name: "full"; Description: "Full installation"
                    //Name: "compact"; Description: "Compact installation"
                    //Name: "custom"; Description: "Custom installation"; Flags: iscustom
                    Full = builder().Description("Full installation").Build(),
                    Compact = builder().Description("Compact installation").Build(),
                    Custom = builder().Description("Custom installation").Flags(SetupTypeFlags.IsCustom).Build()
                }, languages => new { }, languages => new { });

            var tasksBuilder = componentsBuilder.AddComponents((languages, types, customMessages, messages) =>
                new
                {
                    //Name: "program"; Description: "Program Files"; Types: full compact custom; Flags: fixed
                    //Name: "help"; Description: "Help File"; Types: full
                    //Name: "readme"; Description: "Readme File"; Types: full
                    //Name: "readme\en"; Description: "English"; Flags: exclusive
                    //Name: "readme\de"; Description: "German"; Flags: exclusive
                    Program = ComponentFactory.CreateLeaf().Description("Program Files").Types(() => new[] { types.Full, types.Compact, types.Custom }).Flags(ComponentFlags.Fixed).Build(),
                    Help = ComponentFactory.CreateLeaf().Description("Help File").Types(() => types.Full).Build(),
                    Readme = ComponentFactory.CreateParent(
                        builder => builder.Description("Readme File").Types(() => types.Full).Build(),
                        new
                        {
                            English = ComponentFactory.CreateLeaf().Description("English").Flags(ComponentFlags.Exclusive).Build(),
                            German = ComponentFactory.CreateLeaf().Description("German").Flags(ComponentFlags.Exclusive).Build()
                        })
                });
            
            var contentBuilder = tasksBuilder.AddTasks((languages, types, customMessages, messages, components) => new { });

            contentBuilder.AddFiles((builder, languages, types, customMessage, messages, components, tasks) =>
            {
                return new[]
                {
                    //Source: "MyProg.exe"; DestDir: "{app}";
                    //Source: "MyProg.chm"; DestDir: "{app}";
                    //Source: "Readme.txt"; DestDir: "{app}"; Flags: isreadme;
                    //Source: "Readme-German.txt"; DestName: "Liesmich.txt"; DestDir: "{app}"; Components: readme\de; Flags: isreadme
                    builder().Source(_source, "MyProg.exe").Destination(__app).Build(),
                    builder().Source(_source, "MyProg.chm").Destination(__app).Build(),
                    builder().Source(_source, "Readme.txt").Destination(__app).Flags(FileFlags.IsReadme).Build(),
                    builder().Source(_source, "Readme-German.txt").DestinationName("Liesmich.txt").Destination(__app)
                        .Components(() => components.Readme.Children.German).Flags(FileFlags.IsReadme).Build()
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
