using System;
using System.Linq;

namespace DataStructure.Set
{
    public abstract class UnionFindBase : IUnionFind
    {
        protected readonly int[] Connections;
        public int Count { get; protected set; }

        /// <summary>
        /// Initializes an empty union-find data structure with length items
        /// Each item is initially in its own set.
        /// O(n)
        /// </summary>
        /// <param name="length"></param>
        protected UnionFindBase(int length)
        {
            Connections = Enumerable.Range(0, length).ToArray();
            Count = length;
        }

        /// <summary>
        /// Check item range value
        /// </summary>
        /// <param name="p"></param>
        protected void Validate(int p)
        {
            if (p < 0 || p >= Connections.Length)
            {
                throw new IndexOutOfRangeException("index " + p + " is not between 0 and " + (Connections.Length - 1));
            }
        }

        public abstract bool IsConnected(int p, int q);

        public abstract void Connect(int p, int q);

        public abstract int Find(int p);
    }
}