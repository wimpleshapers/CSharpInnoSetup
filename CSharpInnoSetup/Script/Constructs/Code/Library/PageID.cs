
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptevents">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    [GlobalNamespace]
    public sealed class PageID
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptevents">Documentation</a>
        /// </summary>
        [Alias("wpWelcome")]
        public static int Welcome;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptevents">Documentation</a>
        /// </summary>
        [Alias("wpLicense")]
        public static int License;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptevents">Documentation</a>
        /// </summary>
        [Alias("wpPassword")]
        public static int Password;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptevents">Documentation</a>
        /// </summary>
        [Alias("wpInfoBefore")]
        public static int InfoBefore;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptevents">Documentation</a>
        /// </summary>
        [Alias("wpUserInfo")]
        public static int UserInfo;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptevents">Documentation</a>
        /// </summary>
        [Alias("wpSelectDir")]
        public static int SelectDir;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptevents">Documentation</a>
        /// </summary>
        [Alias("wpSelectComponents")]
        public static int SelectComponents;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptevents">Documentation</a>
        /// </summary>
        [Alias("wpSelectProgramGroup")]
        public static int SelectProgramGroup;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptevents">Documentation</a>
        /// </summary>
        [Alias("wpSelectTasks")]
        public static int SelectTasks;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptevents">Documentation</a>
        /// </summary>
        [Alias("wpReady")]
        public static int Ready;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptevents">Documentation</a>
        /// </summary>
        [Alias("wpPreparing")]
        public static int Preparing;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptevents">Documentation</a>
        /// </summary>
        [Alias("wpInstalling")]
        public static int Installing;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptevents">Documentation</a>
        /// </summary>
        [Alias("wpInfoAfter")]
        public static int InfoAfter;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptevents">Documentation</a>
        /// </summary>
        [Alias("wpFinished")]
        public static int Finished;

        private PageID()
        {
        }
    }
}
