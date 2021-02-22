
using CodingMuscles.CSharpInnoSetup.Converter;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_iconssection.htm">Documentation</a>
    /// </summary>
    public sealed class IconEntry : ICommonParameters, ICustomizable, IPredicated
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_iconssection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string Name { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_iconssection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        [Alias("Filename")]
        public FileInfo FileName { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_iconssection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string Parameters { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_iconssection.htm">Documentation</a>
        /// </summary>
        [Alias("WorkingDir")]
        public DirectoryInfo WorkingFolder { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_iconssection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string HotKey { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_iconssection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string Comment { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_iconssection.htm">Documentation</a>
        /// </summary>
        [Alias("IconFilename")]
        public FileInfo IconFileName { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_iconssection.htm">Documentation</a>
        /// </summary>
        public int? IconIndex { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_iconssection.htm">Documentation</a>
        /// </summary>
        [Alias("AppUserModelID")]
        public string AppUserModelId { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_iconssection.htm">Documentation</a>
        /// </summary>
        public Guid? AppUserModelToastActivatorCLSID { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_iconssection.htm">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<IconFlags>))]
        public IconFlags Flags { get; private set; }

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
        /// Creates and initializes instances of a <see cref="IconEntry"/>
        /// </summary>
        public class Builder : IBuilder<IconEntry>, ICommonParametersBuilder<Builder>, IPredicatedBuilder<Builder>, ICustomizableBuilder<Builder>
        {
            private readonly IconEntry _icon;

            /// <summary>
            /// Create an instance of the <see cref="Builder"/>
            /// </summary>
            /// <returns>A new builder instance</returns>
            public static Builder Create() => new Builder();

            /// <see cref="IconEntry.Name"/>
            public Builder Name(string name)
            {
                _icon.Name = name;
                return this;
            }

            /// <see cref="IconEntry.FileName"/>
            public Builder FileName(FileInfo fileName)
            {
                _icon.FileName = fileName;
                return this;
            }

            /// <see cref="IconEntry.Name"/>
            public Builder FileName(string fileName)
            {
                _icon.FileName = new FileInfo(fileName);
                return this;
            }

            /// <see cref="IconEntry.Parameters"/>
            public Builder Parameters(string parameters)
            {
                _icon.Parameters = parameters;
                return this;
            }

            /// <see cref="IconEntry.WorkingFolder"/>
            public Builder WorkingFolder(DirectoryInfo workingFolder)
            {
                _icon.WorkingFolder = workingFolder;
                return this;
            }

            /// <see cref="IconEntry.WorkingFolder"/>
            public Builder WorkingFolder(string workingFolder)
            {
                _icon.WorkingFolder = new DirectoryInfo(workingFolder);
                return this;
            }

            /// <see cref="IconEntry.HotKey"/>
            public Builder HotKey(string hotKey)
            {
                _icon.HotKey = hotKey;
                return this;
            }

            /// <see cref="IconEntry.Comment"/>
            public Builder Comment(string comment)
            {
                _icon.Comment = comment;
                return this;
            }

            /// <see cref="IconEntry.IconFileName"/>
            public Builder IconFileName(FileInfo iconFileName)
            {
                _icon.IconFileName = iconFileName;
                return this;
            }

            /// <see cref="IconEntry.IconIndex"/>
            public Builder IconIndex(int iconIndex)
            {
                _icon.IconIndex = iconIndex;
                return this;
            }

            /// <see cref="IconEntry.AppUserModelId"/>
            public Builder AppUserModelId(string appUserModelId)
            {
                _icon.AppUserModelId = appUserModelId;
                return this;
            }

            /// <see cref="IconEntry.AppUserModelToastActivatorCLSID"/>
            public Builder AppUserModelToastActivatorCLSID(Guid appUserModelToastActivatorCLSID)
            {
                _icon.AppUserModelToastActivatorCLSID = appUserModelToastActivatorCLSID;
                return this;
            }

            /// <see cref="IconEntry.AppUserModelToastActivatorCLSID"/>
            public Builder AppUserModelToastActivatorCLSID(string appUserModelToastActivatorCLSID)
            {
                _icon.AppUserModelToastActivatorCLSID = new Guid(appUserModelToastActivatorCLSID);
                return this;
            }

            /// <see cref="IconEntry.Flags"/>
            public Builder Flags(IconFlags flags)
            {
                _icon.Flags = flags;
                return this;
            }

            /// <inheritdoc/>
            public Builder Check(Expression<Func<string, bool>> check)
            {
                _icon.Check = check;
                return this;
            }

            /// <inheritdoc/>
            public Builder Components(Expression<Func<bool>> components)
            {
                _icon.Components = components;
                return this;
            }

            /// <inheritdoc/>
            public Builder Tasks(Expression<Func<ITask[]>> tasks)
            {
                _icon.Tasks = tasks;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language[]>> languages)
            {
                _icon.Languages = languages;
                return this;
            }

            /// <inheritdoc/>
            public Builder Tasks(Expression<Func<ITask>> task)
            {
                _icon.Tasks = Expression.Lambda<Func<ITask[]>>(Expression.NewArrayInit(typeof(ITask), task.Body)); ;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language>> language)
            {
                _icon.Languages = Expression.Lambda<Func<Language[]>>(Expression.NewArrayInit(typeof(Language), language.Body)); ;
                return this;
            }

            /// <inheritdoc/>
            public Builder MinVersion(Version minVersion)
            {
                _icon.MinVersion = minVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder MinVersion(string minVersion)
            {
                _icon.MinVersion = new Version(minVersion);
                return this;
            }

            /// <inheritdoc/>
            public Builder OnlyBelowVersion(Version onlyBelowVersion)
            {
                _icon.OnlyBelowVersion = onlyBelowVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder OnlyBelowVersion(string onlyBelowVersion)
            {
                _icon.OnlyBelowVersion = new Version(onlyBelowVersion);
                return this;
            }

            /// <inheritdoc/>
            public IconEntry Build() => _icon;

            private Builder()
            {
                _icon = new IconEntry();
            }
        }

        private IconEntry()
        {

        }
    }
}
