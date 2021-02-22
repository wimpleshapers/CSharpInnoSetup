
using CodingMuscles.CSharpInnoSetup.Converter;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_languagessection.htm">Documentation</a>
    /// </summary>
    public sealed class Language
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_languagessection.htm">Documentation</a>
        /// </summary>
        [Alias("MessagesFile")]
        [TypeConverter(typeof(EnumerableToCommaSeparatedStringConverter))]
        public List<SourcedFile> MessagesFiles { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_languagessection.htm">Documentation</a>
        /// </summary>
        public FileInfo LicenseFile { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_languagessection.htm">Documentation</a>
        /// </summary>
        public FileInfo InfoBeforeFile { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_languagessection.htm">Documentation</a>
        /// </summary>
        public FileInfo InfoAfterFile { get; private set; }

        /// <summary>
        /// Creates an initializes instances of a <see cref="Language"/>
        /// </summary>
        public class Builder : IBuilder<Language>
        {
            private readonly Language _language;

            /// <summary>
            /// Create an instance of the <see cref="Builder"/>
            /// </summary>
            /// <returns>A new builder instance</returns>
            public static Builder Create() => new Builder();

            /// <see cref="Language.MessagesFiles"/>
            public Builder AddMessageFile(SourcedFile messageFile)
            {
                _language.MessagesFiles ??= new List<SourcedFile>();
                _language.MessagesFiles.Add(messageFile);

                return this;
            }

            /// <see cref="Language.LicenseFile"/>
            public Builder LicenseFile(FileInfo licenseFile)
            {
                _language.LicenseFile = licenseFile;
                return this;
            }

            /// <see cref="Language.InfoBeforeFile"/>
            public Builder InfoBeforeFile(FileInfo infoBeforeFile)
            {
                _language.InfoAfterFile = infoBeforeFile;
                return this;
            }

            /// <see cref="Language.InfoAfterFile"/>
            public Builder InfoAfterFile(FileInfo infoAfterFile)
            {
                _language.InfoAfterFile = infoAfterFile;
                return this;
            }

            /// <inheritdoc/>
            public Language Build()
            {
                return _language;
            }

            private Builder()
            {
                _language = new Language();
            }
        }

        private Language()
        {
        }
    }
}
