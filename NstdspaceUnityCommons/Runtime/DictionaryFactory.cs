using System;
using System.Collections.Generic;

namespace Nstdspace.Commons
{
    public static class DictionaryFactory
    {
        public static Dictionary<K, V> Of<K, V>(K key, V value)
        {
            Dictionary<K, V> dictionary = new Dictionary<K, V> { { key, value } };

            return dictionary;
        }

        public static Dictionary<K, V> Of<K, V>(K key1, V value1, K key2, V value2)
        {
            Dictionary<K, V> dictionary = new Dictionary<K, V>
            {
                { key1, value1 },
                { key2, value2 }
            };

            return dictionary;
        }

        public static Dictionary<K, V> Of<K, V>(K key1, V value1, K key2, V value2, K key3, V value3)
        {
            Dictionary<K, V> dictionary = new Dictionary<K, V>
            {
                { key1, value1 },
                { key2, value2 },
                { key3, value3 }
            };

            return dictionary;
        }

        public static Dictionary<K, V> Of<K, V>(K key1, V value1, K key2, V value2, K key3, V value3, K key4, V value4)
        {
            Dictionary<K, V> dictionary = new Dictionary<K, V>
            {
                { key1, value1 },
                { key2, value2 },
                { key3, value3 },
                { key4, value4 }
            };

            return dictionary;
        }

        public static Dictionary<K, V> Of<K, V>(K key1, V value1, K key2, V value2, K key3, V value3, K key4, V value4,
            K key5, V value5)
        {
            Dictionary<K, V> dictionary = new Dictionary<K, V>
            {
                { key1, value1 },
                { key2, value2 },
                { key3, value3 },
                { key4, value4 },
                { key5, value5 }
            };

            return dictionary;
        }

        public static Dictionary<K, V> Of<K, V>(K key1, V value1, K key2, V value2, K key3, V value3, K key4, V value4,
            K key5, V value5, K key6, V value6)
        {
            Dictionary<K, V> dictionary = new Dictionary<K, V>
            {
                { key1, value1 },
                { key2, value2 },
                { key3, value3 },
                { key4, value4 },
                { key5, value5 },
                { key6, value6 }
            };

            return dictionary;
        }

        public static Dictionary<K, V> OfMany<K, V>(params (K, V)[] keyValuePairs)
        {
            Dictionary<K, V> dictionary = new Dictionary<K, V>();

            foreach ((K key, V value) in keyValuePairs)
            {
                dictionary.Add(key, value);
            }

            return dictionary;
        }

        public static Dictionary<K, V> OfEnumToDefault<K, V>() where K : Enum
        {
            Dictionary<K, V> dictionary = new Dictionary<K, V>();

            foreach (K enumValue in Enum.GetValues(typeof(K)))
            {
                dictionary.Add(enumValue, default);
            }

            return dictionary;
        }

        public static Dictionary<int, V> EnumKeysToIndices<K, V>(Dictionary<K, V> dictionary) where K : Enum
        {
            Dictionary<int, V> convertedDictionary = new Dictionary<int, V>();

            foreach (KeyValuePair<K, V> keyValuePair in dictionary)
            {
                int index = Array.IndexOf(Enum.GetValues(typeof(K)), keyValuePair.Key);
                convertedDictionary.Add(index, keyValuePair.Value);
            }

            return convertedDictionary;
        }
    }
}