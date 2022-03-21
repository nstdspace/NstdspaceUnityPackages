using System;
using System.Collections.Generic;
using System.Linq;
using Nstdspace.Commons.Extensions;

namespace Nstdspace.Commons
{
    public static class SequenceUtils
    {
        public static List<T> Sequence<T>(int count, Func<T> provider)
        {
            return Sequence(count, i => provider());
        }

        public static List<T> Sequence<T>(int count, Func<int, T> provider)
        {
            return new T[count].ToList().Select((element, index) => provider(index)).ToList();
        }

        public static List<int> IdentitySequence(int n)
        {
            return Sequence(n, i => i).ToList();
        }

        /// <param name="n">length of the sequence</param>
        /// <param name="min">min value</param>
        /// <param name="max">max value</param>
        /// <param name="allowDuplicates">if duplicate values should be allowed</param>
        /// <returns>sequence of length n with values between min (inclusive) and max (inclusive)</returns>
        public static List<int> RandomBetween(int n, int min, int max, bool allowDuplicates = false)
        {
            return Sequence(max - min + 1, i => i + min).ChooseRandom(n, allowDuplicates);
        }

        public static List<int> IndexSequence(this List<int> list)
        {
            return IdentitySequence(list.Count);
        }
    }
}