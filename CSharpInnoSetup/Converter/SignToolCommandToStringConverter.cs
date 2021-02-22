
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive;

namespace CodingMuscles.CSharpInnoSetup.Converter
{
    /// <summary>
    /// Converts a <see cref="SignToolCommand"/> to a <see cref="string"/>,
    /// providing/replacing substitution strings for the sake of convenience
    /// </summary>
    internal class SignToolCommandToStringConverter : ToStringConverter<SignToolCommand>
    {
        /// <inheritdoc/>
        protected override string Convert(SignToolCommand value)
        {
            return string.Format(value("{0}", "{1}").Replace("$", "$$").Replace("\"", "$q"), "$f", "$p");
        }
    }
}
