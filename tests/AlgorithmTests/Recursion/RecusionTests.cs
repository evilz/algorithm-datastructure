using Algorithms.Recursion;
using NUnit.Framework;

namespace AlgorithmTests.Recursion
{
    public class RecusionTests
    {
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(1000)]
        public void Factorial_should_return_same_result_for_all_implementations(int n)
        {
            var basicResult = BasicRecursion.Factorial(n);
            var tailResult = TailRecursion.Factorial(n);
            var iterrativeResult = Iterative.Factorial(n);
            var enumerableResult = Enumerable.Factorial(n);

            Assert.That(basicResult,Is.EqualTo(tailResult));
            Assert.That(basicResult,Is.EqualTo(iterrativeResult));
            Assert.That(basicResult,Is.EqualTo(enumerableResult));
        }
    }
}
