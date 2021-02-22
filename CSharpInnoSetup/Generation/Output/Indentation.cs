
namespace CodingMuscles.CSharpInnoSetup.Generation.Output
{
    /// <summary>
    /// Indentation levels
    /// </summary>
    internal enum Indentation
    {
        /// <summary>
        /// Use no indentation
        /// </summary>
        None,

        /// <summary>
        /// The current indentation should be used
        /// </summary>
        Current,

        /// <summary>
        /// The indentation should be increased one level
        /// </summary>
        Increase,

        /// <summary>
        /// The indentation should be decreased one level
        /// </summary>
        Decrease
    }
}
