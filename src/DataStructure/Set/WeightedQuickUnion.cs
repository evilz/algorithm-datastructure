using System.Linq;

namespace DataStructure.Set
{
    public class WeightedQuickUnion : UnionFindBase
    {
        private readonly bool _compressed;
        private readonly int[] _connectionsSizes;

        public WeightedQuickUnion(int length, bool compressed = true) : base(length)
        {
            _compressed = compressed;
            _connectionsSizes = Enumerable.Repeat(1, length).ToArray();
        }

        public override int Find(int p)
        {
            Validate(p);
            while (p != Connections[p])
            {
                if(_compressed) { CompressPath(p);}
                p = Connections[p];
            }
            return p;
        }
        
        private void CompressPath(int i)
        {
            Connections[i] = Connections[Connections[i]];
        }

        public override void Connect(int p, int q)
        {
            var rootP = Find(p);
            var rootQ = Find(q);
            if (rootP == rootQ) return;

            // make smaller root point to larger one
            if (_connectionsSizes[rootP] < _connectionsSizes[rootQ])
            {
                Connections[rootP] = rootQ;
                _connectionsSizes[rootQ] += _connectionsSizes[rootP];
            }
            else {
                Connections[rootQ] = rootP;
                _connectionsSizes[rootP] += _connectionsSizes[rootQ];
            }
            Count--;
        }

        public override bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }
    }
}