using Algorithms.Sorting;
using NUnit.Framework;

namespace AlgorithmTests
{
    public class MergeSort
    {
        [Test]
        [Ignore("not implemented !")]
        public void Should_return_a_sorted_array()
        {
            var input = new [] {0, 9, 8, 3, 5, 1, 6, 2, 4, 7};
            var expected = new [] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

            var actual = input.MergeSort();
            Assert.That(actual, Is.EquivalentTo(expected));
        }
    }
}
