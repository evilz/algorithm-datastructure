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
            var accumulator = 1;
            while (true)
            {
                if (n < 0) { return 0; }
                if (n <= 1) { return accumulator; }

                accumulator = n*accumulator;
                n--;
            }
        }
    }
}
