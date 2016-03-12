using System.Linq;

namespace DataStructure.Set
{
    public class QuickFind : UnionFindBase
    {
        public QuickFind(int length) : base(length){ }

        /// O(1)
        public override int Find(int p)
        {
            Validate(p);
            return Connections[p];
        }

        /// O(1)
        public override bool IsConnected(int p, int q)
        {
            Validate(p);
            Validate(q);
            return Connections[q] == Connections[p];
        }

        /// O(n)
        public override void Connect(int p, int q)
        {
            var pId = Connections[p];
            var qId = Connections[q];

            if (pId == qId) return;

            for (var i = 0; i < Connections.Length; i++)
            {
                if (Connections[i] == pId) { Connections[i] = qId; }
            }
            Count--;
        }
    }
}