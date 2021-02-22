using CodingMuscles.CSharpInnoSetup.Example;
using CodingMuscles.CSharpInnoSetup.Script.Constructs;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive;
using System;
using System.IO;

namespace CodingMuscles.CSharpInnoSetup.ExampleCodeDlg
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

        private TInputQueryWizardPage UserPage; 
        private TInputOptionWizardPage UsagePage;
        private TOutputMsgWizardPage LightMsgPage;
        private TInputQueryWizardPage KeyPage;
        private TOutputProgressWizardPage ProgressPage;
        private TInputDirWizardPage DataDirPage;

        public ExampleInstallation(DirectoryInfo source)
        {
            _source = source;
        }

        //AppName=My Program
        //AppVersion=1.5
        //WizardStyle=modern
        //DisableWelcomePage=no
        //DefaultDirName={autopf}\My Program
        //DisableProgramGroupPage=yes
        //UninstallDisplayIcon={app}\MyProg.exe
        //OutputDir=userdocs:Inno Setup Examples Output
        //PrivilegesRequired=lowest
        public override string AppName => "My Program";
        public override string AppVersion => "1.5";
        public override WizardStyle WizardStyle => WizardStyle.Modern;
        public override bool DisableWelcomePage => false;
        public override bool CreateAppDir => false;
        public override AutoTriad DisableProgramGroupPage => AutoTriad.Yes;
        public override IconFile UninstallDisplayIcon => new IconFile(new FileInfo($"{__app}\\MyProg.exe"));
        public override OutputDirectory OutputDir => OutputDirectory.UserDocs("Inno Setup Examples Output");
        public override PrivilegesRequired PrivilegesRequired => PrivilegesRequired.Lowest;

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

            contentBuilder.AddRegistryEntries((builder, languages, types, customMessage, messages, components, tasks) =>
            {
                return new[]
                {
                    //Root: HKA; Subkey: "Software\My Company"; Flags: uninsdeletekeyifempty
                    //Root: HKA; Subkey: "Software\My Company\My Program"; Flags: uninsdeletekey
                    //Root: HKA; Subkey: "Software\My Company\My Program\Settings"; ValueType: string; ValueName: "Name"; ValueData: "{code:GetUser|Name}"
                    //Root: HKA; Subkey: "Software\My Company\My Program\Settings"; ValueType: string; ValueName: "Company"; ValueData: "{code:GetUser|Company}"
                    //Root: HKA; Subkey: "Software\My Company\My Program\Settings"; ValueType: string; ValueName: "DataDir"; ValueData: "{code:GetDataDir}"
                    builder().Hive(RegistryHive.HKA).Subkey(@"Software\My Company").Flags(RegistryFlags.UninstallDeleteKeyIfEmpty).Build(),
                    builder().Hive(RegistryHive.HKA).Subkey(@"Software\My Company\My Program").Flags(RegistryFlags.UninstallDeleteKey).Build(),
                    builder().Hive(RegistryHive.HKA).Subkey(@"Software\My Company\My Program\Settings").ValueType(RegistryDataType.String).ValueName("Name").ValueData(__code(() => GetUser("Name"))).Build(),
                    builder().Hive(RegistryHive.HKA).Subkey(@"Software\My Company\My Program\Settings").ValueType(RegistryDataType.String).ValueName("Company").ValueData(__code(() => GetUser("Company"))).Build(),
                    builder().Hive(RegistryHive.HKA).Subkey(@"Software\My Company\My Program\Settings").ValueType(RegistryDataType.String).ValueName("DataDir").ValueData(__code(() => GetDataDir)).Build()
                };
            });

            contentBuilder.AddFolders((builder, languages, types, customMessage, messages, components, tasks) =>
            {
                return new[]
                {
                    // Name: { code: GetDataDir}; Flags: uninsneveruninstall
                    builder().Name(__code(() => GetDataDir)).Flags(FolderFlags.NeverUninstall).Build()
                };
            });
        };

        //procedure InitializeWizard;
        //begin
        //    { Create the pages }

        //    UserPage := CreateInputQueryPage(wpWelcome,
        //        'Personal Information', 'Who are you?',
        //        'Please specify your name and the company for whom you work, then click Next.');
        //    UserPage.Add('Name:', False);
        //    UserPage.Add('Company:', False);

        //    UsagePage := CreateInputOptionPage(UserPage.ID,
        //        'Personal Information', 'How will you use My Program?',
        //        'Please specify how you would like to use My Program, then click Next.',
        //        True, False);
        //    UsagePage.Add('Light mode (no ads, limited functionality)');
        //    UsagePage.Add('Sponsored mode (with ads, full functionality)');
        //    UsagePage.Add('Paid mode (no ads, full functionality)');

        //    LightMsgPage := CreateOutputMsgPage(UsagePage.ID,
        //        'Personal Information', 'How will you use My Program?',
        //        'Note: to enjoy all features My Program can offer and to support its development, ' +
        //        'you can switch to sponsored or paid mode at any time by selecting ''Usage Mode'' ' +
        //        'in the ''Help'' menu of My Program after the installation has completed.'#13#13 +
        //        'Click Back if you want to change your usage mode setting now, or click Next to ' +
        //        'continue with the installation.');

        //    KeyPage := CreateInputQueryPage(UsagePage.ID,
        //        'Personal Information', 'What''s your registration key?',
        //        'Please specify your registration key and click Next to continue. If you don''t ' +
        //        'have a valid registration key, click Back to choose a different usage mode.');
        //    KeyPage.Add('Registration key:', False);

        //    ProgressPage := CreateOutputProgressPage('Personal Information', 'What''s your registration key?');

        //    DataDirPage := CreateInputDirPage(wpSelectDir,
        //        'Select Personal Data Directory', 'Where should personal data files be installed?',
        //        'Select the folder in which Setup should install personal data files, then click Next.',
        //        False, '');
        //    DataDirPage.Add('');

        //    { Set default values, using settings that were stored last time if possible }

        //    UserPage.Values[0] := GetPreviousData('Name', ExpandConstant('{sysuserinfoname}'));
        //    UserPage.Values[1] := GetPreviousData('Company', ExpandConstant('{sysuserinfoorg}'));

        //    case GetPreviousData('UsageMode', '') of
        //        'light': UsagePage.SelectedValueIndex := 0;
        //        'sponsored': UsagePage.SelectedValueIndex := 1;
        //        'paid': UsagePage.SelectedValueIndex := 2;
        //    else
        //        UsagePage.SelectedValueIndex := 1;
        //    end;

        //    DataDirPage.Values[0] := GetPreviousData('DataDir', '');
        //end;
        public override void InitializeWizard()
        {
            // Create the pages

            UserPage = CreateInputQueryPage(
                PageID.Welcome, 
                "Personal Information", 
                "Who are you?",
                "Please specify your name and the company for whom you work, then click Next.");
            UserPage.Add("Name:", false);
            UserPage.Add("Company:", false);

            UsagePage = CreateInputOptionPage(UserPage.ID,
                "Personal Information", "How will you use My Program?",
                "Please specify how you would like to use My Program, then click Next.",
                true, false);
            UsagePage.Add("Light mode (no ads, limited functionality)");
            UsagePage.Add("Sponsored mode (with ads, full functionality)");
            UsagePage.Add("Paid mode (no ads, full functionality)");

            LightMsgPage = CreateOutputMsgPage(UsagePage.ID,
                "Personal Information", "How will you use My Program?",
                "Note: to enjoy all features My Program can offer and to support its development, " +
                "you can switch to sponsored or paid mode at any time by selecting 'Usage Mode' " +
                "in the 'Help' menu of My Program after the installation has completed.\r\r" +
                    "Click Back if you want to change your usage mode setting now, or click Next to " +
                "continue with the installation.");

            KeyPage = CreateInputQueryPage(UsagePage.ID,
                "Personal Information", "What's your registration key?",
                "Please specify your registration key and click Next to continue. If you don't " +
                "have a valid registration key, click Back to choose a different usage mode.");
            KeyPage.Add("Registration key:", false);

            ProgressPage = CreateOutputProgressPage("Personal Information", "What's your registration key?");

            DataDirPage = CreateInputDirPage(PageID.SelectDir,
                "Select Personal Data Directory", "Where should personal data files be installed?",
                "Select the folder in which Setup should install personal data files, then click Next.",
                false, "");

            DataDirPage.Add("");

            // Set default values, using settings that were stored last time if possible

            UserPage.Values[0] = GetPreviousData("Name", ExpandConstant(__sysuserinfoname));
            UserPage.Values[1] = GetPreviousData("Company", ExpandConstant(__sysuserinfoorg));

            switch (GetPreviousData("UsageMode", ""))
            {
                case "light":
                    UsagePage.SelectedValueIndex = 0;
                    break;

                case "sponsored":
                    UsagePage.SelectedValueIndex = 1;
                    break;

                case "paid":
                    UsagePage.SelectedValueIndex = 2;
                    break;

                default:
                    UsagePage.SelectedValueIndex = 1;
                    break;
            }

            DataDirPage.Values[0] = GetPreviousData("DataDir", "");
        }

        //function UpdateReadyMemo(Space, NewLine, MemoUserInfoInfo, MemoDirInfo, MemoTypeInfo,
        //    MemoComponentsInfo, MemoGroupInfo, MemoTasksInfo: String): String;
        //var
        //    S: String;
        //begin
        //    { Fill the 'Ready Memo' with the normal settings and the custom settings }
        //    S := '';
        //    S := S + 'Personal Information:' + NewLine;
        //    S := S + Space + UserPage.Values[0] + NewLine;
        //    if UserPage.Values[1] <> '' then
        //        S := S + Space + UserPage.Values[1] + NewLine;
        //    S := S + NewLine;

        //    S := S + 'Usage Mode:' + NewLine + Space;
        //    case UsagePage.SelectedValueIndex of
        //        0: S := S + 'Light mode';
        //        1: S := S + 'Sponsored mode';
        //        2: S := S + 'Paid mode';
        //    end;
        //    S := S + NewLine + NewLine;

        //    S := S + MemoDirInfo + NewLine;
        //    S := S + Space + DataDirPage.Values[0] + ' (personal data files)' + NewLine;

        //    Result := S;
        //end;
        public override string UpdateReadyMemo(string space, string newLine, string memoUserInfoInfo, string memoDirInfo, string memoTypeInfo, string memoComponentsInfo, string memoGroupInfo, string memoTasksInfo)
        {
            // Fill the 'Ready Memo' with the normal settings and the custom settings
            var S = "";
            S = S + "Personal Information:" + NewLine;
            S = S + space + UserPage.Values[0] + NewLine;
            if(UserPage.Values[1] != "")
                S = S + space + UserPage.Values[1] + NewLine;
            S += NewLine;

            S = S + "Usage Mode:" + NewLine + space;
            switch(UsagePage.SelectedValueIndex)
            {
                case 0:
                    S += "Light mode";
                    break;
                case 1:
                    S += "Sponsored mode";
                    break;
                case 2:
                    S += "Paid mode";
                    break;
                default:
                    S += "default";
                    break;
            }

            S = S + NewLine + NewLine;

            S = S + memoDirInfo + NewLine;
            S = S + space + DataDirPage.Values[0] + " (personal data files)" + NewLine;

            return S;
        }

        //function ShouldSkipPage(PageID: Integer): Boolean;
        //begin
        //    { Skip pages that shouldn't be shown }
        //    if (PageID = LightMsgPage.ID) and(UsagePage.SelectedValueIndex<> 0) then
        //        Result := True
        //    else if (PageID = KeyPage.ID) and(UsagePage.SelectedValueIndex<> 2) then
        //        Result := True
        //    else
        //        Result := False;
        //end;
        public override bool ShouldSkipPage(int pageId)
        {
            // Skip pages that shouldn't be shown
            if ((pageId == LightMsgPage.ID) && (UsagePage.SelectedValueIndex != 0))
                return true;
            else if ((pageId == KeyPage.ID) && (UsagePage.SelectedValueIndex != 2))
                return true;

            return false;
        }

        //function NextButtonClick(CurPageID: Integer): Boolean;
        //var
        //    I: Integer;
        //begin
        //    { Validate certain pages before allowing the user to proceed }
        //    if CurPageID = UserPage.ID then 
        //    begin
        //        if UserPage.Values[0] = '' then 
        //        begin
        //            MsgBox('You must enter your name.', mbError, MB_OK);
        //            Result := False;
        //        end 
        //        else 
        //        begin
        //            if DataDirPage.Values[0] = '' then
        //                DataDirPage.Values[0] := 'C:\' + UserPage.Values[0];
        //             Result := True;
        //        end;
        //    end 
        //    else 
        //        if CurPageID = KeyPage.ID then 
        //        begin
        //            { Just to show how 'OutputProgress' pages work.  Always use a try..finally between the Show and Hide calls as shown below. }
        //            ProgressPage.SetText('Authorizing registration key...', '');
        //            ProgressPage.SetProgress(0, 0);
        //            ProgressPage.Show;

        //            try
        //                for I := 0 to 10 do 
        //                begin
        //                    ProgressPage.SetProgress(I, 10);
        //                    Sleep(100);
        //                end;
        //            finally
        //                ProgressPage.Hide;
        //            end;
        //            if GetSHA1OfString('codedlg' + KeyPage.Values[0]) = '8013f310d340dab18a0d0cda2b5b115d2dcd97e4' then
        //                Result := True
        //            else 
        //            begin
        //                MsgBox('You must enter a valid registration key. (Hint: The key is "inno".)', mbError, MB_OK);
        //                Result := False;
        //            end;
        //        end 
        //        else
        //            Result := True;
        //end;
        public override bool NextButtonClick(int curPageId)
        {
            // Validate certain pages before allowing the user to proceed
            if (curPageId == UserPage.ID)
            {
                if (UserPage.Values[0] == "")
                {
                    MsgBox("You must enter your name.", TMsgBoxType.Error, MB.Ok);
                    return false;
                }
                else if (DataDirPage.Values[0] == "")
                {
                    DataDirPage.Values[0] = "C:\\" + UserPage.Values[0];
                }

                return true;
            }
            else if (curPageId == KeyPage.ID)
            {
                // Just to show how 'OutputProgress' pages work.
                // Always use a try..finally between the Show and Hide calls as shown below.
                ProgressPage.SetText("Authorizing registration key...", "");
                ProgressPage.SetProgress(0, 0);
                ProgressPage.Show();

                try
                {
                    for (int I = 0; I <= 10; I++)
                    {
                        ProgressPage.SetProgress(I, 10);
                        Sleep(100);
                    }
                }
                finally
                {
                    ProgressPage.Hide();
                }

                if(GetSHA1OfString("codedlg" + KeyPage.Values[0]) == "8013f310d340dab18a0d0cda2b5b115d2dcd97e4")
                {
                    return true;
                }
                else
                {
                    MsgBox("You must enter a valid registration key. (Hint: The key is \"inno\".)", TMsgBoxType.Error, MB.Ok);
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        //procedure RegisterPreviousData(PreviousDataKey: Integer);
        //var
        //    UsageMode: String;
        //begin
        //    { Store the settings so we can restore them next time }
        //    SetPreviousData(PreviousDataKey, 'Name', UserPage.Values[0]);
        //    SetPreviousData(PreviousDataKey, 'Company', UserPage.Values[1]);
        //    case UsagePage.SelectedValueIndex of
        //        0: UsageMode := 'light';
        //        1: UsageMode := 'sponsored';
        //        2: UsageMode := 'paid';
        //    end;
        //    SetPreviousData(PreviousDataKey, 'UsageMode', UsageMode);
        //    SetPreviousData(PreviousDataKey, 'DataDir', DataDirPage.Values[0]);
        //end;
        public override void RegisterPreviousData(int previousDataKey)
        {
            // Store the settings so we can restore them next time
            SetPreviousData(previousDataKey, "Name", UserPage.Values[0]);
            SetPreviousData(previousDataKey, "Company", UserPage.Values[1]);

            string UsageMode = "";

            switch(UsagePage.SelectedValueIndex)
            {
                case 0:
                    UsageMode = "light";
                    break;
                case 1:
                    UsageMode = "sponsored";
                    break;
                case 2:
                    UsageMode = "paid";
                    break;
            }

            SetPreviousData(previousDataKey, "UsageMode", UsageMode);
            SetPreviousData(previousDataKey, "DataDir", DataDirPage.Values[0]);
        }

        //function GetUser(Param: String): String;
        //begin
        //    { Return a user value }
        //    { Could also be split into separate GetUserName and GetUserCompany functions }
        //    if Param = 'Name' then
        //    Result := UserPage.Values[0]
        //    else if Param = 'Company' then
        //    Result := UserPage.Values[1];
        //end;
        string GetUser(string Param)
        {
            // Return a user value
            // Could also be split into separate GetUserName and GetUserCompany functions
            if(Param == "Name")
                return UserPage.Values[0];
            else if(Param == "Company")
                return UserPage.Values[1];

            return "";
        }

        //function GetDataDir(Param: String): String;
        //begin
        //    { Return the selected DataDir }
        //    Result := DataDirPage.Values[0];
        //end;
        string GetDataDir(string Param)
        {
            // Return the selected DataDir
            return DataDirPage.Values[0];
        }
    }
}
