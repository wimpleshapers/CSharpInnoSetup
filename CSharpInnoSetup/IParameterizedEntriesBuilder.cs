
namespace CodingMuscles.CSharpInnoSetup
{
    /// <summary>
    /// Builds parameterized (name: value;) entries in the setup script
    /// </summary>
    public interface IParameterizedEntriesBuilder
    {
        /// <summary>
        /// Retrieves a reference to the languages builder
        /// </summary>
        ILanguagesBuilder LanguagesBuilder { get; }
    }
}
