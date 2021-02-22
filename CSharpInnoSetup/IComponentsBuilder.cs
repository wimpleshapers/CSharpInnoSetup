
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;

namespace CodingMuscles.CSharpInnoSetup
{
    /// <summary>
    /// Builds a collection of components for the Inno Setup script [Components] section
    /// </summary>
    /// <typeparam name="TLanguages">The type containing languages</typeparam>
    /// <typeparam name="TSetupTypes">The type containing setup types</typeparam>
    /// <typeparam name="TCustomMessages">The type containing custom messages</typeparam>
    /// <typeparam name="TMessages">The type containing messages</typeparam>
    public interface IComponentsBuilder<TLanguages, TSetupTypes, TCustomMessages, TMessages>
    {
        /// <summary>
        /// Allows components of the script to be specified
        /// </summary>
        /// <typeparam name="TComponents">The type containing components</typeparam>
        /// <param name="components">A delegate that returns an object whose properties represent individual components</param>
        /// <returns>A builder with which tasks are built</returns>
        ITasksBuilder<TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents> AddComponents<TComponents>(
            Func<TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents> components);
    }
}
