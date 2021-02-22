
using CodingMuscles.CSharpInnoSetup.Converter;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration
{
    /// <summary>
    /// Factory that creates <see cref="Component"/> objects that are nodes within a tree structure
    /// </summary>
    public static class ComponentFactory
    {
        /// <summary>
        /// Create a <see cref="Component{T}"/> that has child containing <see cref="Component{T}"/> objects
        /// </summary>
        /// <typeparam name="TChildren">The type containing the child <see cref="Component{T}"/> objects</typeparam>
        /// <param name="builder">Object that creates <see cref="Component{T}"/> objects</param>
        /// <param name="children">Reference to the children</param>
        /// <returns>The <see cref="Component{T}"/> node</returns>
        public static Component<TChildren> CreateParent<TChildren>(Func<Component<TChildren>.Builder, Component<TChildren>> builder, TChildren children)
        {
            return builder(Component<TChildren>.Builder.Create(children));
        }

        /// <summary>
        /// Creates a <see cref="Component{T}"/> with no children
        /// </summary>
        /// <returns>The <see cref="Component{T}"/> node</returns>
        public static Component<LeafComponent>.Builder CreateLeaf() => Component<LeafComponent>.Builder.Create(new LeafComponent());

        /// <summary>
        /// Terminating node within the <see cref="Component{T}"/> tree
        /// </summary>
        public sealed class LeafComponent
        {

        }
    }

    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_componentssection.htm">Documentation</a>
    /// </summary>
    public sealed class Component<TChildren> : ICommonParameters, IPredicated
    {
        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_componentssection.htm">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string Description { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_componentssection.htm">Documentation</a>
        /// </summary>
        public ulong? ExtraDiskSpaceRequired { get; private set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_componentssection.htm">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<ComponentFlags>))]
        public ComponentFlags Flags { get; private set; }

        /// <inheritdoc/>
        [TypeConverter(typeof(TypesExpressionToStringConverter))]
        public Expression<Func<SetupType[]>> Types { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<Language[]>> Languages { get; private set; }

        /// <inheritdoc/>
        public Version MinVersion { get; private set; }

        /// <inheritdoc/>
        public Version OnlyBelowVersion { get; private set; }

        /// <inheritdoc/>
        public Expression<Func<string, bool>> Check { get; private set; }

        /// <summary>
        /// Object whose properties are <see cref="Component{T}"/> objects
        /// </summary>
        [Ignore]
        public TChildren Children { get; private set; }

        /// <summary>
        /// Creates and initializes instances of a <see cref="Component{T}"/>
        /// </summary>
        public class Builder : IBuilder<Component<TChildren>>, ICommonParametersBuilder<Builder>, IPredicatedBuilder<Builder>
        {
            private readonly Component<TChildren> _component;

            /// <summary>
            /// Create an instance of the <see cref="Builder"/>
            /// </summary>
            /// <returns>A new builder instance</returns>
            public static Builder Create(TChildren children) => new Builder(children);

            /// <summary>
            /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_componentssection.htm">Documentation</a>
            /// </summary>
            public Builder Description(string description)
            {
                _component.Description = description;
                return this;
            }

            /// <summary>
            /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_componentssection.htm">Documentation</a>
            /// </summary>
            public Builder ExtraDiskSpaceRequired(ulong extraDiskSpaceRequired)
            {
                _component.ExtraDiskSpaceRequired = extraDiskSpaceRequired;
                return this;
            }

            /// <summary>
            /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_componentssection.htm">Documentation</a>
            /// </summary>
            public Builder Flags(ComponentFlags componentFlags)
            {
                _component.Flags = componentFlags;
                return this;
            }

            /// <inheritdoc/>
            public Builder Types(Expression<Func<SetupType[]>> types)
            {
                _component.Types = types;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language[]>> languages)
            {
                _component.Languages = languages;
                return this;
            }

            /// <inheritdoc/>
            public Builder Types(Expression<Func<SetupType>> type)
            {
                _component.Types = Expression.Lambda<Func<SetupType[]>>(Expression.NewArrayInit(typeof(SetupType), type.Body));
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language>> language)
            {
                _component.Languages = Expression.Lambda<Func<Language[]>>(Expression.NewArrayInit(typeof(Language), language.Body));
                return this;
            }

            /// <inheritdoc/>
            public Builder MinVersion(Version minVersion)
            {
                _component.MinVersion = minVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder OnlyBelowVersion(Version onlyBelowVersion)
            {
                _component.OnlyBelowVersion = onlyBelowVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder Check(Expression<Func<string, bool>> check)
            {
                _component.Check = check;
                return this;
            }

            /// <inheritdoc/>
            public Component<TChildren> Build() => _component;

            private Builder(TChildren children)
            {
                _component = new Component<TChildren>(children);
            }
        }

        /// <summary>
        /// Makes it possible to use <see cref="Component"/> in a binary expression
        /// </summary>
        /// <param name="c">Unused</param>
        public static implicit operator bool(Component<TChildren> c) => true;

        private Component(TChildren children)
        {
            Children = children;
        }
    }
}
