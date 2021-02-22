
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// The Pascal HResult type
    /// </summary>
    [BuiltInSymbol]
    public sealed class HResult
    {
        /// <summary>Convenience operator</summary>
        public static implicit operator long(HResult _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator HResult(long _) => default;

        private HResult()
        {
        }
    }
}
