
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_getwindowsversionex">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    [GlobalNamespace]
    public sealed class ProductType
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_getwindowsversionex">Documentation</a>
        /// </summary>
        [Alias("VER_NT_WORKSTATION")]
        public static byte Workstation;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_getwindowsversionex">Documentation</a>
        /// </summary>
        [Alias("VER_NT_DOMAIN_CONTROLLER")]
        public static byte DomainController;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=isxfunc_getwindowsversionex">Documentation</a>
        /// </summary>
        [Alias("VER_NT_SERVER")]
        public static byte Server;

        private ProductType()
        {
        }
    }
}
