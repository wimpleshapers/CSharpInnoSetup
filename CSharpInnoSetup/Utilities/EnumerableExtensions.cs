
using System;
using System.Collections;
using System.Collections.Generic;

namespace CodingMuscles.CSharpInnoSetup.Utilities
{
    /// <summary>
    /// Extension methods for <see cref="IEnumerable"/> and <see cref="IEnumerable{T}"/>
    /// </summary>
    internal static class EnumerableExtensions
    {
        /// <summary>
        /// Performs an action for all elements in a collection
        /// </summary>
        /// <typeparam name="TSource">The collection element type</typeparam>
        /// <param name="source">The collection source</param>
        /// <param name="action">The action to perform</param>
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            foreach (var element in source)
            {
                action(element);
            }
        }


        /// <summary>
        /// Performs an action for all elements in a collection where the element index
        /// is a parameter to the <paramref name="action"/>
        /// </summary>
        /// <typeparam name="TSource">The collection element type</typeparam>
        /// <param name="source">The collection source</param>
        /// <param name="action">The action to perform</param>
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var index = 0;
            foreach (var element in source)
            {
                action(element, index++);
            }
        }
    }
}
