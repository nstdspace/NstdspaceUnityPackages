using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nstdspace.Commons.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Helper function to convert an enumerable to a set.
        ///     Useful in LINQ chains.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static HashSet<T> ToSet<T>(this IEnumerable<T> enumerable)
        {
            return new HashSet<T>(enumerable);
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> consumer) =>
            ForEach(enumerable, (t, _) => consumer(t));

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> consumer)
        {
            int index = 0;
            foreach (T t in enumerable)
            {
                consumer(t, index);
                index++;
            }
        }
        
        public static void ForEach<T>(this IEnumerable enumerable, Action<T> consumer)
        {
            foreach (T o in enumerable)
            {
                consumer(o);
            }
        }

        public static T ChooseRandom<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.ToList().ChooseRandom();
        }

        public static T ChooseRandomOrDefault<T>(this IEnumerable<T> enumerable)
        {
            if (!enumerable.Any())
            {
                return default;
            }

            return enumerable.ChooseRandom();
        }

        public static int ChooseRandomIndex<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.ToList().ChooseRandomIndex();
        }

        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> enumerable, Predicate<T> predicate) =>
            enumerable.WhereNot((t, _) => predicate(t));

        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> enumerable, Func<T, int, bool> predicate)
        {
            int index = 0;
            foreach (T t in enumerable)
            {
                if (!predicate(t, index))
                {
                    yield return t;
                }
                index++;
            }
        }
    }
}