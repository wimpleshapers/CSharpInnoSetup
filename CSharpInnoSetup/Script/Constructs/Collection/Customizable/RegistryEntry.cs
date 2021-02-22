
using CodingMuscles.CSharpInnoSetup.Converter;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
    /// </summary>
    public sealed class RegistryEntry : ICommonParameters, IPredicated, ICustomizable
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
        /// </summary>
        [Alias("Root")]
        [TypeConverter(typeof(EnumToStringConverter<RegistryHive>))]
        public RegistryHive Hive { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string Subkey { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string ValueName { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<RegistryDataType>))]
        public RegistryDataType ValueType { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public object ValueData { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
        /// </summary>
        public AclPermission Permission { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<RegistryFlags>))]
        public RegistryFlags Flags { get; private set; }

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
        /// Creates and initializes instances of a <see cref="RegistryEntry"/>
        /// </summary>
        public class Builder : IBuilder<RegistryEntry>, ICommonParametersBuilder<Builder>, IPredicatedBuilder<Builder>, ICustomizableBuilder<Builder>
        {
            private readonly RegistryEntry _entry;

            /// <summary>
            /// Create an instance of the <see cref="Builder"/>
            /// </summary>
            /// <returns>A new builder instance</returns>
            public static Builder Create() => new Builder();

            /// <see cref="RegistryEntry.Hive"/>
            public Builder Hive(RegistryHive hive)
            {
                _entry.Hive = hive;
                return this;
            }

            /// <see cref="RegistryEntry.Subkey"/>
            public Builder Subkey(string subkey)
            {
                _entry.Subkey = subkey;
                return this;
            }

            /// <see cref="RegistryEntry.ValueName"/>
            public Builder ValueName(string valueName)
            {
                _entry.ValueName = valueName;
                return this;
            }

            /// <see cref="RegistryEntry.ValueType"/>
            public Builder ValueType(RegistryDataType valueType)
            {
                _entry.ValueType = valueType;
                return this;
            }

            /// <see cref="RegistryEntry.ValueData"/>
            public Builder ValueData(object valueData)
            {
                _entry.ValueData = valueData;
                return this;
            }

            /// <see cref="RegistryEntry.Permission"/>
            public Builder Permission(AclPermission permission)
            {
                _entry.Permission = permission;
                return this;
            }

            /// <see cref="RegistryEntry.Flags"/>
            public Builder Flags(RegistryFlags flags)
            {
                _entry.Flags = flags;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language[]>> languages)
            {
                _entry.Languages = languages;
                return this;
            }

            /// <inheritdoc/>
            public Builder MinVersion(Version minVersion)
            {
                _entry.MinVersion = minVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder OnlyBelowVersion(Version onlyBelowVersion)
            {
                _entry.OnlyBelowVersion = onlyBelowVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder Components(Expression<Func<bool>> components)
            {
                _entry.Components = components;
                return this;
            }

            /// <inheritdoc/>
            public Builder Tasks(Expression<Func<ITask[]>> tasks)
            {
                _entry.Tasks = tasks;
                return this;
            }

            /// <inheritdoc/>
            public Builder Tasks(Expression<Func<ITask>> task)
            {
                _entry.Tasks = Expression.Lambda<Func<ITask[]>>(Expression.NewArrayInit(typeof(ITask), task.Body)); ;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language>> language)
            {
                _entry.Languages = Expression.Lambda<Func<Language[]>>(Expression.NewArrayInit(typeof(Language), language.Body)); ;
                return this;
            }

            /// <inheritdoc/>
            public Builder Check(Expression<Func<string, bool>> check)
            {
                _entry.Check = check;
                return this;
            }

            /// <inheritdoc/>
            public RegistryEntry Build() => _entry;

            private Builder()
            {
                _entry = new RegistryEntry();
            }
        }

        private RegistryEntry()
        {

        }
    }
}
