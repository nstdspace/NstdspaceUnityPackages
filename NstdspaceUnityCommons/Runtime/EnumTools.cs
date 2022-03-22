using System;
using System.Collections.Generic;

namespace Nstdspace.Commons
{
    public static class EnumTools
    {
        private static readonly Random random = new Random();

        public static T GetRandomEnumValue<T>() where T : Enum
        {
            return GetRandomEnumValue<T>(random);
        }

        public static T GetRandomEnumValue<T>(Random random) where T : Enum
        {
            Array values = Enum.GetValues(typeof(T));
            return (T) values.GetValue(random.Next(values.Length));
        }

        public static int GetValueCount<T>()
        {
            return Enum.GetValues(typeof(T)).Length;
        }

        public static List<T> EnumToList<T>() where T : Enum
        {
            List<T> valueList = new List<T>();
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                valueList.Add(item);
            }

            return valueList;
        }

        public static T GetEnumValue<T>(int index) where T : Enum
        {
            return EnumToList<T>()[index];
        }

        public static int IndexOf<T>(T t) where T : Enum
        {
            return EnumToList<T>().IndexOf(t);
        }
    }
}