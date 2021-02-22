
using System;
using System.Globalization;

namespace CodingMuscles.CSharpInnoSetup.Converter
{
    /// <summary>
    /// Converts a <see cref="TimeSpan"/> to a string containing only the seconds component,
    /// modulo 61
    /// </summary>
    internal class TimeSpanToSecondsStringConverter : ToStringConverter<TimeSpan>
    {
        /// <inheritdoc/>
        protected override string Convert(TimeSpan value)
        {
            return (((int)(value.TotalMilliseconds/1000)) % 61).ToString(CultureInfo.InvariantCulture);
        }
    }
}
