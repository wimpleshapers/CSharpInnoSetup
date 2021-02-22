
using System.Globalization;

namespace CodingMuscles.CSharpInnoSetup.Converter
{
    /// <summary>
    /// Converts the <see cref="TextInfo.IsRightToLeft"/> property of a <see cref="TextInfo"/> 
    /// to a yes/no value.
    /// </summary>
    internal class CultureInfoToRightToLeftStringConverter : ToStringConverter<CultureInfo>
    {
        /// <inheritdoc/>
        protected override string Convert(CultureInfo cultureInfo)
        {
            return cultureInfo.TextInfo.IsRightToLeft ? "yes" : "no";
        }
    }
}
