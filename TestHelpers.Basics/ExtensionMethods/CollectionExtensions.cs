using System;
using System.Collections.Generic;

namespace TestHelpers.Basics
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Checks that both the list and the item are valid instances (not null) 
        /// before adding the item to the list.
        /// </summary>
        public static void AddIfNotNull<T>(this List<T> items, T item)
            where T : class
        {
            if (items == null) return;
            if (item == null) return;

            items.Add(item);
        }

        /// <summary>
        /// "Safe" version of ForEach that checks if the collection is null before trying 
        /// to iterate it.
        /// </summary>
        public static void ForAll<T>(this IReadOnlyCollection<T> items, Action<T> action)
        {
            if (items == null) return;

            foreach (var item in items)
            {
                action(item);
            }
        }

        /// <summary>
        /// Wraps an object in an array and returns it as a IReadOnlyList
        /// </summary>
        public static IReadOnlyList<T> AsReadOnlyList<T>(this T @object)
        {
            return new[] { @object };
        }

        /// <summary>
        /// Wraps an object in an array and returns it as a IReadOnlyCollection
        /// </summary>
        public static IReadOnlyCollection<T> AsReadOnlyCollection<T>(this T @object)
        {
            return new[] { @object };
        }
    }
}