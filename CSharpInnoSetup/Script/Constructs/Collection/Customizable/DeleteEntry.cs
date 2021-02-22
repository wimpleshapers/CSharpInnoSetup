
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_installdeletesection.htm">Documentation</a>, 
    /// or Inno Setup <a href="https://jrsoftware.org/ishelp/topic_uninstalldeletesection.htm">Documentation</a>
    /// </summary>
    public sealed class DeleteEntry : ICommonParameters, IPredicated, ICustomizable
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_installdeletesection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        [Alias("Name")]
        public string Pattern { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_installdeletesection.htm">Documentation</a>
        /// </summary>
        public DeleteFlags Flags { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<Language[]>> Languages { get; private set; }

        /// <inheritdoc/>
        public Version MinVersion { get; private set; }

        /// <inheritdoc/>
        public Version OnlyBelowVersion { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<string, bool>> Check { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<bool>> Components { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<ITask[]>> Tasks { get; private set; }

        /// <summary>
        /// Creates an intializes instances of a <see cref="DeleteEntry"/>
        /// </summary>
        public class Builder : IBuilder<DeleteEntry>, ICommonParametersBuilder<Builder>, IPredicatedBuilder<Builder>, ICustomizableBuilder<Builder>
        {
            private readonly DeleteEntry _delete;

            /// <summary>
            /// Create an instance of the <see cref="Builder"/>
            /// </summary>
            /// <returns>A new builder instance</returns>
            public static Builder Create() => new Builder();

            /// <see cref="DeleteEntry.Pattern"/>
            public Builder Pattern(string pattern)
            {
                _delete.Pattern = pattern;
                return this;
            }

            /// <see cref="DeleteEntry.Flags"/>
            public Builder Flags(DeleteFlags flags)
            {
                _delete.Flags = flags;
                return this;
            }

            /// <inheritdoc/>
            public Builder Check(Expression<Func<string, bool>> check)
            {
                _delete.Check = check;
                return this;
            }

            /// <inheritdoc/>
            public Builder Components(Expression<Func<bool>> components)
            {
                _delete.Components = components;
                return this;
            }

            /// <inheritdoc/>
            public Builder Tasks(Expression<Func<ITask[]>> tasks)
            {
                _delete.Tasks = tasks;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language[]>> languages)
            {
                _delete.Languages = languages;
                return this;
            }

            /// <inheritdoc/>
            public Builder Tasks(Expression<Func<ITask>> task)
            {
                _delete.Tasks = Expression.Lambda<Func<ITask[]>>(Expression.NewArrayInit(typeof(ITask), task.Body)); ;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language>> language)
            {
                _delete.Languages = Expression.Lambda<Func<Language[]>>(Expression.NewArrayInit(typeof(Language), language.Body)); ;
                return this;
            }

            /// <inheritdoc/>
            public Builder MinVersion(Version minVersion)
            {
                _delete.MinVersion = minVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder MinVersion(string minVersion)
            {
                return MinVersion(new Version(minVersion));
            }

            /// <inheritdoc/>
            public Builder OnlyBelowVersion(Version onlyBelowVersion)
            {
                _delete.OnlyBelowVersion = onlyBelowVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder OnlyBelowVersion(string onlyBelowVersion)
            {
                return OnlyBelowVersion(new Version(onlyBelowVersion));
            }

            /// <inheritdoc/>
            public DeleteEntry Build() => _delete;

            private Builder()
            {
                _delete = new DeleteEntry();
            }
        }

        private DeleteEntry()
        {

        }
    }
}
