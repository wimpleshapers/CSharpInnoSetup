
using System;
using System.Globalization;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Represents the Windows version plus a service pack level
    /// </summary>
    public class WindowsVersion
    {
        private readonly string _version;

        /// <summary>
        /// Initializes a new <see cref="WindowsVersion"/>
        /// </summary>
        /// <param name="version">The Windows version</param>
        /// <param name="servicePack">The service pack level</param>
        public WindowsVersion(Version version, uint? servicePack = null)
        {
            _version = version.ToString();

            if(servicePack.HasValue)
            {
                _version += $"sp{Convert.ToString(servicePack.Value, CultureInfo.InvariantCulture)}";
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _version;
        }
    }
}
