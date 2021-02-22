
using CodingMuscles.CSharpInnoSetup.Converter;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_dirssection.htm">Documentation</a>
    /// </summary>
    public sealed class FolderEntry : ICommonParameters, ICustomizable, IPredicated
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_dirssection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public DirectoryInfo Name { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_dirssection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        [Alias("Attribs")]
        [TypeConverter(typeof(EnumToStringConverter<FileSystemAttribute>))]
        public FileSystemAttribute Attributes { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_dirssection.htm">Documentation</a>
        /// </summary>
        [Alias("Perissions")]
        public AclPermission Permission { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_dirssection.htm">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<FolderFlags>))]
        public FolderFlags Flags { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<Language[]>> Languages { get; private set; }

        /// <inheritdoc/>
        public Version MinVersion { get; private set; }

        /// <inheritdoc/>
        public Version OnlyBelowVersion { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<bool>> Components { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<ITask[]>> Tasks { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<string, bool>> Check { get; private set; }

        /// <summary>
        /// Creates and initializes instances of a <see cref="FolderEntry"/>
        /// </summary>
        public class Builder : IBuilder<FolderEntry>, ICommonParametersBuilder<Builder>, IPredicatedBuilder<Builder>, ICustomizableBuilder<Builder>
        {
            private readonly FolderEntry _folder;

            /// <summary>
            /// Create an instance of the <see cref="Builder"/>
            /// </summary>
            /// <returns>A new builder instance</returns>
            public static Builder Create() => new Builder();

            /// <see cref="FolderEntry.Name"/>
            public Builder Name(DirectoryInfo name)
            {
                _folder.Name = name;
                return this;
            }

            /// <see cref="FolderEntry.Name"/>
            public Builder Name(string name)
            {
                _folder.Name = new DirectoryInfo(name);
                return this;
            }

            /// <see cref="FolderEntry.Permission"/>
            public Builder Permission(AclPermission permission)
            {
                _folder.Permission = permission;
                return this;
            }

            /// <see cref="FolderEntry.Flags"/>
            public Builder Flags(FolderFlags flags)
            {
                _folder.Flags = flags;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language[]>> languages)
            {
                _folder.Languages = languages;
                return this;
            }

            /// <inheritdoc/>
            public Builder MinVersion(Version minVersion)
            {
                _folder.MinVersion = minVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder OnlyBelowVersion(Version onlyBelowVersion)
            {
                _folder.OnlyBelowVersion = onlyBelowVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder Check(Expression<Func<string, bool>> check)
            {
                _folder.Check = check;
                return this;
            }

            /// <inheritdoc/>
            public Builder Components(Expression<Func<bool>> components)
            {
                _folder.Components = components;
                return this;
            }

            /// <inheritdoc/>
            public Builder Tasks(Expression<Func<ITask[]>> tasks)
            {
                _folder.Tasks = tasks;
                return this;
            }

            /// <inheritdoc/>
            public Builder Tasks(Expression<Func<ITask>> task)
            {
                _folder.Tasks = Expression.Lambda<Func<ITask[]>>(Expression.NewArrayInit(typeof(ITask), task.Body)); ;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language>> language)
            {
                _folder.Languages = Expression.Lambda<Func<Language[]>>(Expression.NewArrayInit(typeof(Language), language.Body)); ;
                return this;
            }

            /// <inheritdoc/>
            public FolderEntry Build() => _folder;

            private Builder()
            {
                _folder = new FolderEntry();
            }
        }

        private FolderEntry()
        {
        }
    }
}
