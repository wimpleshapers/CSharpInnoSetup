
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;

namespace CodingMuscles.CSharpInnoSetup
{
    /// <summary>
    /// Builds a collection of <see cref="Language"/> objects for the Inno Setup script [Languages] section
    /// </summary>
    public interface ILanguagesBuilder
    {
        /// <summary>
        /// Allows entries of the [Languages] section to be specified
        /// </summary>
        /// <typeparam name="TLanguages">The type of object containing the languages</typeparam>
        /// <param name="languages">A delegate that returns a type whose properties are the <see cref="Language"/> entries</param>
        /// <returns>A builder for specifying sections that have a language dependency</returns>
        ILanguageDependentBuilder<TLanguages> AddLanguages<TLanguages>(Func<Func<Language.Builder>, TLanguages> languages);
    }
}
