
using CodingMuscles.CSharpInnoSetup.Script.Constructs;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CodingMuscles.CSharpInnoSetup.Example.CodeDll
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
        private const int MB_ICONINFORMATION = 0x40;

        public ExampleInstallation(DirectoryInfo source)
        {
            _source = source;
        }

        //AppName=My Program
        //AppVersion=1.5
        //WizardStyle=modern
        //DefaultDirName={autopf}\My Program
        //DisableProgramGroupPage=yes
        //DisableWelcomePage=no
        //UninstallDisplayIcon={app}\MyProg.exe
        //OutputDir=userdocs:Inno Setup Examples Output
        public override string AppName => "My Program";
        public override string AppVersion => "1.5";
        public override WizardStyle WizardStyle => WizardStyle.Modern;
        public override DirectoryInfo DefaultDirName => new DirectoryInfo($"{__autopf}\\My Program");
        public override AutoTriad DisableProgramGroupPage => AutoTriad.Yes;
        public override bool DisableWelcomePage => false;
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
                    //Source: "MyProg.exe"; DestDir: "{app}"
                    //Source: "MyProg.chm"; DestDir: "{app}"
                    //Source: "Readme.txt"; DestDir: "{app}"; Flags: isreadme
                    //Source: "MyDll.dll"; DestDir: "{app}"
                    builder().Source(_source, "MyProg.exe").Destination(__app).Build(),
                    builder().Source(_source, "MyProg.chm").Destination(__app).Build(),
                    builder().Source(_source, "Readme.txt").Destination(__app).Flags(FileFlags.IsReadme).Build(),
                    builder().Source(_source, "MyDll.dll").Destination(__app).Build(),
                };
            });
        };

        //function MessageBox(hWnd: Integer; lpText, lpCaption: String; uType: Cardinal): Integer;
        //external 'MessageBoxW@user32.dll stdcall';
        [DllImport("user32.dll", EntryPoint = "MessageBoxW", CallingConvention = CallingConvention.StdCall)]
        private static extern int MessageBox(int hWnd, string text, string caption, Cardinal uType);

        //procedure MyDllFuncSetup(hWnd: Integer; lpText, lpCaption: AnsiString; uType: Cardinal);
        //external 'MyDllFunc@files:MyDll.dll stdcall setuponly';
        [DllImport("files:MyDll.dll", EntryPoint = "MyDllFunc", CallingConvention = CallingConvention.StdCall)]
        [ExternalSymbolOptions(ExternalSymbolOption.SetupOnly)]
        private static extern void MyDllFuncSetup(int hWnd, AnsiString text, AnsiString caption, Cardinal uType);

        //procedure MyDllFuncUninstall(hWnd: Integer; lpText, lpCaption: AnsiString; uType: Cardinal);
        //external 'MyDllFunc@{app}\MyDll.dll stdcall uninstallonly';
        [DllImport("{app}\\MyDll.dll", EntryPoint = "MyDllFunc", CallingConvention = CallingConvention.StdCall)]
        [ExternalSymbolOptions(ExternalSymbolOption.UninstallOnly)]
        private static extern void MyDllFuncUninstall(int hWnd, AnsiString text, AnsiString caption, Cardinal uType);

        //procedure DelayLoadedFunc(hWnd: Integer; lpText, lpCaption: AnsiString; uType: Cardinal);
        //external 'DllFunc@DllWhichMightNotExist.dll stdcall delayload';
        [DllImport("DllWhichMightNotExist.dll", EntryPoint = "DllFunc", CallingConvention = CallingConvention.StdCall)]
        [ExternalSymbolOptions(ExternalSymbolOption.DelayLoad)]
        private static extern void DelayLoadedFunc(int hWnd, AnsiString text, AnsiString caption, Cardinal uType);

        //function NextButtonClick(CurPage: Integer): Boolean;
        //var
        //    hWnd: Integer;
        //begin
        //    if CurPage = wpWelcome then begin
        //        hWnd := StrToInt(ExpandConstant('{wizardhwnd}'));

        //        MessageBox(hWnd, 'Hello from Windows API function', 'MessageBoxA', MB_OK or MB_ICONINFORMATION);
        //        MyDllFuncSetup(hWnd, 'Hello from custom DLL function', 'MyDllFunc', MB_OK or MB_ICONINFORMATION);

        //        try
        //            // If this DLL does not exist (it shouldn't), an exception will be raised. Press F9 to continue.
        //            DelayLoadedFunc(hWnd, 'Hello from delay loaded function', 'DllFunc', MB_OK or MB_ICONINFORMATION);
        //        except
        //            // <Handle missing dll here>
        //        end;
        //    end;
        //    Result := True;
        //end;
        public override bool NextButtonClick(int curPageId)
        {
            if(curPageId == PageID.Welcome)
            {
                var hWnd = (int)StrToInt(ExpandConstant(__wizardhwnd));
                MessageBox(hWnd, "Hello from Windows API function", "MessageBoxA", MB.Ok | MB.IconInformation);

                try
                {
                    // If this DLL does not exist (it shouldn't), an exception will be raised. Press F9 to continue.
                    DelayLoadedFunc(hWnd, "Hello from delay loaded function", "DllFunc", MB.Ok | MB.IconInformation);
                }
                catch
                {
                    // <Handle missing dll here>
                }
            }

            return true;
        }

        //procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
        //begin
        //    // Call our function just before the actual uninstall process begins.
        //    if CurUninstallStep = usUninstall then begin
        //        MyDllFuncUninstall(0, 'Hello from custom DLL function', 'MyDllFunc', MB_OK or MB_ICONINFORMATION);

        //        // Now that we're finished with it, unload MyDll.dll from memory.
        //        // We have to do this so that the uninstaller will be able to remove the DLL and the {app} directory.
        //        UnloadDLL(ExpandConstant('{app}\MyDll.dll'));
        //    end;
        //end;
        public override void CurUninstallStepChanged(TUninstallStep curUninstallStep)
        {
            if(curUninstallStep == TUninstallStep.Uninstall)
            {
                MyDllFuncUninstall(0, "Hello from custom DLL function", "MyDllFunc", MB.Ok | MB.IconInformation);

                // Now that we're finished with it, unload MyDll.dll from memory.
                // We have to do this so that the uninstaller will be able to remove the DLL and the {app} directory.
                UnloadDLL(ExpandConstant($"{__app}\\MyDll.dll"));
            }
        }

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        [ExternalSymbolOptions(ExternalSymbolOption.DelayLoad)]
        private static extern uint SetTimer(uint hWnd, uint nIDEvent, uint uElapse, uint lpTimerFunc);

        private int TimerCount;

        //procedure MyTimerProc(Arg1, Arg2, Arg3, Arg4: Longword);
        //begin
        //    Inc(TimerCount);
        //    WizardForm.BeveledLabel.Caption := ' Timer! ' + IntToStr(TimerCount) + ' ';
        //    WizardForm.BeveledLabel.Visible := True;
        //end;
        private void MyTimerProc(uint Arg1, uint Arg2, uint Arg3, uint Arg4)
        {
            TimerCount++;
            WizardForm.BeveledLabel.Caption = " Timer! " + IntToStr(TimerCount) + " ";
            WizardForm.BeveledLabel.Visible = true;
        }

        //procedure InitializeWizard;
        //begin
        //    SetTimer(0, 0, 1000, CreateCallback(@MyTimerProc));
        //end;
        public override void InitializeWizard()
        {
            SetTimer(0, 0, 1000, CreateCallback(nameof(MyTimerProc)));
        }
    }
}
