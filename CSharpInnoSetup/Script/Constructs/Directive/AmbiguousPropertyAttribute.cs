
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Applied to a property that is expanded into multiple script directives
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    internal class AmbiguousPropertyAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new <see cref="AmbiguousPropertyAttribute"/>
        /// </summary>
        /// <param name="name"><see cref="Name"/></param>
        /// <param name="typeConverter"><see cref="TypeConverter"/></param>
        public AmbiguousPropertyAttribute(string name, Type typeConverter)
        {
            Name = name;
            TypeConverter = typeConverter;
        }

        /// <summary>
        /// The name of the directive
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// The <see cref="TypeConverter"/> to use to transform the underlying value
        /// </summary>
        public Type TypeConverter { get; }
    }
}
