
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable;
using System;
using System.Collections.Generic;

namespace CodingMuscles.CSharpInnoSetup
{
    /// <summary>
    /// Builds parts of the Inno Setup script that contain repeating entries 
    /// </summary>
    /// <typeparam name="TLanguages">The type containing languages</typeparam>
    /// <typeparam name="TSetupTypes">The type containing setup types</typeparam>
    /// <typeparam name="TCustomMessages">The type containing custom messages</typeparam>
    /// <typeparam name="TMessages">The type containing messages</typeparam>
    /// <typeparam name="TComponents">The type containing components</typeparam>
    /// <typeparam name="TTasks">The type containing tasks</typeparam>
    public interface IContentBuilder<TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks>
    {
        /// <summary>
        /// Allows entries in the [Files] section to be specified
        /// </summary>
        /// <param name="builder">A builder with which new <see cref="FileEntry.Builder"/> objects are instatiated</param>
        void AddFiles(Func<Func<FileEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<FileEntry>> builder);

        /// <summary>
        /// Allows entries in the [Dirs] section to be specified
        /// </summary>
        /// <param name="builder">A builder with which new <see cref="FolderEntry.Builder"/> objects are instatiated</param>
        void AddFolders(Func<Func<FolderEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<FolderEntry>> builder);

        /// <summary>
        /// Allows entries in the [Icons] section to be specified
        /// </summary>
        /// <param name="builder">A builder with which new <see cref="IconEntry.Builder"/> objects are instatiated</param>
        void AddIcons(Func<Func<IconEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<IconEntry>> builder);

        /// <summary>
        /// Allows entries in the [Files] section to be specified
        /// </summary>
        /// <param name="builder">A builder with which new <see cref="IniEntry.Builder"/> objects are instatiated</param>
        void AddIniEntries(Func<Func<IniEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<IniEntry>> builder);

        /// <summary>
        /// Allows entries in the [InstallDelete] section to be specified
        /// </summary>
        /// <param name="builder">A builder with which new <see cref="DeleteEntry.Builder"/> objects are instatiated</param>
        void AddInstallDeleteEntries(Func<Func<DeleteEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<DeleteEntry>> builder);

        /// <summary>
        /// Allows entries in the [UninstallDelete] section to be specified
        /// </summary>
        /// <param name="builder">A builder with which new <see cref="DeleteEntry.Builder"/> objects are instatiated</param>
        void AddUninstallDeleteEntries(Func<Func<DeleteEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<DeleteEntry>> builder);

        /// <summary>
        /// Allows entries in the [Registry] section to be specified
        /// </summary>
        /// <param name="builder">A builder with which new <see cref="RegistryEntry.Builder"/> objects are instatiated</param>
        void AddRegistryEntries(Func<Func<RegistryEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<RegistryEntry>> builder);

        /// <summary>
        /// Allows entries in the [Run] section to be specified
        /// </summary>
        /// <param name="builder">A builder with which new <see cref="RunEntry.Builder"/> objects are instatiated</param>
        void AddRunEntries(Func<Func<RunEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<RunEntry>> builder);

        /// <summary>
        /// Allows entries in the [UninstallRun] section to be specified
        /// </summary>
        /// <param name="builder">A builder with which new <see cref="RunEntry.Builder"/> objects are instatiated</param>
        void AddUninstallRunEntries(Func<Func<RunEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<RunEntry>> builder);
    }
}
