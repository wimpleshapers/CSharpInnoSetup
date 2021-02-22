
using System.Collections;
using System.Linq;

namespace CodingMuscles.CSharpInnoSetup.Converter
{
    /// <summary>
    /// Converts an enumeration of arbitrary objects into a comma-separated string using
    /// the <see cref="object.ToString"/> method of each object.
    /// </summary>
    internal class EnumerableToCommaSeparatedStringConverter : ToStringConverter<IEnumerable>
    {
        /// <inheritdoc/>
        protected override string Convert(IEnumerable enumerable)
        {
            return string.Join(", ", enumerable.Cast<object>().Select(e => e.ToString()));
        }
    }
}
