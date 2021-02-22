
namespace CodingMuscles.CSharpInnoSetup.Converter
{
    /// <summary>
    /// Converts a <see cref="bool"/> type to a yes/no string
    /// </summary>
    internal class BoolToStringConverter : ToStringConverter<bool>
    {
        /// <inheritdoc/>
        protected override string Convert(bool value)
        {
            return value ? "yes" : "no";
        }
    }
}
