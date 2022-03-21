using System.Collections.Generic;

namespace Nstdspace.Commons.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        ///     Adds all entries from the other dictionary to the dictionary this method is called on.
        ///     Note that values which already existed are overwritten if they appear in the given other dictionary.
        /// </summary>
        public static void AddRange<K, V1, V2>(this Dictionary<K, V1> self, Dictionary<K, V2> other) where V2 : V1
        {
            foreach (KeyValuePair<K, V2> keyValuePair in other)
            {
                self[keyValuePair.Key] = keyValuePair.Value;
            }
        }
    }
}