
using CodingMuscles.CSharpInnoSetup.Converter;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_typessection.htm">Documentation</a>
    /// </summary>
    public sealed class SetupType : ICommonParameters, IPredicated
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_typessection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string Description { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_typessection.htm">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<SetupTypeFlags>))]
        public SetupTypeFlags Flags { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<Language[]>> Languages { get; private set; }

        /// <inheritdoc/>
        public Version MinVersion { get; private set; }

        /// <inheritdoc/>
        public Version OnlyBelowVersion { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<string, bool>> Check { get; private set; }

        /// <summary>
        /// Creates and initializes instances of a <see cref="SetupType"/>
        /// </summary>
        public class Builder : IBuilder<SetupType>, ICommonParametersBuilder<Builder>, IPredicatedBuilder<Builder>
        {
            private readonly SetupType _type;

            /// <summary>
            /// Create an instance of the <see cref="Builder"/>
            /// </summary>
            /// <returns>A new builder instance</returns>
            public static Builder Create() => new Builder();

            /// <see cref="SetupType.Description"/>
            public Builder Description(string description)
            {
                _type.Description = description;
                return this;
            }

            /// <see cref="SetupType.Flags"/>
            public Builder Flags(SetupTypeFlags flags)
            {
                _type.Flags = flags;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language[]>> languages)
            {
                _type.Languages = languages;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language>> language)
            {
                _type.Languages = Expression.Lambda<Func<Language[]>>(Expression.NewArrayInit(typeof(Language), language.Body));
                return this;
            }

            /// <inheritdoc/>
            public Builder MinVersion(Version minVersion)
            {
                _type.MinVersion = minVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder OnlyBelowVersion(Version onlyBelowVersion)
            {
                _type.OnlyBelowVersion = onlyBelowVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder Check(Expression<Func<string, bool>> check)
            {
                _type.Check = check;
                return this;
            }

            /// <inheritdoc/>
            public SetupType Build() => _type;

            private Builder()
            {
                _type = new SetupType();
            }
        }

        private SetupType()
        {
        }
    }
}
