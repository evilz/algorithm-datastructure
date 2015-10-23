using System.Linq;

namespace Algorithms.Recursion
{
    public static class BasicRecursion
    {
        public static int Factorial(int n)
        {
            if (n < 0) { return 0; }
            if (n <= 1) { return 1; }
            return n * Factorial(n - 1);
        }
    }

    public static class TailRecursion
    {
        public static int Factorial(int n,int accumulator = 1)
        {
            if (n < 0) { return 0; }
            if (n <= 1) { return accumulator; }
            return Factorial(n - 1, n * accumulator);
        }
    }

    public static class Iterative
    {
        public static int Factorial(int n)
        {
            if (n < 0) { return 0; }

            var accumulator = 1;
            for (var i = 1 ; i <= n; i++)
            {
                accumulator = i * accumulator;
            }
            return accumulator;
        }
    }
    public static class Enumerable
    {
        public static int Factorial(int n)
        {
            if (n < 0) { return 0; }

            return System.Linq.Enumerable.Range(1, n)
                .Aggregate(1, (accumulator, i) => accumulator * i);
        }
    }
}
