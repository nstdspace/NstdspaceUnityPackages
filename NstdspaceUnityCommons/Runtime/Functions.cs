using System;

namespace Nstdspace.Commons
{
    public static class Functions
    {
        public static Func<T, T> Identity<T>()
        {
            return t => t;
        }
    }
}