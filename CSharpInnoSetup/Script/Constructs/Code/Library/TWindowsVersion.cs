
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public struct TWindowsVersion
    {
        /// <summary>
        /// Major version number
        /// </summary>
        public uint Major;
        /// <summary>
        /// Minor version number
        /// </summary>
        public uint Minor;
        /// <summary>
        /// Build number
        /// </summary>
        public uint Build;
        /// <summary>
        /// Major version number of service pack
        /// </summary>
        public uint SerivcePackMajor;
        /// <summary>
        /// Minor version number of service pack
        /// </summary>
        public uint ServicePackMinor;
        /// <summary>
        /// True if an NT-based platform
        /// </summary>
        public bool NTPlatform;
        /// <summary>
        /// Product type <see cref="ProductType"/>
        /// </summary>
        public byte ProductType;
        /// <summary>
        /// Product suites <see cref="SuiteMask"/>
        /// </summary>
        public ushort SuiteMask;
    }
}
