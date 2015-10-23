using System;
using System.Linq;
using DataStructure.Collection.SimpleLinkedList;

namespace PerfTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            var enumerable = Enumerable.Range(0, 10000);

            var list = new LinkedList<int>(enumerable);
            Console.ReadLine();
            list.Clear();

            Console.ReadLine();
        }
    }
}
