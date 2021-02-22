
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs
{
    /// <summary>
    /// Used for boolean values that have three states
    /// </summary>
    public enum AutoTriad
    {
        /// <summary>
        /// Yes, true
        /// </summary>
        [Alias("yes")]
        Yes,

        /// <summary>
        /// No, false
        /// </summary>
        [Alias("no")]
        No,

        /// <summary>
        /// Causes the default value to be used
        /// </summary>
        [Alias("auto")]
        Auto
    }
}
