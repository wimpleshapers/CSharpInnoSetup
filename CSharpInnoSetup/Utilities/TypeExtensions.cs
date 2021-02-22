
using System;

namespace CodingMuscles.CSharpInnoSetup.Utilities
{
    /// <summary>
    /// Extensions to the <see cref="Type"/> class
    /// </summary>
    internal static class TypeExtensions
    {
        /// <summary>
        /// Determines if a <see cref="Type"/> belongs to a struct
        /// </summary>
        /// <param name="type">The type to test</param>
        /// <returns>True if it is a struct, otherwise false</returns>
        public static bool IsStruct(this Type type)
        {
            return type.IsValueType && !type.IsPrimitive && !type.IsEnum;
        }
    }
}
