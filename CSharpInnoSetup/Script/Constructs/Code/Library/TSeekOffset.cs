
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno <see href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Documentation</see>
    /// </summary>
    [BuiltInSymbol]
    [GlobalNamespace]
    public sealed class TSeekOffset
    {
        /// <summary>
        /// Inno <see href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Documentation</see>
        /// </summary>
        [Alias("soFromBeginning")]
        public static readonly TSeekOffset Beginning = default;

        /// <summary>
        /// Inno <see href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Documentation</see>
        /// </summary>
        [Alias("soFromCurrent")]
        public static readonly TSeekOffset Current = default;

        /// <summary>
        /// Inno <see href="https://github.com/KngStr/Inno-All-in-One-Setup/blob/master/IsPack_Restools/Inno_ISCmplr_Setup/InnoSetup_Unicode/MiniVCL/Support%20Classes.txt">Documentation</see>
        /// </summary>
        [Alias("soFromEnd")]
        public static readonly TSeekOffset End = default;

        /// <summary>Convenience operator</summary>
        public static implicit operator TSeekOffset(ushort _) => default;

        private TSeekOffset()
        {
        }
    }
}
