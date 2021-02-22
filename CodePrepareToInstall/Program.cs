
using CodingMuscles.CSharpInnoSetup;
using CodingMuscles.CSharpInnoSetup.Example;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive;
using System;
using System.IO;

namespace CodePrepareToInstall
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
        // Customize the following to your own name.
        private readonly string RunOnceName = "My Program Setup restart";
        private readonly string QuitMessageReboot = "The installation of a prerequisite program was not completed. You will need to restart your computer to complete that installation.\r\rAfter restarting your computer, Setup will continue next time an administrator logs in.";
        private readonly string QuitMessageError = "Error. Cannot continue.";
        [CommandLineParameter("restart")]
        private bool Restarted = false;

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
            var componentsBuilder = languageDependentBuilder.Add((builder, languages) => new { }, languages => new { }, languages => new { });
            var tasksBuilder = componentsBuilder.AddComponents((languages, types, customMessages, messages) => new { });
            var contentBuilder = tasksBuilder.AddTasks((languages, types, customMessages, messages, components) => new { });

            contentBuilder.AddFiles((builder, languages, types, customMessage, messages, components, tasks) =>
            {
                return new[]
                {
                    //Source: "MyProg.exe"; DestDir: "{app}";
                    //Source: "MyProg.chm"; DestDir: "{app}";
                    //Source: "Readme.txt"; DestDir: "{app}"; Flags: isreadme;
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
        };

        //function InitializeSetup(): Boolean;
        //begin
        //    Restarted := ExpandConstant('{param:restart|0}') = '1';
        //    if not Restarted then 
        //    begin
        //        Result := not RegValueExists(HKA, 'Software\Microsoft\Windows\CurrentVersion\RunOnce', RunOnceName);
        //        if not Result then
        //        MsgBox(QuitMessageReboot, mbError, mb_Ok);
        //    end 
        //    else
        //        Result := True;
        //end;
        public override bool InitializeSetup()
        {
            bool res = true;

            if(!Restarted)
            {
                res = RegValueExists(RegistryHive.HKA, @"Software\Microsoft\Windows\CurrentVersion\RunOnce", RunOnceName);
                if(!res)
                    MsgBox(QuitMessageReboot, TMsgBoxType.Error, MB.Ok);
            }

            return res;
        }


        //function DetectAndInstallPrerequisites: Boolean;
        //begin
        //    (*** Place your prerequisite detection and installation code below. ***)
        //    (*** Return False if missing prerequisites were detected but their installation failed, else return True. ***)

        //    //<your code here>

        //    Result := True;

        //    (*** Remove the following block! Used by this demo to simulate a prerequisite install requiring a reboot. ***)
        //    if not Restarted then
        //        RestartReplace(ParamStr(0), '');
        //end;
        private bool DetectAndInstallPrerequisites()
        {
            // Place your prerequisite detection and installation code below.
            // Return False if missing prerequisites were detected but their installation failed, else return True.
            // <your code here>

            // Remove the following block! Used by this demo to simulate a prerequisite install requiring a reboot.

            if (!Restarted)
                RestartReplace(ParamStr(0), "");

            return true;
        }

        //function Quote(const S: String): String;
        //begin
        //    Result := '"' + S + '"';
        //end;
        private string Quote(string S)
        {
            return $"\"{S}\"";
        }

        //function AddParam(const S, P, V: String): String;
        //begin
        //if V<> '""' then
        //    Result := S + ' /' + P + '=' + V;
        //end;
        private string AddParam(string S, string P, string V)
        {
            if (V != "\"\"")
                return $"{S}/{P}={V}";

            return "";
        }

        //function AddSimpleParam(const S, P: String): String;
        //begin
        //    Result := S + ' /' + P;
        //end;
        private string AddSimpleParam(string S, string P)
        {
            return $"{S}/{P}";
        }

        //procedure CreateRunOnceEntry;
        //var
        //    RunOnceData: String;
        //begin
        //    RunOnceData := Quote(ExpandConstant('{srcexe}')) + ' /restart=1';
        //    RunOnceData := AddParam(RunOnceData, 'LANG', ExpandConstant('{language}'));
        //    RunOnceData := AddParam(RunOnceData, 'DIR', Quote(WizardDirValue));
        //    RunOnceData := AddParam(RunOnceData, 'GROUP', Quote(WizardGroupValue));

        //    if WizardNoIcons then
        //        RunOnceData := AddSimpleParam(RunOnceData, 'NOICONS');
        //    RunOnceData := AddParam(RunOnceData, 'TYPE', Quote(WizardSetupType(False)));
        //    RunOnceData := AddParam(RunOnceData, 'COMPONENTS', Quote(WizardSelectedComponents(False)));
        //    RunOnceData := AddParam(RunOnceData, 'TASKS', Quote(WizardSelectedTasks(False)));

        //    (*** Place any custom user selection you want to remember below. ***)

        //    //<your code here>
        //    RegWriteStringValue(HKA, 'Software\Microsoft\Windows\CurrentVersion\RunOnce', RunOnceName, RunOnceData);
        //end;
        private void CreateRunOnceEntry()
        {
            var RunOnceData = Quote(ExpandConstant(__srcexe)) + " /restart=1";
            RunOnceData = AddParam(RunOnceData, "LANG", ExpandConstant(__language));
            RunOnceData = AddParam(RunOnceData, "DIR", Quote(WizardDirValue()));
            RunOnceData = AddParam(RunOnceData, "GROUP", Quote(WizardGroupValue()));

            if(WizardNoIcons())
                RunOnceData = AddSimpleParam(RunOnceData, "NOICONS");

            RunOnceData = AddParam(RunOnceData, "TYPE", Quote(WizardSetupType(false)));
            RunOnceData = AddParam(RunOnceData, "COMPONENTS", Quote(WizardSelectedComponents(false)));
            RunOnceData = AddParam(RunOnceData, "TASKS", Quote(WizardSelectedTasks(false)));

            // Place any custom user selection you want to remember below.

            RegWriteStringValue(RegistryHive.HKA, @"Software\Microsoft\Windows\CurrentVersion\RunOnce", RunOnceName, RunOnceData);
        }

        //function PrepareToInstall(var NeedsRestart: Boolean): String;
        //var
        //    ChecksumBefore, ChecksumAfter: String;
        //begin
        //    ChecksumBefore := MakePendingFileRenameOperationsChecksum;
        //    if DetectAndInstallPrerequisites then begin
        //        ChecksumAfter := MakePendingFileRenameOperationsChecksum;

        //    if ChecksumBefore<> ChecksumAfter then begin
        //        CreateRunOnceEntry;
        //        NeedsRestart := True;
        //        Result := QuitMessageReboot;
        //    end;
        //    end else
        //        Result := QuitMessageError;
        //end;
        public override string PrepareToInstall(ref bool needsRestart)
        {
            string ChecksumAfter = "";
            var ChecksumBefore = MakePendingFileRenameOperationsChecksum();

            if(DetectAndInstallPrerequisites())
                ChecksumAfter = MakePendingFileRenameOperationsChecksum();

            if(ChecksumBefore != ChecksumAfter)
            {
                CreateRunOnceEntry();
                needsRestart = true;
                return QuitMessageReboot;
            }

            return QuitMessageError;
        }

        //function ShouldSkipPage(PageID: Integer): Boolean;
        //begin
        //    Result := Restarted;
        //end;
        public override bool ShouldSkipPage(int pageId)
        {
            return Restarted;
        }
    }
}
