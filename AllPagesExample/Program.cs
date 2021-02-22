
using CodingMuscles.CSharpInnoSetup.Example;
using CodingMuscles.CSharpInnoSetup.Script.Constructs;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive;
using System;
using System.IO;

namespace CodingMuscles.CSharpInnoSetup.ExampleAllPagesExample
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
        private const string _password = "Password";
        private readonly DirectoryInfo _source;
        //var
        //  OutputProgressWizardPage: TOutputProgressWizardPage;
        //  OutputProgressWizardPageAfterID: Integer;
        private TOutputProgressWizardPage OutputProgressWizardPage;
        private int OutputProgressWizardPageAfterID;
        private int Test = 0;

        public ExampleInstallation(DirectoryInfo source)
        {
            _source = source;
        }

        //AppName=My Program
        //AppVersion=1.5
        //WizardStyle=modern
        //DefaultDirName = { autopf }\My Program
        //DefaultGroupName=My Program
        //UninstallDisplayIcon={app
        //}\MyProg.exe
        //Compression = lzma2
        //SolidCompression=yes
        //OutputDir = userdocs:Inno Setup Examples Output
        public override string AppName => "My Program";
        public override string AppVersion => "1.5";
        public override WizardStyle WizardStyle => WizardStyle.Modern;
        public override DirectoryInfo DefaultDirName => new DirectoryInfo($"{__autopf}\\My Program");
        public override string DefaultGroupName => "My Program";
        public override IconFile UninstallDisplayIcon => new IconFile(new FileInfo($"{__app}\\MyProg.exe"));
        public override Compression Compression => Compression.Lzma2;
        public override bool SolidCompression => true;
        public override OutputDirectory OutputDir => OutputDirectory.UserDocs("Inno Setup Examples Output");
        //DisableWelcomePage=no
        //LicenseFile = license.txt
        //Password={#Password}
        //InfoBeforeFile=readme.txt
        //UserInfoPage = yes
        //PrivilegesRequired=lowest
        //DisableDirPage = no
        //DisableProgramGroupPage=no
        //InfoAfterFile = readme.txt
        public override bool DisableWelcomePage => false;
        public override FileInfo LicenseFile => new FileInfo(Path.Combine(_source.FullName, "license.txt"));
        public override string Password => _password;
        public override FileInfo InfoBeforeFile => new FileInfo(Path.Combine(_source.FullName, "readme.txt"));
        public override bool UserInfoPage => true;
        public override PrivilegesRequired PrivilegesRequired => PrivilegesRequired.Lowest;
        public override AutoTriad DisableDirPage => AutoTriad.No;
        public override AutoTriad DisableProgramGroupPage => AutoTriad.No;
        public override FileInfo InfoAfterFile => new FileInfo(Path.Combine(_source.FullName, "readme.txt"));

        public override Action<IParameterizedEntriesBuilder> ParameterizedEntriesBuilderHandler => builder =>
        {
            var languageDependentBuilder = builder.LanguagesBuilder.AddLanguages(builder => new { });
            var componentsBuilder = languageDependentBuilder.Add((builder, languages) => new { }, languages => new { }, languages => new { });

            var tasksBuilder = componentsBuilder.AddComponents((languages, types, customMessages, messages) => new
            {
                Component = ComponentFactory.CreateLeaf().Description("Component").Build()
            });

            var contentBuilder = tasksBuilder.AddTasks((languages, types, customMessages, messages, components) => new
            {
                Task = TaskFactory.CreateLeaf().Description("Task").Build()
            });

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
        };

        //procedure InitializeWizard;
        //var
        //    InputQueryWizardPage: TInputQueryWizardPage;
        //    InputOptionWizardPage: TInputOptionWizardPage;
        //    InputDirWizardPage: TInputDirWizardPage;
        //    InputFileWizardPage: TInputFileWizardPage;
        //    OutputMsgWizardPage: TOutputMsgWizardPage;
        //    OutputMsgMemoWizardPage: TOutputMsgMemoWizardPage;
        //    AfterID: Integer;
        //begin
        //    WizardForm.PasswordEdit.Text := '{#Password}';
        //
        //    AfterID := wpSelectTasks;
        //
        //    AfterID := CreateCustomPage(AfterID, 'CreateCustomPage', 'ADescription').ID;
        //
        //    InputQueryWizardPage := CreateInputQueryPage(AfterID, 'CreateInputQueryPage', 'ADescription', 'ASubCaption');
        //    InputQueryWizardPage.Add('&APrompt:', False);
        //    AfterID := InputQueryWizardPage.ID;
        //
        //    InputOptionWizardPage := CreateInputOptionPage(AfterID, 'CreateInputOptionPage', 'ADescription', 'ASubCaption', False, False);
        //    InputOptionWizardPage.Add('&AOption');
        //    AfterID := InputOptionWizardPage.ID;
        //
        //    InputDirWizardPage := CreateInputDirPage(AfterID, 'CreateInputDirPage', 'ADescription', 'ASubCaption', False, 'ANewFolderName');
        //    InputDirWizardPage.Add('&APrompt:');
        //    InputDirWizardPage.Values[0] := 'C:\';
        //    AfterID := InputDirWizardPage.ID;
        //
        //    InputFileWizardPage := CreateInputFilePage(AfterID, 'CreateInputFilePage', 'ADescription', 'ASubCaption');
        //    InputFileWizardPage.Add('&APrompt:', 'Executable files|*.exe|All files|*.*', '.exe');
        //    AfterID := InputFileWizardPage.ID;
        //
        //    OutputMsgWizardPage := CreateOutputMsgPage(AfterID, 'CreateOutputMsgPage', 'ADescription', 'AMsg');
        //    AfterID := OutputMsgWizardPage.ID;
        //
        //    OutputMsgMemoWizardPage := CreateOutputMsgMemoPage(AfterID, 'CreateOutputMsgMemoPage', 'ADescription', 'ASubCaption', 'AMsg');
        //    AfterID := OutputMsgMemoWizardPage.ID;
        //
        //    OutputProgressWizardPage := CreateOutputProgressPage('CreateOutputProgressPage', 'ADescription');
        //    OutputProgressWizardPageAfterID := AfterID;
        //end;
        public override void InitializeWizard()
        {
            WizardForm.PasswordEdit.Text = _password;
            var AfterID = PageID.SelectTasks;

            AfterID = CreateCustomPage(AfterID, "CreateCustomPage", "ADescription").ID;

            var InputQueryWizardPage = CreateInputQueryPage(AfterID, "CreateInputQueryPage", "ADescription", "ASubCaption");
            InputQueryWizardPage.Add("&APrompt:", false);
            AfterID = InputQueryWizardPage.ID;

            var InputOptionWizardPage = CreateInputOptionPage(AfterID, "CreateInputOptionPage", "ADescription", "ASubCaption", false, false);
            InputOptionWizardPage.Add("&AOption");
            AfterID = InputOptionWizardPage.ID;

            var InputDirWizardPage = CreateInputDirPage(AfterID, "CreateInputDirPage", "ADescription", "ASubCaption", false, "ANewFolderName");
            InputDirWizardPage.Add("&APrompt:");
            InputDirWizardPage.Values[0]  = "C:\\";
            AfterID = InputDirWizardPage.ID;

            var InputFileWizardPage = CreateInputFilePage(AfterID, "CreateInputFilePage", "ADescription", "ASubCaption");
            InputFileWizardPage.Add("&APrompt:", "Executable files|*.exe|All files|*.*", ".exe");
            AfterID = InputFileWizardPage.ID;

            var OutputMsgWizardPage = CreateOutputMsgPage(AfterID, "CreateOutputMsgPage", "ADescription", "AMsg");
            AfterID = OutputMsgWizardPage.ID;

            var OutputMsgMemoWizardPage = CreateOutputMsgMemoPage(AfterID, "CreateOutputMsgMemoPage", "ADescription", "ASubCaption", "AMsg");
            AfterID = OutputMsgMemoWizardPage.ID;

            OutputProgressWizardPage = CreateOutputProgressPage("CreateOutputProgressPage", "ADescription");
            OutputProgressWizardPageAfterID = AfterID;
        }


        //function NextButtonClick(CurPageID: Integer): Boolean;
        //var
        //  Position, Max: Integer;
        //begin
        //  if CurPageID = OutputProgressWizardPageAfterID then begin
        //    try
        //      Max := 25;
        //      for Position := 0 to Max do begin
        //        OutputProgressWizardPage.SetProgress(Position, Max);
        //        if Position = 0 then
        //          OutputProgressWizardPage.Show;
        //        Sleep(2000 div Max);
        //        end;
        //    finally
        //      OutputProgressWizardPage.Hide;
        //    end;
        //  end;
        //  Result := True;
        //end;
        public override bool NextButtonClick(int curPageId)
        {
            if(curPageId == OutputProgressWizardPageAfterID)
            {
                try
                {
                    var Max = 25;
                    for(int Position = 0; Position < 25; Position++)
                    {
                        OutputProgressWizardPage.SetProgress(Position, Max);
                        if(Position == 0)
                            OutputProgressWizardPage.Show();
                        Sleep(2000 / Max);
                    }
                }
                finally
                {
                    OutputProgressWizardPage.Hide();
                }
            }

            return true;
        }

        //function PrepareToInstall(var NeedsRestart: Boolean): String;
        //begin
        //  if SuppressibleMsgBox('Do you want to stop Setup at the Preparing To Install wizard page?', mbConfirmation, MB_YESNO, IDNO) = IDYES then
        //    Result := 'Stopped by user';
        //end;
        public override string PrepareToInstall(ref bool needsRestart)
        {
            if(SuppressibleMsgBox(
                "Do you want to stop Setup at the Preparing To Install wizard page?", 
                TMsgBoxType.Confirmation, 
                MB.YesNo, 
                MsgBoxResult.No) == MsgBoxResult.Yes)
            {
                return "Stopped by user";
            }

            return "";
        }
    }
}