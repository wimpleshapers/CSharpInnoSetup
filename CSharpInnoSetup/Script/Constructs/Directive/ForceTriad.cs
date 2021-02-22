
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Yes/no enumeration that includes a value for 'force'
    /// </summary>
    public enum ForceTriad
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
        /// Perform operation forcefully
        /// </summary>
        [Alias("force")]
        Force
    }
}
