using System;

namespace Algorithms.Sorting
{
    public static class InsertionSortExt
    {
        public static void InsertionSort<T>(this T[] source) where T : IComparable
        {
            for (var i = 0; i < source.Length; i++)
            {
                for (var j = i; j.IsGreaterThan(0) && source[j].IsLessThan(source[j - 1]); j--)
                {
                    source.Swap(j, j - 1);
                }
            }
        }
    }
}
