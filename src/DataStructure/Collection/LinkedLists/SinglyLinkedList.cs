using System.Collections.Generic;

namespace DataStructure.Collection.LinkedLists
{
    public class SinglyLinkedList<T> : ISinglyLinkedList<T>
    {
        public SinglyLinkedList(IEnumerable<T> datas = null)
        {
            if (datas == null) { return; }

            foreach (var data in datas)
            {
                if (Head == null)
                {
                    AddFirst(data);
                }
                else
                {
                    AddLast(data);
                }
            }
        }

        public int Length { get; private set; }
        public SinglyLinkedItem<T> Head { get; private set; }
        public SinglyLinkedItem<T> Tail { get; private set; }

        public ISinglyLinkedList<T> AddAfter(T data, SinglyLinkedItem<T> previousItem)
        {
            return AddAfter(new SinglyLinkedItem<T>(data), previousItem);
        }

        public ISinglyLinkedList<T> AddAfter(SinglyLinkedItem<T> newItem, SinglyLinkedItem<T> previousItem)
        {
            if (previousItem == null) return this;

            previousItem.Next = newItem;
            IncrementLength();

            if (IsTail(previousItem))
            {
                Tail = newItem;
            }

            return this;
        }

        public ISinglyLinkedList<T> AddFirst(T data)
        {
            return AddFirst(new SinglyLinkedItem<T>(data));
        }

        public ISinglyLinkedList<T> AddFirst(SinglyLinkedItem<T> newItem)
        {
            newItem.Next = Head;
            Head = newItem;

            if (Tail == null)
            {
                Tail = newItem;
            }

            IncrementLength();
            return this;
        }

        public ISinglyLinkedList<T> AddLast(T data)
        {
            return AddLast(new SinglyLinkedItem<T>(data));
        }

        public ISinglyLinkedList<T> AddLast(SinglyLinkedItem<T> newItem)
        {
            Tail.Next = newItem;
            Tail = Tail.Next;
            IncrementLength();
            return this;
        }

        public ISinglyLinkedList<T> Clear()
        {
            Length = 0;
            Head = null;
            Tail = null;
            return this;
        }

        public bool Contains(T data)
        {
            return Find(data) != null;
        }

        public SinglyLinkedItem<T> Find(T data)
        {
            var item = Head;
            while (item != null)
            {
                if (item.Data.Equals(data)) return item;

                item = item.Next;
            }
            return null;
        }

        public ISinglyLinkedList<T> RemoveFirst()
        {
            Head = Head.Next;

            if (Head == null)
            {
                Tail = null;
            }
            DecrementLength();
            return this;
        }

        public ISinglyLinkedList<T> RemoveAfter(SinglyLinkedItem<T> previousItem)
        {
            if (previousItem.Next == null) return this;

            previousItem.Next = previousItem.Next.Next;
            DecrementLength();
            return this;
        }
        
        public bool IsHead(SinglyLinkedItem<T> item)
        {
            return Head == item;
        }

        public bool IsTail(SinglyLinkedItem<T> item)
        {
            return Tail == item;
        }

        private void IncrementLength()
        {
            ++Length;
        }
        private void DecrementLength()
        {
            --Length;
        }
    }
}