using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace DataStructure.Set
{
    public class QuickFind
    {
        private readonly int[] _connections;

        public QuickFind(int length)
        {
            _connections = Enumerable.Range(0, length).ToArray();
        }

        public bool IsConnected(int p, int q)
        {
            return _connections[q] == _connections[p];
        }

        public void Connect(int p, int q)
        {
            var pid = _connections[p];
            for (var i = 0; i < _connections.Length; i++)
            {
                if (_connections[i] == pid)
                {
                    _connections[i] = _connections[q];
                }
            }
        }
    }
}