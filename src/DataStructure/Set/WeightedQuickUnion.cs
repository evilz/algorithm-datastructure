using System.Linq;

namespace DataStructure.Set
{
    public class WeightedQuickUnion
    {
        private readonly int[] _connections;
        private readonly int[] _connectionsSizes;

        public WeightedQuickUnion(int size)
        {
            _connections = Enumerable.Range(0, size).ToArray();
            _connectionsSizes = Enumerable.Repeat(1, size).ToArray();
        }

        private int Root(int i)
        {
            while (i != _connections[i])
            {
                 CompressPath(i);
                i = _connections[i];
            }
            return i;
        }

        private void CompressPath(int i)
        {
            _connections[i] = _connections[_connections[i]];
        }

        public void Connect(int p, int q)
        {
            int i = Root(p);
            int j = Root(q);

            if (_connectionsSizes[i] <= _connectionsSizes[j])
            {
                _connections[i] = j;
                _connectionsSizes[j] += _connectionsSizes[i];
            }
            else
            {
                _connections[j] = i;
                _connectionsSizes[i] += _connectionsSizes[j];
            }
            
        }

        public bool IsConnected(int p, int q)
        {
            return Root(p) == Root(q);
        }
    }
}