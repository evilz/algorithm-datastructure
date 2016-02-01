using System.Linq;

namespace DataStructure.Set
{
    public class QuickUnion
    {
        private readonly int[] _connections;

        public QuickUnion(int size)
        {
            _connections = Enumerable.Range(0, size).ToArray();
        }

        private int Root(int i)
        {
            while (i != _connections[i]) i = _connections[i];
            return i;
        }

        public void Connect(int p, int q)
        {
            int i = Root(p);
            int j = Root(q);
            _connections[i] = j;
        }

        public bool IsConnected(int p, int q)
        {
            return Root(p) == Root(q);
        }
    }
}