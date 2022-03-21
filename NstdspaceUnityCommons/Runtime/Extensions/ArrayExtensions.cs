using System;
using System.Linq;

namespace Nstdspace.Commons.Extensions
{
    public static class ArrayExtensions
    {
        public static void ForEach<T>(this T[] array, Action<T> consumer)
        {
            foreach (T t in array)
            {
                consumer(t);
            }
        }

        public static T[] ChooseRandom<T>(this T[] array, int n, bool allowDuplicates = false)
        {
            return array.ToList().ChooseRandom(n, allowDuplicates).ToArray();
        }
    }
}