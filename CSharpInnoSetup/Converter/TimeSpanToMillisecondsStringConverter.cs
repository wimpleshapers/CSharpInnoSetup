
using System;
using System.Globalization;

namespace CodingMuscles.CSharpInnoSetup.Converter
{
    /// <summary>
    /// Converts a <see cref="TimeSpan"/> to a string containing the total milliseconds
    /// </summary>
    internal class TimeSpanToMillisecondsStringConverter : ToStringConverter<TimeSpan>
    {
        /// <inheritdoc/>
        protected override string Convert(TimeSpan value)
        {
            return value.TotalMilliseconds.ToString(CultureInfo.InvariantCulture);
        }
    }
}
