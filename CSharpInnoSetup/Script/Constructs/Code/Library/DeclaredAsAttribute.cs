
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Applied to types that should be declared in script using an alias <see cref="Type"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Delegate | AttributeTargets.Interface)]
    public sealed class DeclaredAsAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new <see cref="DeclaredAsAttribute"/>
        /// </summary>
        /// <param name="declaredType"><see cref="DeclaredType"/></param>
        public DeclaredAsAttribute(Type declaredType)
        {
            DeclaredType = declaredType;
        }

        /// <summary>
        /// The alias <see cref="Type"/> used to declare this type in script
        /// </summary>
        public Type DeclaredType { get; }
    }
}
