using System;
using System.Collections;
using System.Linq;
using DataStructure.Set;
using NUnit.Framework;

namespace DataStructureTests.Set
{
    public class UnionFindTests
    {
        private class UnionFindClasses
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(new Func<int, IUnionFind>(size => new QuickFind(size))).SetName("QuickFind");
                    yield return new TestCaseData(new Func<int, IUnionFind>(size => new QuickUnion(size))).SetName("QuickUnion");
                    yield return new TestCaseData(new Func<int, IUnionFind>(size => new WeightedQuickUnion(size))).SetName("WeightedQuickUnion");
                }
            }
        }

        [Test, TestCaseSource(typeof(UnionFindClasses), nameof(UnionFindClasses.TestCases))]
        public void P_should_be_connected_to_is_self(Func<int, IUnionFind> ufFactory)
        {
            const int size = 10;
            var unionFind = ufFactory(size);

            Assert.That(unionFind.Count, Is.EqualTo(size));

            foreach (var i in Enumerable.Range(0, size))
            {
                Assert.That(unionFind.IsConnected(i, i), Is.True);
                Assert.That(unionFind.Find(i), Is.EqualTo(i));
            }
        }

        [Test, TestCaseSource(typeof(UnionFindClasses), nameof(UnionFindClasses.TestCases))]
        public void Q_should_be_connected_to_P_After_connecting_Q_to_P(Func<int, IUnionFind> ufFactory)
        {
            int size = 2;
            var unionFind = ufFactory(size);
            var Q = 0;
            var P = 1;

            unionFind.Connect(Q, P);

            Assert.That(unionFind.IsConnected(Q, P), Is.True);
            Assert.That(unionFind.Find(Q),Is.EqualTo(unionFind.Find(P)));
            Assert.That(unionFind.Count, Is.EqualTo(--size));
        }

        [Test, TestCaseSource(typeof(UnionFindClasses), nameof(UnionFindClasses.TestCases))]
        public void Q_should_be_connected_to_P_when_P_is_connected_to_Q(Func<int, IUnionFind> ufFactory)
        {
            var size = 2;
            var unionFind = ufFactory(size);
            var Q = 0;
            var P = 1;

            unionFind.Connect(Q, P);

            Assert.That(unionFind.IsConnected(Q, P), Is.EqualTo(unionFind.IsConnected(P, Q)));

        }

        [Test, TestCaseSource(typeof(UnionFindClasses), nameof(UnionFindClasses.TestCases))]
        public void P_should_be_connected_to_R_when_P_is_connected_to_Q_and_Q_is_connected_R(Func<int, IUnionFind> ufFactory)
        {
            var size = 3;
            var unionFind = ufFactory(size);

            var Q = 0;
            var P = 1;
            var R = 2;

            unionFind.Connect(P, Q);
            unionFind.Connect(Q, R);

            Assert.That(unionFind.IsConnected(P, R), Is.True);
            Assert.That(unionFind.Find(Q), Is.EqualTo(unionFind.Find(R)));
            Assert.That(unionFind.Count, Is.EqualTo(1));

        }

        [Test, TestCaseSource(typeof(UnionFindClasses), nameof(UnionFindClasses.TestCases))]
        public void Senarii_tests(Func<int, IUnionFind> ufFactory)
        {
            var size = 10;
            var unionFind = ufFactory(size);

            Assert.That(unionFind.Count, Is.EqualTo(size));
            
            unionFind.Connect(4, 3);
            Assert.That(unionFind.IsConnected(4, 3), Is.True);
            Assert.That(unionFind.IsConnected(3, 4), Is.True);
            Assert.That(unionFind.Count, Is.EqualTo(--size));

            unionFind.Connect(3, 8);
            Assert.That(unionFind.IsConnected(4, 8), Is.True);
            Assert.That(unionFind.Count, Is.EqualTo(--size));

            unionFind.Connect(6, 5);
            Assert.That(unionFind.IsConnected(6, 5), Is.True);
            Assert.That(unionFind.Count, Is.EqualTo(--size));

            unionFind.Connect(9, 4);
            Assert.That(unionFind.IsConnected(3, 9), Is.True);
            Assert.That(unionFind.Count, Is.EqualTo(--size));
            
            unionFind.Connect(2, 1);
            Assert.That(unionFind.IsConnected(1, 2), Is.True);
            Assert.That(unionFind.Count, Is.EqualTo(--size));

            unionFind.Connect(5, 0);
            Assert.That(unionFind.IsConnected(0, 5), Is.True);
            Assert.That(unionFind.Count, Is.EqualTo(--size));

            unionFind.Connect(7, 2);
            Assert.That(unionFind.IsConnected(7, 1), Is.True);
            Assert.That(unionFind.Count, Is.EqualTo(--size));

            unionFind.Connect(6, 1);
            Assert.That(unionFind.IsConnected(1, 5), Is.True);
            Assert.That(unionFind.Count, Is.EqualTo(--size));

            unionFind.Connect(7, 3);
            Assert.That(unionFind.IsConnected(3, 7), Is.True);
            Assert.That(unionFind.Count, Is.EqualTo(--size));

        }



    }
}
