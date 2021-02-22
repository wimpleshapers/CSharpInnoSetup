
using System.Collections.Generic;

namespace CodingMuscles.CSharpInnoSetup.Utilities
{
    /// <summary>
    /// Extensions to the type <see cref="IDictionary{TKey, TValue}"/>
    /// </summary>
    internal static class DictionaryExtensions
    {
        /// <summary>
        /// If it does not exist, adds a dictionary entry, otherwise updates it
        /// </summary>
        /// <typeparam name="TKey">The type of key</typeparam>
        /// <typeparam name="TValue">The type of value</typeparam>
        /// <param name="dictionary">The dictionary to affect</param>
        /// <param name="key">The value of the key</param>
        /// <param name="value">The value to set</param>
        /// <returns>The value that was set</returns>
        public static TValue Set<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if(!dictionary.TryAdd(key, value))
            {
                dictionary[key] = value;
            }

            return value;
        }
    }
}
