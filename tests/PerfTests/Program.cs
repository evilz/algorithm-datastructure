using DataStructure.Collection.LinkedLists;
using System;
using System.Linq;

namespace PerfTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            var enumerable = Enumerable.Range(0, 10000);

            var list = new SinglyLinkedList<int>(enumerable);
            Console.ReadLine();
            list.Clear();

            Console.ReadLine();
        }
    }
}
