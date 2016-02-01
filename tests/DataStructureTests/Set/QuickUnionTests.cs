using System.Linq;
using DataStructure.Set;
using NUnit.Framework;

namespace DataStructureTests.Set
{
    public class QuickUnionTests
    {
        [Test]
        public void P_should_be_connected_to_is_self()
        {
            var size = 10;
            var set = new QuickUnion(size);

            var pairs = from i in Enumerable.Range(0, size)
                        from j in Enumerable.Range(0, size)
                        select new {i, j};

            foreach (var pair in pairs)
            {
                Assert.That(set.IsConnected(pair.i,pair.j), Is.EqualTo(pair.i == pair.j));
            }
            
        }

        [Test]
        public void Q_should_be_connected_to_P_After_connecting_Q_to_P()
        {
            var size = 3;
            var set = new QuickUnion(size);

            var Q = 0;
            var P = 1;
            set.Connect(Q, P);
            Assert.That(set.IsConnected(Q, P), Is.True);

        }

        [Test]
        public void Q_should_be_connected_to_P_when_P_is_connected_to_Q()
        {
            var size = 3;
            var set = new QuickUnion(size);

            var Q = 0;
            var P = 1;
            set.Connect(Q, P);
            Assert.That(set.IsConnected(Q,P), Is.EqualTo(set.IsConnected(P,Q)));
            
        }

        [Test]
        public void P_should_be_connected_to_R_when_P_is_connected_to_Q_and_Q_is_connected_R()
        {
            var size = 3;
            var set = new QuickUnion(size);

            var Q = 0;
            var P = 1;
            var R = 2;
            set.Connect(P, Q);
            set.Connect(Q, R);
            Assert.That(set.IsConnected(P, R), Is.True);

        }
    }
}
