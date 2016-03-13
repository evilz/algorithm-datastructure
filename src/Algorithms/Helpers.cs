using System;

namespace Algorithms
{
    public static class Helpers
    {
        public static bool IsLessThan<T>(this T v, T w) where T : IComparable
        {
            return v.CompareTo(w) < 0;
        }

        public static bool IsGreaterThan<T>(this T v, T w) where T : IComparable
        {
            return v.CompareTo(w) > 0;
        }

        public static bool IsEqualTo<T>(this T v, T w) where T : IComparable
        {
            return v.CompareTo(w) > 0;
        }

        public static void Swap<T>(this T[] source, int i, int j)
        {
            T swap = source[i];
            source[i] = source[j];
            source[j] = swap;
        }
    }
}
