using System;
using System.Collections;
using Algorithms.Sorting;
using DataStructure.Set;
using System.Linq;
using NUnit.Framework;

namespace AlgorithmTests.Sorting
{
    public class SortTests
    {
        private class SortingClasses
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(new Action<int[]>(unsorted => unsorted.SelectionSort())).SetName("Selection Sort");
                    yield return new TestCaseData(new Action<int[]>(unsorted => unsorted.InsertionSort())).SetName("Insertion Sort");

                }
            }

            [Test, TestCaseSource(typeof(SortingClasses), nameof(SortingClasses.TestCases))]
            public void Sould_sort_10_elements(Action<int[]> sortingAlgo)
            {
                var source = new[] { 7, 10, 5, 3, 8, 4, 2, 9, 6, 1 };
                var expectedSorted = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                sortingAlgo(source);

                Assert.That(source, Is.EqualTo(expectedSorted));
            }
        }
    }
}
