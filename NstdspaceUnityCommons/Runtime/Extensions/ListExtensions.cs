using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Nstdspace.Commons.Extensions
{
    public static class ListExtensions
    {
        public static List<T> Shuffle<T>(this List<T> list)
        {
            List<T> copy = new List<T>(list);
            int count = copy.Count;
            int lastIndex = count - 1;

            for (int currentIndex = 0; currentIndex < lastIndex; currentIndex++)
            {
                int newIndex = Random.Range(currentIndex, count);
                copy.SwapElements(currentIndex, newIndex);
            }

            return copy;
        }

        public static T ChooseRandom<T>(this List<T> list)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Cannot choose element from empty list.");
            }

            return list[Random.Range(0, list.Count)];
        }

        public static int ChooseRandomIndex<T>(this List<T> list)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Cannot choose index from empty list.");
            }

            return Random.Range(0, list.Count);
        }

        public static List<T> ChooseRandom<T>(this List<T> list, int n, bool allowDuplicates = false)
        {
            if (list.Count < n && !allowDuplicates)
            {
                throw new InvalidOperationException(
                    $"Cannot choose {n} distinct elements from list with {list.Count} elements!");
            }

            List<T> copy = new List<T>(list);
            List<T> chosen = new List<T>();
            for (int i = 0; i < n; i++)
            {
                int randomIndex = copy.ChooseRandomIndex();
                T shape = copy[randomIndex];
                if (!allowDuplicates)
                {
                    copy.RemoveAt(randomIndex);
                }

                chosen.Add(shape);
            }

            return chosen;
        }

        public static List<int> ChooseRandomIndices<T>(this List<T> list, int n, bool allowDuplicates = false)
        {
            return IndexSequence(list).ChooseRandom(n, allowDuplicates);
        }

        public static List<int> IndexSequence<T>(this List<T> list)
        {
            return SequenceUtils.IdentitySequence(list.Count);
        }

        public static void SwapElements<T>(this List<T> list, int index1, int index2)
        {
            (list[index1], list[index2]) = (list[index2], list[index1]);
        }
    }
}