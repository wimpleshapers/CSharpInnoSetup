
using CodingMuscles.CSharpInnoSetup.Converter;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration
{
    /// <summary>
    /// Factory that creates <see cref="Component"/> objects that are nodes within a tree structure
    /// </summary>
    public static class TaskFactory
    {
        /// <summary>
        /// Create a <see cref="Task{T}"/> that has child <see cref="Task{T}"/> objects
        /// </summary>
        /// <typeparam name="TChildren">The type containing the child <see cref="Task{T}"/> objects</typeparam>
        /// <param name="builder">Object that creates <see cref="Task{T}"/> objects</param>
        /// <param name="children">Reference to the children</param>
        /// <returns>The <see cref="Task{T}"/> node</returns>
        public static Task<TChildren> CreateParent<TChildren>(Func<Task<TChildren>.Builder, Task<TChildren>> builder, TChildren children)
        {
            return builder(Task<TChildren>.Builder.Create(children));
        }

        /// <summary>
        /// Creates a <see cref="Task{T}"/> with no children
        /// </summary>
        /// <returns>The <see cref="Task{T}"/> node</returns>
        public static Task<LeafTask>.Builder CreateLeaf() => Task<LeafTask>.Builder.Create(new LeafTask());

        /// <summary>
        /// Terminating node within the <see cref="Task{T}"/> tree
        /// </summary>
        public sealed class LeafTask
        {

        }
    }

    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_taskssection.htm">Documentation</a>
    /// </summary>
    public sealed class Task<TChildren> : ICommonParameters, IPredicated, IComponentCustomizable, ITask
    {
        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=taskssection">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string Description { get; private set; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=taskssection">Documentation</a>
        /// </summary>
        [DoubleQuote]
        public string GroupDescription { get; private set; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=taskssection">Documentation</a>
        /// </summary>
        [TypeConverter(typeof(EnumToStringConverter<TaskFlags>))]
        public TaskFlags Flags { get; private set; }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=taskssection">Documentation</a>
        /// </summary>
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

        /// <summary>
        /// Collection of sub-tasks belonging to this one
        /// </summary>
        [Ignore]
        public TChildren Children { get; private set; }

        /// <summary>
        /// Creates a task builder that has children
        /// </summary>
        /// <param name="children">The object whose properties are tasks</param>
        /// <returns>A builder capable of creating a task</returns>
        public static Builder CreateBuilder(TChildren children) => Builder.Create(children);

        /// <summary>
        /// Instantiates and initializes a <see cref="Task{T}"/> object
        /// </summary>
        public class Builder : IBuilder<Task<TChildren>>, ICommonParametersBuilder<Builder>, IPredicatedBuilder<Builder>, IComponentCustomizableBuilder<Builder>
        {
            private readonly Task<TChildren> _task;

            /// <summary>
            /// Create an instance of the <see cref="Builder"/>
            /// </summary>
            /// <returns>A new builder instance</returns>
            public static Builder Create(TChildren children) => new Builder(children);

            /// <see cref="Task{TChildren}.Description"/>
            public Builder Description(string description)
            {
                _task.Description = description;
                return this;
            }

            /// <see cref="Task{TChildren}.GroupDescription"/>
            public Builder GroupDescription(string groupDescription)
            {
                _task.GroupDescription = groupDescription;
                return this;
            }

            /// <see cref="Task{TChildren}.Flags"/>
            public Builder Flags(TaskFlags flags)
            {
                _task.Flags = flags;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language[]>> languages)
            {
                _task.Languages = languages;
                return this;
            }

            /// <inheritdoc/>
            public Builder Languages(Expression<Func<Language>> language)
            {
                _task.Languages = Expression.Lambda<Func<Language[]>>(Expression.NewArrayInit(typeof(Language), language.Body)); ;
                return this;
            }

            /// <inheritdoc/>
            public Builder MinVersion(Version minVersion)
            {
                _task.MinVersion = minVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder OnlyBelowVersion(Version onlyBelowVersion)
            {
                _task.OnlyBelowVersion = onlyBelowVersion;
                return this;
            }

            /// <inheritdoc/>
            public Builder Check(Expression<Func<string, bool>> check)
            {
                _task.Check = check;
                return this;
            }

            /// <inheritdoc/>
            public Builder Components(Expression<Func<bool>> components)
            {
                _task.Components = components;
                return this;
            }

            /// <inheritdoc/>
            public Task<TChildren> Build() => _task;

            private Builder(TChildren children)
            {
                _task = new Task<TChildren>(children);
            }
        }

        private Task(TChildren children)
        {
            Children = children;
        }
    }
}
