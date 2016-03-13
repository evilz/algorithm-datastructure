using System;

namespace Algorithms.Sorting
{
    public static class SelectionSortExt
    {
        public static void SelectionSort<T>(this T[] source) where T : IComparable
        {
            for (var i = 0; i < source.Length; i++)
            {
                var minIndex = i;
                for (var j = i+1; j < source.Length; j++)
                {
                    if (source[j].IsLessThan(source[minIndex]))
                    {
                        minIndex = j;
                    }
                    source.Swap(i,minIndex);
                }
            }
        }
    }
}
