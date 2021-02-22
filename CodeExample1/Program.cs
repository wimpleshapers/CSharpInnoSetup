
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive;
using System;
using System.IO;

namespace CodingMuscles.CSharpInnoSetup.Example.CodeExample1
{
    class Program
    {
        static int Main(string[] args)
        {
            return ExampleConsole.Run(() => new ExampleInstallation(new DirectoryInfo(args[0])), new FileInfo(args[1]));
        }
    }

    internal class BaseInstaller : Installation
    {
        public override string AppName => throw new NotImplementedException();

        public override string AppVersion => throw new NotImplementedException();

        //<event ('InitializeWizard')>
        //procedure InitializeWizard2;
        //begin
        //    Log('InitializeWizard2 called');
        //end;
        public override void InitializeWizard()
        {
            Log("Base InitializeWizard called");
        }
    }


    internal class ExampleInstallation : BaseInstaller
    {
        private readonly DirectoryInfo _source;
        private bool MyProgChecked;
        private bool MyProgCheckResult;
        private bool FinishedInstall;

        public ExampleInstallation(DirectoryInfo source)
        {
            _source = source;
        }

        //AppName=My Program
        //AppVersion=1.5
        //WizardStyle=modern
        //DisableWelcomePage=no
        //DefaultDirName={code:MyConst}\My Program
        //DefaultGroupName=My Program
        //UninstallDisplayIcon={app}\MyProg.exe
        //InfoBeforeFile=Readme.txt
        //OutputDir=userdocs:Inno Setup Examples Output
        public override string AppName => "My Program";
        public override string AppVersion => "1.5";
        public override WizardStyle WizardStyle => WizardStyle.Modern;
        public override bool DisableWelcomePage => false;
        public override DirectoryInfo DefaultDirName => new DirectoryInfo($"{__code(() => MyConst)}\\My Program");
        public override string DefaultGroupName => "My Program";
        public override IconFile UninstallDisplayIcon => new IconFile(new FileInfo($"{__app}\\MyProg.exe"));
        public override FileInfo InfoBeforeFile => new FileInfo(Path.Combine(_source.FullName, "Readme.txt"));
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
                    //Source: "MyProg.exe"; DestDir: "{app}"; Check: MyProgCheck; BeforeInstall: BeforeMyProgInstall('MyProg.exe'); AfterInstall: AfterMyProgInstall('MyProg.exe')
                    //Source: "MyProg.chm"; DestDir: "{app}"; Check: MyProgCheck; BeforeInstall: BeforeMyProgInstall('MyProg.chm'); AfterInstall: AfterMyProgInstall('MyProg.chm')
                    //Source: "Readme.txt"; DestDir: "{app}"; Flags: isreadme
                    builder().Source(_source, "MyProg.exe").Destination(__app)
                        .Check(fn => MyProgCheck()).BeforeInstall(fn => BeforeMyProgInstall("MyProg.exe")).AfterInstall(fn => AfterMyProgInstall("MyProg.exe")).Build(),
                    builder().Source(_source, "MyProg.chm").Destination(__app)
                        .Check(fn => MyProgCheck()).BeforeInstall(fn => BeforeMyProgInstall("MyProg.chm")).AfterInstall(fn => AfterMyProgInstall("MyProg.chm")).Build(),
                    builder().Source(_source, "Readme.txt").Destination(__app).Flags(FileFlags.IsReadme).Build()
                };
            });
        };

        //function InitializeSetup(): Boolean;
        //begin
        //    Log('InitializeSetup called');
        //    Result := MsgBox('InitializeSetup:' #13#13 'Setup is initializing. Do you really want to start setup?', mbConfirmation, MB_YESNO) = idYes;
        //    if Result = False then
        //        MsgBox('InitializeSetup:' #13#13 'Ok, bye bye.', mbInformation, MB_OK);
        //end;
        public override bool InitializeSetup()
        {
            Log("InitializeSetup called");
            var res = MsgBox(
                "InitializeSetup: \r\r Setup is initializing. Do you really want to start setup?",
                TMsgBoxType.Confirmation,
                MB.YesNo) == MsgBoxResult.Yes;

            if (res == false)
                MsgBox("InitializeSetup: \r\r Ok, bye bye.", TMsgBoxType.Information, MB.Ok);

            return res;
        }


        //procedure InitializeWizard;
        //begin
        //    Log('InitializeWizard called');
        //end;
        public override void InitializeWizard()
        {
            Log("InitializeWizard called");

            // CSharpInnoSetup doesn't support function <event ('xxxxx')> attribute.
            // Rather, create a hierarchy of Installation objects and call the base
            // class implementation to get similar behavior.
            base.InitializeWizard();
        }

        //procedure DeinitializeSetup();
        //var
        //    FileName: String;
        //    ResultCode: Integer;
        //begin
        //    Log('DeinitializeSetup called');
        //    if FinishedInstall then 
        //    begin
        //        if MsgBox('DeinitializeSetup:' #13#13 'The [Code] scripting demo has finished. Do you want to uninstall My Program now?', mbConfirmation, MB_YESNO) = idYes then 
        //        begin
        //            FileName := ExpandConstant('{uninstallexe}');
        //            if not Exec(FileName, '', '', SW_SHOWNORMAL, ewNoWait, ResultCode) then
        //            MsgBox('DeinitializeSetup:' #13#13 'Execution of ''' + FileName + ''' failed. ' + SysErrorMessage(ResultCode) + '.', mbError, MB_OK);
        //        end 
        //        else
        //            MsgBox('DeinitializeSetup:' #13#13 'Ok, bye bye.', mbInformation, MB_OK);
        //    end;
        //end;
        public override void DeinitializeSetup()
        {
            Log("DeinitializeSetup called");

            if (FinishedInstall)
            {
                if (MsgBox("DeinitializeSetup: \r\r The [Code] scripting demo has finished. Do you want to uninstall My Program now?",
                    TMsgBoxType.Confirmation,
                    MB.YesNo) == MsgBoxResult.Yes)
                {
                    int ResultCode = 0;
                    var FileName = ExpandConstant(__uninstallexe);
                    if (!Exec(FileName, "", "", ShowWindow.Normal, TExecWait.NoWait, ref ResultCode))
                    {
                        MsgBox(
                            "DeinitializeSetup: \r\r Execution of '" + FileName + "' failed. " + SysErrorMessage(ResultCode) + ".",
                            TMsgBoxType.Error, 
                            MB.Ok);
                    }
                    else
                    {
                        MsgBox("DeinitializeSetup: \r\r Ok, bye bye.", TMsgBoxType.Information, MB.Ok);
                    }
                }
            }
        }

        //procedure CurStepChanged(CurStep: TSetupStep);
        //begin
        //    Log('CurStepChanged(' + IntToStr(Ord(CurStep)) + ') called');
        //    if CurStep = ssPostInstall then
        //        FinishedInstall := True;
        //end;
        public override void CurStepChanged(TSetupStep curStep)
        {
            Log("CurStepChanged(" + IntToStr(Ord(curStep)) + ") called");
            if (curStep == TSetupStep.PostInstall)
            {
                FinishedInstall = true;
            }
        }

        //procedure CurInstallProgressChanged(CurProgress, MaxProgress: Integer);
        //begin
        //    Log('CurInstallProgressChanged(' + IntToStr(CurProgress) + ', ' + IntToStr(MaxProgress) + ') called');
        //end;
        public override void CurInstallProgressChanged(int curProgress, int maxProgress)
        {
            Log("CurInstallProgressChanged(" + IntToStr(curProgress) + ", " + IntToStr(maxProgress) + ") called");
        }

        //function NextButtonClick(CurPageID: Integer): Boolean;
        //var
        //    ResultCode: Integer;
        //begin
        //    Log('NextButtonClick(' + IntToStr(CurPageID) + ') called');
        //    case CurPageID of
        //        wpSelectDir:
        //            MsgBox('NextButtonClick:' #13#13 'You selected: ''' + WizardDirValue + '''.', mbInformation, MB_OK);
        //        wpSelectProgramGroup:
        //            MsgBox('NextButtonClick:' #13#13 'You selected: ''' + WizardGroupValue + '''.', mbInformation, MB_OK);
        //        wpReady:
        //        begin
        //            if MsgBox('NextButtonClick:' #13#13 'Using the script, files can be extracted before the installation starts. For example we could extract ''MyProg.exe'' now and run it.' #13#13 'Do you want to do this?', mbConfirmation, MB_YESNO) = idYes then begin
        //                ExtractTemporaryFile('myprog.exe');
        //                if not ExecAsOriginalUser(ExpandConstant('{tmp}\myprog.exe'), '', '', SW_SHOWNORMAL, ewWaitUntilTerminated, ResultCode) then
        //                    MsgBox('NextButtonClick:' #13#13 'The file could not be executed. ' + SysErrorMessage(ResultCode) + '.', mbError, MB_OK);
        //            end;
        //            BringToFrontAndRestore();
        //            MsgBox('NextButtonClick:' #13#13 'The normal installation will now start.', mbInformation, MB_OK);
        //        end;
        //    end;

        //    Result := True;
        //end;
        public override bool NextButtonClick(int curPageId)
        {
            Log("NextButtonClick(" + IntToStr(curPageId) + ") called");

            if(curPageId == PageID.SelectDir)
            {
                MsgBox("NextButtonClick: \r\r You selected: '" + WizardDirValue() + "'.", TMsgBoxType.Information, MB.Ok);
            }
            else if (curPageId == PageID.SelectProgramGroup)
            {
                MsgBox("NextButtonClick: \r\r You selected: '" + WizardGroupValue() + "'.", TMsgBoxType.Information, MB.Ok);
            }
            else if (curPageId == PageID.Ready)
            {
                if (MsgBox("NextButtonClick: \r\r Using the script, files can be extracted before the installation starts. For example we could extract 'MyProg.exe' now and run it. \r\r Do you want to do this?",
                    TMsgBoxType.Confirmation,
                    MB.YesNo) == MsgBoxResult.Yes)
                {
                    int ResultCode = 0;
                    ExtractTemporaryFile("myprog.exe");
                    if(!ExecAsOriginalUser(ExpandConstant($"{__tmp}\\myprog.exe"), "", "", ShowWindow.Normal, TExecWait.WaitUntilTerminated, ref ResultCode))
                        MsgBox("NextButtonClick: \r\r The file could not be executed. " + SysErrorMessage(ResultCode) + ".", TMsgBoxType.Error, MB.Ok);
                }

                BringToFrontAndRestore();
                MsgBox("NextButtonClick: \r\r The normal installation will now start.", TMsgBoxType.Information, MB.Ok);
            }

            return true;
        }


        //function BackButtonClick(CurPageID: Integer): Boolean;
        //begin
        //    Log('BackButtonClick(' + IntToStr(CurPageID) + ') called');
        //    Result := True;
        //end;
        public override bool BackButtonClick(int curPageId)
        {
            Log("BackButtonClick(" + IntToStr(curPageId) + ") called");
            return true;
        }

        //function ShouldSkipPage(PageID: Integer): Boolean;
        //begin
        //    Log('ShouldSkipPage(' + IntToStr(PageID) + ') called');
        //    { Skip wpInfoBefore page; show all others }
        //    case PageID of
        //        wpInfoBefore:
        //            Result := True;
        //    else
        //        Result := False;
        //    end;
        //end;
        public override bool ShouldSkipPage(int pageId)
        {
            Log("ShouldSkipPage(" + IntToStr(pageId) + ") called");

            //Skip wpInfoBefore page; show all others
            return pageId == PageID.InfoBefore;
        }

        //procedure CurPageChanged(CurPageID: Integer);
        //begin
        //    Log('CurPageChanged(' + IntToStr(CurPageID) + ') called');
        //    case CurPageID of
        //        wpWelcome:
        //            MsgBox('CurPageChanged:' #13#13 'Welcome to the [Code] scripting demo. This demo will show you some possibilities of the scripting support.' #13#13 'The scripting engine used is RemObjects Pascal Script by Carlo Kok. See http://www.remobjects.com/ps for more information.', mbInformation, MB_OK);
        //        wpFinished:
        //            MsgBox('CurPageChanged:' #13#13 'Welcome to final page of this demo. Click Finish to exit.', mbInformation, MB_OK);
        //    end;
        //end;
        public override void CurPageChanged(int curPageId)
        {
            Log("CurPageChanged(" + IntToStr(curPageId) + ") called");

            if(curPageId == PageID.Welcome)
                MsgBox("CurPageChanged: \r\r Welcome to the [Code] scripting demo. This demo will show you some possibilities of the scripting support. \r\r The scripting engine used is RemObjects Pascal Script by Carlo Kok. See http://www.remobjects.com/ps for more information.", TMsgBoxType.Information, MB.Ok);
            else if(curPageId == PageID.Finished)
                MsgBox("CurPageChanged: \r\r Welcome to final page of this demo. Click Finish to exit.", TMsgBoxType.Information, MB.Ok);
        }

        //function PrepareToInstall(var NeedsRestart: Boolean): String;
        //begin
        //    Log('PrepareToInstall() called');
        //    if MsgBox('PrepareToInstall:' #13#13 'Setup is preparing to install. Using the script you can install any prerequisites, abort Setup on errors, and request restarts. Do you want to return an error now?', mbConfirmation, MB_YESNO or MB_DEFBUTTON2) = idYes then
        //        Result := '<your error text here>.'
        //    else
        //        Result := '';
        //end;
        public override string PrepareToInstall(ref bool needsRestart)
        {
            Log("PrepareToInstall() called");

            if (MsgBox("PrepareToInstall: \r\r Setup is preparing to install. Using the script you can install any prerequisites, abort Setup on errors, and request restarts. Do you want to return an error now?", TMsgBoxType.Confirmation, MB.YesNo | MB.DefaultButton2) == MsgBoxResult.Yes)
                return "<your error text here>.";

            return "";            
        }

        //function MyProgCheck(): Boolean;
        //begin
        //    Log('MyProgCheck() called');
        //    if not MyProgChecked then begin
        //        MyProgCheckResult := MsgBox('MyProgCheck:' #13#13 'Using the script you can decide at runtime to include or exclude files from the installation. Do you want to install MyProg.exe and MyProg.chm to ' + ExtractFilePath(CurrentFileName) + '?', mbConfirmation, MB_YESNO) = idYes;
        //        MyProgChecked := True;
        //    end;
        //    Result := MyProgCheckResult;
        //end;
        private bool MyProgCheck()
        {
            Log("MyProgCheck() called");
            if (!MyProgChecked)
            {
                MyProgCheckResult = MsgBox(
                    "MyProgCheck: \r\r Using the script you can decide at runtime to include or exclude files from the installation. Do you want to install MyProg.exe and MyProg.chm to " + ExtractFilePath(CurrentFilename()) + "?", 
                    TMsgBoxType.Confirmation, 
                    MB.YesNo) == MsgBoxResult.Yes;

                MyProgChecked = true;
            }

            return MyProgCheckResult;
        }

        //procedure BeforeMyProgInstall(S: String);
        //begin
        //    Log('BeforeMyProgInstall(''' + S + ''') called');
        //    MsgBox('BeforeMyProgInstall:' #13#13 'Setup is now going to install ' + S + ' as ' + CurrentFileName + '.', mbInformation, MB_OK);
        //end;
        private void BeforeMyProgInstall(string S)
        {
            Log("BeforeMyProgInstall('" + S + "') called");

            MsgBox(
                "BeforeMyProgInstall: \r\r Setup is now going to install " + S + " as " + CurrentFilename() + ".", 
                TMsgBoxType.Information, 
                MB.Ok);
        }

        //procedure AfterMyProgInstall(S: String);
        //begin
        //    Log('AfterMyProgInstall(''' + S + ''') called');
        //    MsgBox('AfterMyProgInstall:' #13#13 'Setup just installed ' + S + ' as ' + CurrentFileName + '.', mbInformation, MB_OK);
        //end;
        private void AfterMyProgInstall(string S)
        {
            Log("AfterMyProgInstall('" + S + "') called");

            MsgBox(
                "AfterMyProgInstall: \r\r Setup just installed " + S + " as " + CurrentFilename() + ".",
                TMsgBoxType.Information,
                MB.Ok);
        }

        //function MyConst(Param: String): String;
        //begin
        //    Log('MyConst(''' + Param + ''') called');
        //    Result := ExpandConstant('{autopf}');
        //end;
        private string MyConst(string Param)
        {
            Log("MyConst('" + Param + "') called");
            return ExpandConstant(__autopf);
        }
    }
}