using System.Linq;
using DataStructure.Set;
using NUnit.Framework;

namespace DataStructureTests.Set
{
    public class UnionFindTests
    {
        [Test]
        public void P_should_be_connected_to_is_self()
        {
            var size = 10;
            var uf = new QuickFind(size);

            var pairs = from i in Enumerable.Range(0, size)
                        from j in Enumerable.Range(0, size)
                        select new {i, j};

            foreach (var pair in pairs)
            {
                Assert.That(uf.IsConnected(pair.i,pair.j), Is.EqualTo(pair.i == pair.j));
            }
            
        }

        [Test]
        public void Q_should_be_connected_to_P_After_connecting_Q_to_P()
        {
            var size = 3;
            var uf = new QuickFind(size);

            var Q = 0;
            var P = 1;
            uf.Connect(Q, P);
            Assert.That(uf.IsConnected(Q, P), Is.True);

        }

        [Test]
        public void Q_should_be_connected_to_P_when_P_is_connected_to_Q()
        {
            var size = 3;
            var uf = new QuickFind(size);

            var Q = 0;
            var P = 1;
            uf.Connect(Q, P);
            Assert.That(uf.IsConnected(Q,P), Is.EqualTo(uf.IsConnected(P,Q)));
            
        }

        [Test]
        public void P_should_be_connected_to_R_when_P_is_connected_to_Q_and_Q_is_connected_R()
        {
            var size = 3;
            var uf = new QuickFind(size);

            var Q = 0;
            var P = 1;
            var R = 2;
            uf.Connect(P, Q);
            uf.Connect(Q, R);
            Assert.That(uf.IsConnected(P, R), Is.True);

        }

        [Test]
        public void coursera()
        {
            var size = 10;
            var uf = new QuickFind(size);

            
            uf.Connect(4, 3);
            uf.Connect(0, 5);
            uf.Connect(7, 9);
            uf.Connect(5, 3);
            uf.Connect(2, 7);
            uf.Connect(9, 1);
            
        }


        // P_should_be_connected_to_is_self // reflexive
        //Q_is_connected_to_P_when_P_is_connected_to_Q // symmetric
        //P_is_coonected_to_R_when_P_is_connected_toQ_and_Q_is_connected_R

    }
}
