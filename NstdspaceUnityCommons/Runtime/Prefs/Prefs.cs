using System;
using UnityEngine;

namespace Nstdspace.Commons.Prefs
{
    public static class Prefs
    {
        public static void Set(StringPrefKey key, string value)
        {
            PlayerPrefs.SetString(key.ToString(), value);
        }

        public static void Set(IntPrefKey key, int value)
        {
            PlayerPrefs.SetInt(key.ToString(), value);
        }

        public static void Set(BoolPrefKey key, bool value)
        {
            PlayerPrefs.SetInt(key.ToString(), value ? 1 : 0);
        }

        public static string Get(StringPrefKey key)
        {
            return PlayerPrefs.GetString(key.ToString(), null);
        }

        public static int Get(IntPrefKey key)
        {
            return PlayerPrefs.GetInt(key.ToString());
        }

        public static bool Get(BoolPrefKey key)
        {
            return PlayerPrefs.GetInt(key.ToString(), 0) == 1;
        }

        public static bool Exists<T>(T key) where T : Enum
        {
            return PlayerPrefs.HasKey(key.ToString());
        }

        public static void Delete<T>(T key) where T : Enum
        {
            PlayerPrefs.DeleteKey(key.ToString());
        }
    }
}