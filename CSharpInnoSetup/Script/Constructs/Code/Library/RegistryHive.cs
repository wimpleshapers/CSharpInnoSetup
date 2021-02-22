
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=registrysection">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    [GlobalNamespace]
    public enum RegistryHive
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=registrysection">Documentation</a>
        /// </summary>
        [Alias("HKCU")]
        HKEY_CURRENT_USER,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=registrysection">Documentation</a>
        /// </summary>
        [Alias("HKLM")]
        HKEY_LOCAL_MACHINE,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=registrysection">Documentation</a>
        /// </summary>
        [Alias("HKCR")]
        HKEY_CLASSES_ROOT,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=registrysection">Documentation</a>
        /// </summary>
        [Alias("HKU")]
        HKEY_USERS,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=registrysection">Documentation</a>
        /// </summary>
        [Alias("HKCC")]
        HKEY_CURRENT_CONFIG,

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=registrysection">Documentation</a>
        /// </summary>
        [Alias("HKA")]
        HKA
    }
}
