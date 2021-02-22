
using CodingMuscles.CSharpInnoSetup.Example;
using CodingMuscles.CSharpInnoSetup.Script.Constructs;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CodingMuscles.CSharpInnoSetup.ExampleCodeAutomation2
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
        private const string CLSID_ShellLink = "{00021401-0000-0000-C000-000000000046}";

        public ExampleInstallation(DirectoryInfo source)
        {
            _source = source;
        }

        //AppName=My Program
        //AppVersion=1.5
        //WizardStyle=modern
        //DisableWelcomePage=no
        //CreateAppDir=no
        //DisableProgramGroupPage=yes
        //DefaultGroupName=My Program
        //UninstallDisplayIcon={app}\MyProg.exe
        //OutputDir=userdocs:Inno Setup Examples Output
        public override string AppName => "My Program";
        public override string AppVersion => "1.5";
        public override WizardStyle WizardStyle => WizardStyle.Modern;
        public override bool DisableWelcomePage => false;
        public override bool CreateAppDir => false;
        public override AutoTriad DisableProgramGroupPage => AutoTriad.Yes;
        public override string DefaultGroupName => "My Program";
        public override IconFile UninstallDisplayIcon => new IconFile(new FileInfo($"{__app}\\MyProg.exe"));
        public override OutputDirectory OutputDir => OutputDirectory.UserDocs("Inno Setup Examples Output");

        //IShellLinkW = interface(IUnknown)
        //    '{000214F9-0000-0000-C000-000000000046}'
        //    procedure Dummy;
        //    procedure Dummy2;
        //    procedure Dummy3;
        //    function GetDescription(pszName: String; cchMaxName: Integer);
        //    function SetDescription(pszName: String);
        //    function GetWorkingDirectory(pszDir: String; cchMaxPath: Integer);
        //    function SetWorkingDirectory(pszDir: String);
        //    function GetArguments(pszArgs: String; cchMaxPath: Integer);
        //    function SetArguments(pszArgs: String);
        //    function GetHotkey(var pwHotkey: Word);
        //    function SetHotkey(wHotkey: Word);
        //    function GetShowCmd(out piShowCmd: Integer);
        //    function SetShowCmd(iShowCmd: Integer);
        //    function GetIconLocation(pszIconPath: String; cchIconPath: Integer; out piIcon: Integer);
        //    function SetIconLocation(pszIconPath: String; iIcon: Integer);
        //    function SetRelativePath(pszPathRel: String; dwReserved: DWORD);
        //    function Resolve(Wnd: HWND; fFlags: DWORD);
        //    function SetPath(pszFile: String);
        //end;
        [Guid("000214F9-0000-0000-C000-000000000046")]
        interface IShellLinkW : IUnknown
        {
            void Dummy();
            void Dummy2();
            void Dummy3();
            HResult GetDescription(string pszName, int cchMaxName);
            HResult SetDescription(string pszName);
            HResult GetWorkingDirectory(string pszDir, int cchMaxPath);
            HResult SetWorkingDirectory(string pszDir);
            HResult GetArguments(string pszArgs, int cchMaxPath);
            HResult SetArguments(string pszArgs);
            HResult GetHotkey(WORD pwHotkey);
            HResult SetHotkey(WORD wHotkey);
            HResult GetShowCmd(out int piShowCmd);
            HResult SetShowCmd(int iShowCmd);
            HResult GetIconLocation(string szIconPath, int cchIconPath, out int piIcon);
            HResult SetIconLocation(string pszIconPath, int iIcon);
            HResult SetRelativePath(string pszPathRel, DWORD dwReserved);
            HResult Resolve(HWND Wnd, DWORD fFlags);
            HResult SetPath(string pszFile);
        }

        //IPersist = interface(IUnknown)
        //    '{0000010C-0000-0000-C000-000000000046}'
        //    function GetClassID(var classID: TGUID);
        //end;
        [Guid("0000010C-0000-0000-C000-000000000046")]
        interface IPersist : IUnknown
        {
            HResult GetClassID(TGUID classID);
        }

        //IPersistFile = interface(IPersist)
        //    '{0000010B-0000-0000-C000-000000000046}'
        //    function IsDirty;
        //    function Load(pszFileName: String; dwMode: Longint);
        //    function Save(pszFileName: String; fRemember: BOOL);
        //    function SaveCompleted(pszFileName: String);
        //    function GetCurFile(out pszFileName: String);
        //end;
        [Guid("0000010B-0000-0000-C000-000000000046")]
        interface IPersistFile : IPersist
        {
            HResult IsDirty();
            HResult Load(string pszFileName, long dwMode);
            HResult Save(string pszFileName, bool fRemember /*BOOL*/);
            HResult SaveCompleted(string pszFileName);
            HResult GetCurFile(out string pszFileName);
        }

        //const
        //    CLSID_TaskScheduler = '{148BD52A-A2AB-11CE-B11F-00AA00530503}';
        //    CLSID_Task = '{148BD520-A2AB-11CE-B11F-00AA00530503}';
        //    IID_Task = '{148BD524-A2AB-11CE-B11F-00AA00530503}';
        //    TASK_TIME_TRIGGER_DAILY = 1;
        private const string CLSID_TaskScheduler = "{148BD52A-A2AB-11CE-B11F-00AA00530503}";
        private const string CLSID_Task = "{148BD520-A2AB-11CE-B11F-00AA00530503}";
        private const string IID_Task = "{148BD524-A2AB-11CE-B11F-00AA00530503}";
        private const int TASK_TIME_TRIGGER_DAILY = 1;

        //ITaskScheduler = interface(IUnknown)
        //    '{148BD527-A2AB-11CE-B11F-00AA00530503}'
        //    function SetTargetComputer(pwszComputer: String);
        //    function GetTargetComputer(out ppwszComputer: String);
        //    procedure Dummy;
        //    function Activate(pwszName: String; var riid: TGUID; out ppUnk: IUnknown);
        //    function Delete(pwszName: String);
        //    function NewWorkItem(pwszTaskName: String; var rclsid: TGUID; var riid: TGUID; out ppUnk: IUnknown);
        //    procedure Dummy2;
        //    function IsOfType(pwszName: String; var riid: TGUID);
        //end;
        [Guid("148BD527-A2AB-11CE-B11F-00AA00530503")]
        interface ITaskScheduler : IUnknown
        {
            HResult SetTargetComputer(string pwszComputer);
            HResult GetTargetComputer(out string ppwszComputer);
            void Dummy();
            HResult Activate(string pwszName, ref TGUID riid, IUnknown ppUnk);
            HResult Delete(string pwszName);
            HResult NewWorkItem(string pwszTaskName, ref TGUID rclsid, ref TGUID riid, out IUnknown ppUnk);
            void Dummy2();
            HResult IsOfType(string pwszName, ref TGUID riid);
        }

        struct TDaily
        {
            public WORD DaysInterval;
        }

        struct TWeekly
        {
            public WORD WeeksInterval;
            public WORD rgfDaysOfTheWeek;
        }

        struct TMonthyDate
        {
            public DWORD rgfDays;
            public WORD rgfMonths;
        }

        struct TMonthlyDow
        {
            public WORD wWhichWeek;
            public WORD rgfDaysOfTheWeek;
            public WORD rgfMonths;
        }

        // ROPS doesn't support unions, replace this with the type you need and adjust padding (end size has to be 48).
        struct TTriggerTypeUnion
        {
            public TDaily Daily;
            public WORD Pad1;
            public WORD Pad2;
            public WORD Pad3;
        }

        struct TTaskTrigger
        {
            public WORD cbTriggerSize;
            public WORD Reserved1;
            public WORD wBeginYear;
            public WORD wBeginMonth;
            public WORD wBeginDay;
            public WORD wEndYear;
            public WORD wEndMonth;
            public WORD wEndDay;
            public WORD wStartHour;
            public WORD wStartMinute;
            public DWORD MinutesDuration;
            public DWORD MinutesInterval;
            public DWORD rgFlags;
            public DWORD TriggerType;
            public TTriggerTypeUnion Type_;
            public WORD Reserved2;
            public WORD wRandomMinutesInterval;
        }

        [Guid("148BD52B-A2AB-11CE-B11F-00AA00530503")]
        interface ITaskTrigger : IUnknown
        {
            HResult SetTrigger(ref TTaskTrigger pTrigger);
            HResult GetTrigger(ref TTaskTrigger pTrigger);
            HResult GetTriggerString(ref string ppwszTrigger);
        }

        [Guid("A6B952F0-A4B1-11D0-997D-00AA006887EC")]
        interface IScheduledWorkItem : IUnknown
        {
            HResult CreateTrigger(out WORD piNewTrigger, out ITaskTrigger ppTrigger);
            HResult DeleteTrigger(WORD iTrigger);
            HResult GetTriggerCount(out WORD pwCount);
            HResult GetTrigger(WORD iTrigger, ref ITaskTrigger ppTrigger);
            HResult GetTriggerString(WORD iTrigger, out string ppwszTrigger);
            void Dummy();
            void Dummy2();
            HResult SetIdleWait(WORD wIdleMinutes, WORD wDeadlineMinutes);
            HResult GetIdleWait(out WORD pwIdleMinutes, out WORD pwDeadlineMinutes);
            HResult Run();
            HResult Terminate();
            HResult EditWorkItem(HWND hParent, DWORD dwReserved);
            void Dummy3();
            HResult GetStatus(out HResult phrStatus);
            HResult GetExitCode(out DWORD pdwExitCode);
            HResult SetComment(string pwszComment);
            HResult GetComment(out string ppwszComment);
            HResult SetCreator(string pwszCreator);
            HResult GetCreator(out string ppwszCreator);
            HResult SetWorkItemData(WORD cbData, ref byte rgbData);
            HResult GetWorkItemData(out WORD pcbData, out byte prgbData);
            HResult SetErrorRetryCount(WORD wRetryCount);
            HResult GetErrorRetryCount(out WORD pwRetryCount);
            HResult SetErrorRetryInterval(WORD wRetryInterval);
            HResult GetErrorRetryInterval(out WORD pwRetryInterval);
            HResult SetFlags(DWORD dwFlags);
            HResult GetFlags(out DWORD pdwFlags);
            HResult SetAccountInformation(string pwszAccountName, string pwszPassword);
            HResult GetAccountInformation(out string ppwszAccountName);
        }

        [Guid("148BD524-A2AB-11CE-B11F-00AA00530503")]
        interface ITask : IScheduledWorkItem
        {
            HResult SetApplicationName(string pwszApplicationName);
            HResult GetApplicationName(out string ppwszApplicationName);
            HResult SetParameters(string pwszParameters);
            HResult GetParameters(out string ppwszParameters);
            HResult SetWorkingDirectory(string pwszWorkingDirectory);
            HResult GetWorkingDirectory(out string ppwszWorkingDirectory);
            HResult SetPriority(DWORD dwPriority);
            HResult GetPriority(out DWORD pdwPriority);
            HResult SetTaskFlags(DWORD dwFlags);
            HResult GetTaskFlags(out DWORD pdwFlags);
            HResult SetMaxRunTime(DWORD dwMaxRunTimeMS);
            HResult GetMaxRunTime(out DWORD pdwMaxRunTimeMS);
        }

        //procedure CreateButton(ALeft, ATop: Integer; ACaption: String; ANotifyEvent: TNotifyEvent);
        //begin
        //    with TButton.Create(WizardForm) do begin
        //        Left := ALeft;
        //        Top := ATop;
        //        Width := (WizardForm.CancelButton.Width*3)/2;
        //        Height := WizardForm.CancelButton.Height;
        //        Caption := ACaption;
        //        OnClick := ANotifyEvent;
        //        Parent := WizardForm.WelcomePage;
        //    end;
        //end;
        void CreateButton(int ALeft, int ATop, string ACaption, TNotifyEvent ANotifyEvent)
        {
            var button = new TButton(WizardForm);
            button.Left = ALeft;
            button.Top = ATop;
            button.Width = WizardForm.CancelButton.Width * 3 / 2;
            button.Height = WizardForm.CancelButton.Height;
            button.Caption = ACaption;
            button.Parent = WizardForm.WelcomePage;
            button.OnClick += ANotifyEvent;
        }

        //procedure InitializeWizard();
        //var
        //    Left, LeftInc, Top, TopInc: Integer;
        //begin
        //    Left := WizardForm.WelcomeLabel2.Left;
        //    LeftInc := (WizardForm.CancelButton.Width*3)/2 + ScaleX(8);
        //    TopInc := WizardForm.CancelButton.Height + ScaleY(8);
        //    Top := WizardForm.WelcomeLabel2.Top + WizardForm.WelcomeLabel2.Height - 4*TopInc;

        //    CreateButton(Left, Top, '&IShellLink...', @IShellLinkButtonOnClick);
        //    Top := Top + TopInc;
        //    CreateButton(Left, Top, '&ITaskScheduler...', @ITaskSchedulerButtonOnClick);
        //end;
        public override void InitializeWizard()
        {
            var Left = WizardForm.WelcomeLabel2.Left;
            var TopInc = WizardForm.CancelButton.Height + ScaleY(8);
            var Top = WizardForm.WelcomeLabel2.Top + WizardForm.WelcomeLabel2.Height - 4 * TopInc;

            CreateButton(Left, Top, "&IShellLink...", IShellLinkButtonOnClick);
            Top += TopInc;
            CreateButton(Left, Top, "&ITaskScheduler...", ITaskSchedulerButtonOnClick);
        }

        //procedure ITaskSchedulerButtonOnClick(Sender: TObject);
        //var
        //    Obj, Obj2: IUnknown;
        //    TaskScheduler: ITaskScheduler;
        //    G1, G2: TGUID;
        //    Task: ITask;
        //    iNewTrigger;
        //    TaskTrigger: ITaskTrigger;
        //    TaskTrigger2: TTaskTrigger;
        //    PF: IPersistFile;
        //begin
        //    { Create the main TaskScheduler COM Automation object }
        //    Obj := CreateComObject(StringToGuid(CLSID_TaskScheduler));

        //    { Create the Task COM automation object }
        //    TaskScheduler := ITaskScheduler(Obj);
        //    G1 := StringToGuid(CLSID_Task);
        //    G2 := StringToGuid(IID_Task);
        //    //This will throw an exception if the task already exists
        //    OleCheck(TaskScheduler.NewWorkItem('CodeAutomation2 Test', G1, G2, Obj2));

        //    { Set the task properties }
        //    Task := ITask(Obj2);
        //    OleCheck(Task.SetComment('CodeAutomation2 Test Comment'));
        //    OleCheck(Task.SetApplicationName(ExpandConstant('{srcexe}')));

        //    { Set the task account information }
        //    //Uncomment the following and provide actual user info to get a runnable task
        //    //OleCheck(Task.SetAccountInformation('username', 'password'));

        //    { Create the TaskTrigger COM automation object }
        //    OleCheck(Task.CreateTrigger(iNewTrigger, TaskTrigger));

        //    { Set the task trigger properties }
        //    with TaskTrigger2 do begin
        //        cbTriggerSize := SizeOf(TaskTrigger2);
        //        wBeginYear := 2009;
        //        wBeginMonth := 10;
        //        wBeginDay := 1;
        //        wStartHour := 12;
        //        TriggerType := TASK_TIME_TRIGGER_DAILY;
        //        Type_.Daily.DaysInterval := 1;
        //    end;
        //    OleCheck(TaskTrigger.SetTrigger(TaskTrigger2));

        //    { Save the task }
        //    PF := IPersistFile(Obj2);
        //    OleCheck(PF.Save('', True));

        //    MsgBox('Created a daily task named named ''CodeAutomation2 Test''.' + #13#13 + 'Note: Account information not set so the task won''t actually run, uncomment the SetAccountInfo call and provide actual user info to get a runnable task.', mbInformation, mb_Ok);
        //end;
        void ITaskSchedulerButtonOnClick(TObject Sender)
        {
            // Create the main TaskScheduler COM Automation object
            var Obj = CreateComObject(StringToGuid(CLSID_TaskScheduler));

            // Create the Task COM automation object
            var TaskScheduler = (ITaskScheduler)Obj;
            var G1 = StringToGuid(CLSID_Task);
            var G2 = StringToGuid(IID_Task);
            //This will throw an exception if the task already exists
            OleCheck(TaskScheduler.NewWorkItem("CodeAutomation2 Test", ref G1, ref G2, out var Obj2));

            // Set the task properties
            var Task = (ITask)Obj2; // ITask(Obj2);
            OleCheck(Task.SetComment("CodeAutomation2 Test Comment"));
            OleCheck(Task.SetApplicationName(ExpandConstant(__srcexe)));

            // Set the task account information
            OleCheck(Task.SetAccountInformation("username", "password"));

            // Create the TaskTrigger COM automation object
            OleCheck(Task.CreateTrigger(out WORD iNewTrigger, out ITaskTrigger TaskTrigger));

            // Set the task trigger properties
            var TaskTrigger2 = new TTaskTrigger();
            TaskTrigger2.cbTriggerSize = (WORD)SizeOf(TaskTrigger2);
            TaskTrigger2.wBeginYear = 2009;
            TaskTrigger2.wBeginMonth = 10;
            TaskTrigger2.wBeginDay = 1;
            TaskTrigger2.wStartHour = 12;
            TaskTrigger2.TriggerType = TASK_TIME_TRIGGER_DAILY;
            TaskTrigger2.Type_.Daily.DaysInterval = 1;

            OleCheck(TaskTrigger.SetTrigger(ref TaskTrigger2));

            // Save the task
            var PF = (IPersistFile)Obj2;
            OleCheck(PF.Save("", true));

            MsgBox("Created a daily task named named 'CodeAutomation2 Test'." + "\r\r" + "Note: Account information not set so the task won't actually run, uncomment the SetAccountInfo call and provide actual user info to get a runnable task.", 
                TMsgBoxType.Information, 
                MB.Ok);
        }

        //procedure IShellLinkButtonOnClick(Sender: TObject);
        //var
        //    Obj: IUnknown;
        //    SL: IShellLinkW;
        //    PF: IPersistFile;
        //begin
        //    { Create the main ShellLink COM Automation object }
        //    Obj := CreateComObject(StringToGuid(CLSID_ShellLink));

        //    { Set the shortcut properties }
        //    SL := IShellLinkW(Obj);
        //    OleCheck(SL.SetPath(ExpandConstant('{srcexe}')));
        //    OleCheck(SL.SetArguments(''));
        //    OleCheck(SL.SetShowCmd(SW_SHOWNORMAL));

        //    { Save the shortcut }
        //    PF := IPersistFile(Obj);
        //    OleCheck(PF.Save(ExpandConstant('{autodesktop}\CodeAutomation2 Test.lnk'), True));

        //    MsgBox('Saved a shortcut named ''CodeAutomation2 Test'' on the common desktop.', mbInformation, mb_Ok);
        //end;
        void IShellLinkButtonOnClick(TObject Sender)
        {
            // Create the main ShellLink COM Automation object
            var Obj = CreateComObject(StringToGuid(CLSID_ShellLink));

            // Set the shortcut properties
            var SL = (IShellLinkW)Obj;
            OleCheck(SL.SetPath(ExpandConstant(__srcexe)));
            OleCheck(SL.SetArguments(""));
            OleCheck(SL.SetShowCmd(ShowWindow.Normal));

            // Save the shortcut
            var PF = (IPersistFile)Obj;
            OleCheck(PF.Save(ExpandConstant($"{__autodesktop}\\CodeAutomation2 Test.lnk"), true));

            MsgBox("Saved a shortcut named 'CodeAutomation2 Test' on the common desktop.", TMsgBoxType.Information, MB.Ok);
        }
    }
}
