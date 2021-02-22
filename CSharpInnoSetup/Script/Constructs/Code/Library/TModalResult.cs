
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Pascal TModalResult type
    /// </summary>
    [BuiltInSymbol]
    [GlobalNamespace]
    public sealed class TModalResult
    {
        /// <summary>
        /// Inno <a href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Soure Code</a>
        /// </summary>
        [Alias("mrNone")]
        public static TModalResult None;

        /// <summary>
        /// Inno <a href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Soure Code</a>
        /// </summary>
        [Alias("mrOk")]
        public static TModalResult Ok;

        /// <summary>
        /// Inno <a href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Soure Code</a>
        /// </summary>
        [Alias("mrCancel")]
        public static TModalResult Cancel;

        /// <summary>
        /// Inno <a href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Soure Code</a>
        /// </summary>
        [Alias("mrAbort")]
        public static TModalResult Abort;

        /// <summary>
        /// Inno <a href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Soure Code</a>
        /// </summary>
        [Alias("mrRetry")]
        public static TModalResult Retry;

        /// <summary>
        /// Inno <a href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Soure Code</a>
        /// </summary>
        [Alias("mrIgnore")]
        public static TModalResult Ignore;

        /// <summary>
        /// Inno <a href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Soure Code</a>
        /// </summary>
        [Alias("mrYes")]
        public static TModalResult Yes;

        /// <summary>
        /// Inno <a href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Soure Code</a>
        /// </summary>
        [Alias("mrNo")]
        public static TModalResult No;

        /// <summary>
        /// Inno <a href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Soure Code</a>
        /// </summary>
        [Alias("mrAll")]
        public static TModalResult All;

        /// <summary>
        /// Inno <a href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Soure Code</a>
        /// </summary>
        [Alias("mrNoToAll")]
        public static TModalResult NoToAll;

        /// <summary>
        /// Inno <a href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Soure Code</a>
        /// </summary>
        [Alias("mrYesToAll")]
        public static TModalResult YesToAll;

        /// <summary>Convenience operator</summary>
        public static implicit operator int(TModalResult _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator TModalResult(int _) => default;

        private TModalResult()
        {
        }
    }
}
