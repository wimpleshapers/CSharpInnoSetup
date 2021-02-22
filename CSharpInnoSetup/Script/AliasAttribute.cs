
using System;

namespace CodingMuscles.CSharpInnoSetup.Script
{
    /// <summary>
    /// Describes the name a symbol uses when transformed into Inno Setup script
    /// </summary>
    /// <remarks>
    /// A property or method name, for example can appear as-is in an Inno Setup script.  When that is not possible
    /// the <see cref="AliasAttribute"/> must be applied which describes the alternate name to use.
    /// 
    /// If the alias is applied to a generic type, the placeholder {0} in the alias will be replaced with the type name.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Property|AttributeTargets.Field|AttributeTargets.Class, Inherited = true)]
    public class AliasAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new <see cref="AliasAttribute"/>
        /// </summary>
        /// <param name="name"><see cref="Name"/></param>
        public AliasAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The alternate name to use
        /// </summary>
        public string Name { get; }
    }
}
