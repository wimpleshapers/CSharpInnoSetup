
using System.Globalization;

namespace CodingMuscles.CSharpInnoSetup.Converter
{
    /// <summary>
    /// Converts the <see cref="CultureInfo.LCID"/> property of a <see cref="CultureInfo"/> 
    /// to a 4-position hexidecimally formatted string
    /// </summary>
    internal class CultureInfoToLcidStringConverter : ToStringConverter<CultureInfo>
    {
        /// <inheritdoc/>
        protected override string Convert(CultureInfo cultureInfo)
        {
            return $"${cultureInfo.LCID:X4}";
        }
    }
}
