
using System;

namespace CodingMuscles.CSharpInnoSetup
{
    /// <summary>
    /// Builds a collection of components for the Inno Setup script [Tasks] section
    /// </summary>
    /// <typeparam name="TLanguages">The type containing languages</typeparam>
    /// <typeparam name="TSetupTypes">The type containing setup types</typeparam>
    /// <typeparam name="TCustomMessages">The type containing custom messages</typeparam>
    /// <typeparam name="TMessages">The type containing messages</typeparam>
    /// <typeparam name="TComponents">The type containing components</typeparam>
    public interface ITasksBuilder<TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents>
    {
        /// <summary>
        /// Allows tasks of the script to be specified
        /// </summary>
        /// <typeparam name="TTasks">The type containing tasks</typeparam>
        /// <param name="tasks">A delegate that returns an object whose properties represent individual tasks</param>
        /// <returns>A builder with which content is built</returns>
        IContentBuilder<TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks> AddTasks<TTasks>(
            Func<TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks> tasks);
    }
}
