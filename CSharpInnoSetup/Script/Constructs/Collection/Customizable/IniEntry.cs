
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.IO;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_inisection.htm">Documentation</a>
    /// </summary>
    public sealed class IniEntry : ICommonParameters, ICustomizable, IPredicated
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_inisection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        [Alias("Filename")]
        public FileInfo FileName { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_inisection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string Section { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_inisection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string Key { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_inisection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        [Alias("String")]
        public string Value { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_inisection.htm">Documentation</a>
        /// </summary>
        public IniFlags Flags { get; private set; }

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
        /// Creates and initializes instances of a <see cref="IniEntry"/>
        /// </summary>
        public class Builder : IBuilder<IniEntry>, ICommonParametersBuilder<Builder>, IPredicatedBuilder<Builder>, ICustomizableBuilder<Builder>
        {
            private readonly IniEntry _ini;

            /// <summary>
            /// Create an instance of the <see cref="Builder"/>
            /// </summary>
            /// <returns>A new builder instance</returns>
            public static Builder Create() => new Builder();

            /// <see cref="IniEntry.FileName"/>
            public Builder FileName(FileInfo fileName)
            {
                _ini.FileName = fileName;
                return this;
            }

            /// <see cref="IniEntry.FileName"/>
            public Builder FileName(string fileName)
            {
                _ini.FileName = new FileInfo(fileName);
                return this;
            }

            /// <see cref="IniEntry.Section"/>
            public Builder Section(string section)
            {
                _ini.Section = section;
                return this;
            }

            /// <see cref="IniEntry.Key"/>
            public Builder Key(string key)
            {
                _ini.Key = key;
                return this;
            }

            /// <see cref="IniEntry.Value"/>
            public Builder Value(string value)
            {
                _ini.Value = value;
                return this;
            }

            /// <see cref="IniEntry.Flags"/>
            public Builder Flags(IniFlags flags)
            {
                _ini.Flags = flags;
                return this;
            }

            /// <inheritdoc/>
            public Builder Check(Expression<Func<string, bool>> check)
            {
                _ini.Check = check;
                return this;
            }

            /// <inheritdoc/>
            public Builder Components(Expression<Func<bool>> components)
            {
                _ini.Components = components;
                return this;
            }

            /// <inheritdoc/>
            public Builder Tasks(Expression<Func<ITask[]>> tasks)
            {
                _ini.Tasks = tasks;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language[]>> languages)
            {
                _ini.Languages = languages;
                return this;
            }

            /// <inheritdoc/>
            public Builder Tasks(Expression<Func<ITask>> task)
            {
                _ini.Tasks = Expression.Lambda<Func<ITask[]>>(Expression.NewArrayInit(typeof(ITask), task.Body)); ;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language>> language)
            {
                _ini.Languages = Expression.Lambda<Func<Language[]>>(Expression.NewArrayInit(typeof(Language), language.Body)); ;
                return this;
            }

            /// <inheritdoc/>
            public Builder MinVersion(Version minVersion)
            {
                _ini.MinVersion = minVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder MinVersion(string minVersion)
            {
                _ini.MinVersion = new Version(minVersion);
                return this;
            }

            /// <inheritdoc/>
            public Builder OnlyBelowVersion(Version onlyBelowVersion)
            {
                _ini.OnlyBelowVersion = onlyBelowVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder OnlyBelowVersion(string onlyBelowVersion)
            {
                _ini.OnlyBelowVersion = new Version(onlyBelowVersion);
                return this;
            }

            /// <inheritdoc/>
            public IniEntry Build() => _ini;

            private Builder()
            {
                _ini = new IniEntry();
            }
        }

        private IniEntry()
        {

        }
    }
}
