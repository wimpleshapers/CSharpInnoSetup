
using CodingMuscles.CSharpInnoSetup.Converter;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_runsection.htm">Documentation</a>
    /// </summary>
    public sealed class RunEntry : ICommonParameters, IPredicated, ICustomizable
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_runsection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        [Alias("Filename")]
        public FileInfo FileName { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_runsection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string Description { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_runsection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string Parameters { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_runsection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        [Alias("WorkingDir")]
        public DirectoryInfo WorkingFolder { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_runsection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        [Alias("StatusMsg")]
        public string StatusMessage { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_runsection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string RunOnceId { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_runsection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string Verb { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_runsection.htm">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<RunFlags>))]
        public RunFlags Flags { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<Language[]>> Languages { get; private set; }

        /// <inheritdoc/>
        public Version MinVersion { get; private set; }

        /// <inheritdoc/>
        public Version OnlyBelowVersion { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<bool>> Components { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<string, bool>> Check { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<ITask[]>> Tasks { get; private set; }

        /// <summary>
        /// Creates and initializes instances of a <see cref="RunEntry"/>
        /// </summary>
        public class Builder : IBuilder<RunEntry>, ICommonParametersBuilder<Builder>, IPredicatedBuilder<Builder>, ICustomizableBuilder<Builder>
        {
            private readonly RunEntry _run;

            /// <summary>
            /// Create an instance of the <see cref="Builder"/>
            /// </summary>
            /// <returns>A new builder instance</returns>
            public static Builder Create() => new Builder();

            /// <see cref="RunEntry.FileName"/>
            public Builder FileName(FileInfo filename)
            {
                _run.FileName = filename;
                return this;
            }

            /// <see cref="RunEntry.Description"/>
            public Builder Description(string description)
            {
                _run.Description = description;
                return this;
            }

            /// <see cref="RunEntry.Parameters"/>
            public Builder Parameters(string parameters)
            {
                _run.Parameters = parameters;
                return this;
            }

            /// <see cref="RunEntry.WorkingFolder"/>
            public Builder WorkingFolder(DirectoryInfo workingFolder)
            {
                _run.WorkingFolder = workingFolder;
                return this;
            }

            /// <see cref="RunEntry.StatusMessage"/>
            public Builder StatusMessage(string statusMessage)
            {
                _run.StatusMessage = statusMessage;
                return this;
            }

            /// <see cref="RunEntry.RunOnceId"/>
            public Builder RunOnceId(string runOnceId)
            {
                _run.RunOnceId = runOnceId;
                return this;
            }

            /// <see cref="RunEntry.Verb"/>
            public Builder Verb(string verb)
            {
                _run.Verb = verb;
                return this;
            }

            /// <see cref="RunEntry.Flags"/>
            public Builder Flags(RunFlags flags)
            {
                _run.Flags = flags;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language[]>> languages)
            {
                _run.Languages = languages;
                return this;
            }

            /// <inheritdoc/>
            public Builder MinVersion(Version minVersion)
            {
                _run.MinVersion = minVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder OnlyBelowVersion(Version onlyBelowVersion)
            {
                _run.OnlyBelowVersion = onlyBelowVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder Component(Expression<Func<bool>> components)
            {
                _run.Components = components;
                return this;
            }

            /// <inheritdoc/>
            public Builder Check(Expression<Func<string, bool>> check)
            {
                _run.Check = check;
                return this;
            }

            /// <inheritdoc/>
            public Builder Tasks(Expression<Func<ITask[]>> tasks)
            {
                _run.Tasks = tasks;
                return this;
            }

            /// <inheritdoc/>
            public Builder Tasks(Expression<Func<ITask>> task)
            {
                _run.Tasks = Expression.Lambda<Func<ITask[]>>(Expression.NewArrayInit(typeof(ITask), task.Body)); ;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language>> language)
            {
                _run.Languages = Expression.Lambda<Func<Language[]>>(Expression.NewArrayInit(typeof(Language), language.Body)); ;
                return this;
            }

            /// <inheritdoc/>
            public Builder Components(Expression<Func<bool>> components)
            {
                _run.Components = components;
                return this;
            }

            /// <inheritdoc/>
            public RunEntry Build() => _run;

            private Builder()
            {
                _run = new RunEntry();
            }
        }

        private RunEntry()
        {

        }
    }
}
