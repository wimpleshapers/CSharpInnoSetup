
using CodingMuscles.CSharpInnoSetup.Script;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library;

namespace CodingMuscles.CSharpInnoSetup
{
    public partial class Installation
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual bool BackButtonClick(int curPageId) => false;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual void CancelButtonClick(int curPageId, ref bool cancel, ref bool confirm) { }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual bool CheckPassword(string password) => false;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual bool CheckSerial(string serial) => false;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual void CurInstallProgressChanged(int curProgress, int maxProgress) { }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual void CurPageChanged(int curPageId) { }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual void CurStepChanged(TSetupStep curStep) { }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual void CurUninstallStepChanged(TUninstallStep curUninstallStep) { }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual void DeinitializeSetup() { }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual void DeinitializeUninstall() { }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual int GetCustomSetupExitCode() => 0;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        [Alias("this_InitializeSetup")]
        public virtual bool InitializeSetup() => true;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        [Alias("this_InitializeUninstall")]
        public virtual bool InitializeUninstall() => true;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual void InitializeUninstallProgressForm() { }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual void InitializeWizard() { }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual bool NeedRestart() => false;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual bool NextButtonClick(int curPageId) => false;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual string PrepareToInstall(ref bool needsRestart) => null;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual void RegisterExtraCloseApplicationsResources() { }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual void RegisterPreviousData(int previousDataKey) { }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual bool ShouldSkipPage(int pageId) => false;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual bool UninstallNeedRestart() => false;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_scriptevents.htm">Documentation</a>
        /// </summary>
        [EventHandler]
        public virtual string UpdateReadyMemo(
            string space,
            string newLine,
            string memoUserInfoInfo,
            string memoDirInfo,
            string memoTypeInfo,
            string memoComponentsInfo,
            string memoGroupInfo,
            string memoTasksInfo) => null;
    }
}
