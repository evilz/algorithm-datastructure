using DataStructure.Collection.LinkedLists;
using System;
using System.Security.Cryptography;
using Algorithms.Recursion;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Enumerable = System.Linq.Enumerable;

namespace PerfTests
{
    [Config("columns=Min,Max")]
    //[Config("columns=AllStatistics")]
    public class Program
    {
        private const int N = 10000;
        
        [Benchmark]
        public int BasicRecursionTest()
        {
            return BasicRecursion.Factorial(N);
        }

        [Benchmark]
        public int TailRecursionTest()
        {
            return TailRecursion.Factorial(N);
        }

        [Benchmark]
        public int IterativeTest()
        {
            return Iterative.Factorial(N);
        }

        [Benchmark]
        public int EnumerableTest()
        {
            return Algorithms.Recursion.Enumerable.Factorial(N);
        }

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Program>();
            //Console.ReadLine();
            //var enumerable = Enumerable.Range(0, 10000);

            //var list = new SinglyLinkedList<int>(enumerable);
            //Console.ReadLine();
            //list.Clear();

            //Console.ReadLine();

        }
    }
}
