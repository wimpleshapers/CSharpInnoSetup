
using System;

namespace CodingMuscles.CSharpInnoSetup.Generation.Visitor
{
    /// <summary>
    /// A type loaded while decompiling the installation code
    /// </summary>
    public class LoadedType
    {
        /// <summary>
        /// Initializes a new <see cref="LoadedType"/>
        /// </summary>
        /// <param name="pascalTypeName"><see cref="PascalTypeName"/></param>
        /// <param name="csharpType"><see cref="CSharpType"/></param>
        public LoadedType(string pascalTypeName, Type csharpType)
        {
            PascalTypeName = pascalTypeName;
            CSharpType = csharpType;
        }

        /// <summary>
        /// The C# type
        /// </summary>
        public Type CSharpType { get; }

        /// <summary>
        /// The equivalent Pascal name for the type
        /// </summary>
        public string PascalTypeName { get; }
    }
}
