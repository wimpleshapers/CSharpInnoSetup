
using System;
using System.Collections.Generic;

namespace CodingMuscles.CSharpInnoSetup.Utilities
{
    /// <summary>
    /// Extension methods for enumerable types
    /// </summary>
    internal static class EnumExtensions
    {
        /// <summary>
        /// Retrieves the individual flags set in an enueration
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type</typeparam>
        /// <param name="input">The enumerated value with potentially multiple flags set</param>
        /// <returns>A collection of the individual flags set</returns>
        public static IEnumerable<TEnum> GetFlags<TEnum>(this TEnum input) where TEnum : Enum
        {
            foreach (TEnum value in Enum.GetValues(input.GetType()))
            {
                if (input.HasFlag(value))
                {
                    yield return value;
                }
            }
        }
    }
}
