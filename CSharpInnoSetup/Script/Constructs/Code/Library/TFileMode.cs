
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno <see href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Documentation</see>
    /// </summary>
    [BuiltInSymbol]
    [GlobalNamespace]
    public sealed class TFileMode
    {
        /// <summary>
        /// Inno <see href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Documentation</see>
        /// </summary>
        [Alias("fmCreate")]
        public static readonly TFileMode Create = default;

        /// <summary>
        /// Inno <see href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Documentation</see>
        /// </summary>
        [Alias("fmOpenRead")]
        public static readonly TFileMode OpenRead = default;

        /// <summary>
        /// Inno <see href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Documentation</see>
        /// </summary>
        [Alias("fmOpenWrite")]
        public static readonly TFileMode OpenWrite = default;

        /// <summary>
        /// Inno <see href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Documentation</see>
        /// </summary>
        [Alias("fmOpenReadWrite")]
        public static readonly TFileMode OpenReadWrite = default;

        /// <summary>Convenience operator</summary>
        public static implicit operator TFileMode(ushort _) => default;

        private TFileMode()
        {
        }
    }
}
