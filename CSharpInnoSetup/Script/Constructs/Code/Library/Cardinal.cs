
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// The Pascal Cardinal type
    /// </summary>
    [BuiltInSymbol]
    public sealed class Cardinal
    {
        /// <summary>Convenience operator</summary>
        public static implicit operator uint(Cardinal _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator Cardinal(uint _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator Cardinal(int _) => default;

        private Cardinal()
        {

        }
    }
}
