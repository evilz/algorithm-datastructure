using System.Linq;
using DataStructure.Collection.LinkedLists;
using NUnit.Framework;

namespace DataStructureTests.Collection.SimpleLinkedList
{
    public class SimpleLinkedListTests
    {
        
        [TestCase]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9)]
        public void Length_should_be_same_as_enumerable_count_when_instanced(params int[] datas)
        {
            var list = new SinglyLinkedList<int>(datas);
            Assert.That(list.Length, Is.EqualTo(datas.Length));
        }


        [TestCase(1)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9)]
        public void should_contains_item_in_same_order(params int[] datas)
        {
            var list = new SinglyLinkedList<int>(datas);

            var item = list.Head;
            var i = 0;
            while (item != null)
            {
                Assert.That(item.Data,Is.EqualTo(datas[i]));
                item = item.Next;
                i++;
            }
            Assert.That(i, Is.EqualTo(datas.Length));
            
            Assert.That(list.Head.Data,Is.EqualTo(datas[0]));
            Assert.That(list.Tail.Data,Is.EqualTo(datas.Last()));
        }

        [Test]
        public void AddAfter_Should_change_tail_and_set_next_item_of_previous_item()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new [] {1});

            var previous = list.Head;
            list = list.AddAfter(2,previous);
            Assert.That(list.Tail.Data,Is.EqualTo(2));
            Assert.That(previous.Next, Is.EqualTo(list.Tail));
            list = list.AddAfter(3, previous);
            Assert.That(list.Tail.Data, Is.EqualTo(2));
            Assert.That(previous.Next.Data, Is.EqualTo(3));
        }

        [Test]
        public void AddFirst_Should_change_head()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new[] { 1 });
            list = list.AddFirst(2);
            Assert.That(list.Head.Data, Is.EqualTo(2));
        }

        [Test]
        public void AddFirst_Should_change_tail_when_tail_is_null()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new int[0]);
            list = list.AddFirst(1);
            Assert.That(list.Head.Data, Is.EqualTo(1));
            Assert.That(list.Tail.Data, Is.EqualTo(1));
        }

        [Test]
        public void AddLast_Should_change_tail_and_set_next_of_previous_tail()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new[] { 1 });

            var previous = list.Tail;
            list = list.AddLast(2);
            Assert.That(list.Tail.Data, Is.EqualTo(2));
            Assert.That(previous.Next, Is.EqualTo(list.Tail));
            
        }

        [Test]
        public void Adding_Should_increment_length()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new[] { 1 });
            Assert.That(list.Length, Is.EqualTo(1));

            list = list.AddAfter(2,list.Tail);
            Assert.That(list.Length, Is.EqualTo(2));

            list = list.AddFirst(3);
            Assert.That(list.Length, Is.EqualTo(3));

            list = list.AddLast(4);
            Assert.That(list.Length, Is.EqualTo(4));

        }

        [Test]
        public void IsHead_should_return_true_when_item_is_equal_to_list_head()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new[] { 1,2,3 });
            Assert.IsTrue(list.IsHead(list.Head));
            Assert.IsFalse(list.IsHead(list.Tail));
        }

        [Test]
        public void IsTail_should_return_true_when_item_is_equal_to_list_tail()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new[] { 1, 2, 3 });
            Assert.IsTrue(list.IsTail(list.Tail));
            Assert.IsFalse(list.IsTail(list.Head));         
        }

        [Test]
        public void RemoveFirst_Should_change_head()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new[] { 1,2,3 });
            
            list = list.RemoveFirst();
            Assert.That(list.Head.Data, Is.EqualTo(2));
        }

        [Test]
        public void RemoveFirst_Should_change_tail_when_list_is_empty()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new[] { 1});

            list = list.RemoveFirst();
            Assert.That(list.Head, Is.Null);
            Assert.That(list.Tail, Is.Null);
        }

        [Test]
        public void RemoveAfter_Should_change_next_of_previous_item()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new[] { 1, 2, 3 });

            var previous = list.Head;
            list.RemoveAfter(previous);
            Assert.That(previous.Next.Data, Is.EqualTo(3));
        }

        [Test]
        public void Removing_Should_decrement_length()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new[] { 1,2,3 });
            Assert.That(list.Length, Is.EqualTo(3));

            list = list.RemoveFirst();
            Assert.That(list.Length, Is.EqualTo(2));

            list = list.RemoveAfter(list.Head);
            Assert.That(list.Length, Is.EqualTo(1));
            
        }

        [Test]
        public void Length_should_be_0_when_list_is_clear()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new[] { 1, 2, 3 });
            list = list.Clear();
            Assert.That(list.Length,Is.EqualTo(0));
        }

        [Test]
        public void Head_and_tail_and_should_be_null_when_list_is_clear()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new[] { 1, 2, 3 });
            list = list.Clear();
            Assert.That(list.Head, Is.Null);
            Assert.That(list.Tail, Is.Null);
        }

        [Test]
        public void Find_should_return_LinkedItem_when_exist()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new[] { 1, 2, 3 });
            var item = list.Find(3);
            Assert.That(item, Is.Not.Null);
            Assert.That(item.Data, Is.EqualTo(3));
            Assert.That(item, Is.EqualTo(list.Tail));
        }

        [Test]
        public void Find_should_return_null_when_does_not_exist()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new[] { 1, 2, 3 });
            var item = list.Find(4);
            Assert.That(item, Is.Null);
        }

        [Test]
        public void Contains_should_return_true_when_exist()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new[] { 1, 2, 3 });
            var result = list.Contains(3);
            Assert.That(result, Is.True);
            
        }
        [Test]
        public void Contains_should_return_false_when_doesnot_exist()
        {
            ISinglyLinkedList<int> list = new SinglyLinkedList<int>(new[] { 1, 2, 3 });
            var result = list.Contains(4);
            Assert.That(result, Is.False);

        }
    }
}
