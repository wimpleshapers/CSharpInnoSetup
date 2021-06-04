
using CodingMuscles.CSharpInnoSetup.Converter;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_filessection.htm">Documentation</a>
    /// </summary>
    public sealed class FileEntry : ICommonParameters, IPredicated, ICustomizable
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=filessection">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public SourcedFile Source { get; private set; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=filessection">Documentation</a>
        /// </summary>
        [DoubleQuote]
        [Alias("DestDir")]
        public DirectoryInfo Destination { get; private set; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=filessection">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<FileFlags>))]
        public FileFlags Flags { get; private set; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=filessection">Documentation</a>
        /// </summary>
        [DoubleQuote]
        [Alias("DestName")]
        public string DestinationName { get; private set; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=filessection">Documentation</a>
        /// </summary>
        [DoubleQuote]
        [TypeConverter(typeof(EnumerableToCommaSeparatedStringConverter))]
        public string[] Excludes { get; private set; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=filessection">Documentation</a>
        /// </summary>
        public long? ExternalSize { get; private set; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=filessection">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<FileSystemAttribute>))]
        [Alias("Attribs")]
        public FileSystemAttribute Attributes { get; private set; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=filessection">Documentation</a>
        /// </summary>
        [Alias("Perissions")]
        public AclPermission Permission { get; private set; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=filessection">Documentation</a>
        /// </summary>
        [DoubleQuote]
        [Alias("FontInstall")]
        public string FontName { get; private set; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=filessection">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string StrongAssemblyName { get; private set; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptinstall">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(DelegateExpressionToStringConverter<Action<string>>))]
        public Expression<Action<string>> AfterInstall { get; private set; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptinstall">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(DelegateExpressionToStringConverter<Action<string>>))]
        public Expression<Action<string>> BeforeInstall { get; private set; }

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
        /// Instantiates and initializes a <see cref="FileEntry"/> object
        /// </summary>
        public class Builder : IBuilder<FileEntry>, ICommonParametersBuilder<Builder>, IPredicatedBuilder<Builder>, ICustomizableBuilder<Builder>
        {
            private readonly FileEntry _file;

            /// <summary>
            /// Create an instance of the <see cref="Builder"/>
            /// </summary>
            /// <returns>A new builder instance</returns>
            public static Builder Create() => new Builder();

            /// <see cref="FileEntry.Source"/>
            public Builder Source(SourcedFile source)
            {
                _file.Source = source;
                return this;
            }

            /// <see cref="FileEntry.Source"/>
            public Builder Source(FileInfo fileInfo)
            {
                return Source(SourcedFile.From(fileInfo));
            }

            /// <see cref="FileEntry.Source"/>
            public Builder Source(DirectoryInfo directoryInfo, string fileName)
            {
                return Source(SourcedFile.From(directoryInfo, fileName));
            }

            /// <see cref="FileEntry.Destination"/>
            public Builder Destination(DirectoryInfo destination)
            {
                _file.Destination = destination;
                return this;
            }

            /// <see cref="FileEntry.Destination"/>
            public Builder Destination(string destination)
            {
                _file.Destination = new DirectoryInfo(destination);
                return this;
            }

            /// <see cref="FileEntry.Source"/>
            public Builder Flags(FileFlags flags)
            {
                _file.Flags = flags;
                return this;
            }

            /// <see cref="FileEntry.DestinationName"/>
            public Builder DestinationName(string destinationName)
            {
                _file.DestinationName = destinationName;
                return this;
            }

            /// <see cref="FileEntry.Excludes"/>
            public Builder Excludes(params string[] excludes)
            {
                _file.Excludes = excludes;
                return this;
            }

            /// <see cref="FileEntry.ExternalSize"/>
            public Builder ExternalSize(long externalSize)
            {
                _file.ExternalSize = externalSize;
                _file.Flags |= FileFlags.External;
                return this;
            }

            /// <see cref="FileEntry.Attributes"/>
            public Builder Attributes(FileSystemAttribute attributes)
            {
                _file.Attributes = attributes;
                return this;
            }

            /// <see cref="FileEntry.Permission"/>
            public Builder Permission(AclPermission permission)
            {
                _file.Permission = permission;
                return this;
            }

            /// <see cref="FileEntry.FontName"/>
            public Builder FontName(string fontName)
            {
                _file.FontName = fontName;
                return this;
            }

            /// <see cref="FileEntry.StrongAssemblyName"/>
            public Builder StrongAssemblyName(string strongAssemblyName)
            {
                _file.StrongAssemblyName = strongAssemblyName;
                return this;
            }

            /// <see cref="FileEntry.AfterInstall"/>
            public Builder AfterInstall(Expression<Action<string>> afterInstall)
            {
                _file.AfterInstall = afterInstall;
                return this;
            }

            /// <see cref="FileEntry.BeforeInstall"/>
            public Builder BeforeInstall(Expression<Action<string>> beforeInstall)
            {
                _file.BeforeInstall = beforeInstall;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language[]>> languages)
            {
                _file.Languages = languages;
                return this;
            }

            /// <inheritdoc/>
            public Builder MinVersion(Version minVersion)
            {
                _file.MinVersion = minVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder OnlyBelowVersion(Version onlyBelowVersion)
            {
                _file.OnlyBelowVersion = onlyBelowVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder Components(Expression<Func<bool>> components)
            {
                _file.Components = components;
                return this;
            }

            /// <inheritdoc/>
            public Builder Check(Expression<Func<string, bool>> check)
            {
                _file.Check = check;
                return this;
            }

            /// <inheritdoc/>
            public Builder Tasks(Expression<Func<ITask[]>> tasks)
            {
                _file.Tasks = tasks;
                return this;
            }

            /// <inheritdoc/>
            public Builder Tasks(Expression<Func<ITask>> task)
            {
                _file.Tasks = Expression.Lambda<Func<ITask[]>>(Expression.NewArrayInit(typeof(ITask), task.Body)); ;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language>> language)
            {
                _file.Languages = Expression.Lambda<Func<Language[]>>(Expression.NewArrayInit(typeof(Language), language.Body)); ;
                return this;
            }

            /// <inheritdoc/>
            public FileEntry Build() => _file;

            private Builder()
            {
                _file = new FileEntry();
            }
        }

        private FileEntry()
        {
        }
    }
}
