
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// The Pascal "array of ..." type
    /// </summary>
    /// <typeparam name="T">The element type</typeparam>
    [Alias("array of {0}")]
    [BuiltInSymbol]
    public sealed class ArrayOf<T>
    {
        /// <summary>Convenience operator</summary>
        public static implicit operator T[](ArrayOf<T> _) => default;
        /// <summary>Convenience operator</summary>
        public static implicit operator ArrayOf<T>(T[] _) => default;

        /// <summary>
        /// Initializes a new <see cref="ArrayOf{T}"/>
        /// </summary>
        public ArrayOf()
        {
        }
    }
}
