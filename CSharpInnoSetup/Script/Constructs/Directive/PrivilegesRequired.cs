
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Rights required by installer at startup
    /// </summary>
    public enum PrivilegesRequired
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_privilegesrequired">Documentation</a>
        /// </summary>
        [Alias("admin")]
        Admin,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_privilegesrequired">Documentation</a>
        /// </summary>
        [Alias("lowest")]
        Lowest
    }
}
