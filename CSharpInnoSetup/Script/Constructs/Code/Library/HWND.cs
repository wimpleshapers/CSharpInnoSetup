
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// The Pascal HWND type
    /// </summary>
    [BuiltInSymbol]
    public sealed class HWND
    {
        /// <summary>Convenience operator</summary>
        public static implicit operator uint(HWND _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator HWND(uint _) => default;

        private HWND()
        {
        }
    }
}
