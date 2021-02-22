
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;

namespace CodingMuscles.CSharpInnoSetup
{
    /// <summary>
    /// Allows sections, like [Types], [CustomMessages], and [Messages], that have a language dependency, to be built
    /// </summary>
    /// <typeparam name="TLanguages">The type containing <see cref="Language"/> instances</typeparam>
    public interface ILanguageDependentBuilder<TLanguages>
    {
        /// <summary>
        /// Builds parts of the Inno Setup script that contain named, repeating entries, including 
        /// [Types], [CustomMessages], and [Messages]
        /// </summary>
        /// <typeparam name="TSetupTypes">The type containing <see cref="SetupType"/> instances</typeparam>
        /// <typeparam name="TCustomMessages">The type containing custom <see cref="Message"/> instances</typeparam>
        /// <typeparam name="TMessages">The type containing <see cref="Message"/> instances</typeparam>
        /// <param name="types">Delegate that instantiates an object whose properties are the script <see cref="SetupType"/> entries</param>
        /// <param name="customMessages">Delegate that instantiates an object whose properties are the script custom <see cref="Message"/> entries</param>
        /// <param name="messages">Delegate that instantiates an object whose properties are the script <see cref="Message"/> entries</param>
        /// <returns>An object with which components can be built</returns>
        IComponentsBuilder<TLanguages, TSetupTypes, TCustomMessages, TMessages> Add<TSetupTypes, TCustomMessages, TMessages>(
                            Func<Func<SetupType.Builder>, TLanguages, TSetupTypes> types,
                            Func<TLanguages, TCustomMessages> customMessages,
                            Func<TLanguages, TMessages> messages);
    }
}
