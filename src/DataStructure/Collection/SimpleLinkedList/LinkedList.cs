using System.Collections.Generic;

namespace DataStructure.Collection.SimpleLinkedList
{
    public class LinkedList<T> : ILinkedList<T>
    {
        public LinkedList(IEnumerable<T> datas = null)
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
        public LinkedItem<T> Head { get; private set; }
        public LinkedItem<T> Tail { get; private set; }

        public ILinkedList<T> AddAfter(T data, LinkedItem<T> previousItem)
        {
            return AddAfter(new LinkedItem<T>(data), previousItem);
        }

        public ILinkedList<T> AddAfter(LinkedItem<T> newItem, LinkedItem<T> previousItem)
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

        public ILinkedList<T> AddFirst(T data)
        {
            return AddFirst(new LinkedItem<T>(data));
        }

        public ILinkedList<T> AddFirst(LinkedItem<T> newItem)
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

        public ILinkedList<T> AddLast(T data)
        {
            return AddLast(new LinkedItem<T>(data));
        }

        public ILinkedList<T> AddLast(LinkedItem<T> newItem)
        {
            Tail.Next = newItem;
            Tail = Tail.Next;
            IncrementLength();
            return this;
        }

        public ILinkedList<T> Clear()
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

        public LinkedItem<T> Find(T data)
        {
            var item = Head;
            while (item != null)
            {
                if (item.Data.Equals(data)) return item;

                item = item.Next;
            }
            return null;
        }

        public ILinkedList<T> RemoveFirst()
        {
            Head = Head.Next;

            if (Head == null)
            {
                Tail = null;
            }
            DecrementLength();
            return this;
        }

        public ILinkedList<T> RemoveAfter(LinkedItem<T> previousItem)
        {
            if (previousItem.Next == null) return this;

            previousItem.Next = previousItem.Next.Next;
            DecrementLength();
            return this;
        }
        
        public bool IsHead(LinkedItem<T> item)
        {
            return Head == item;
        }

        public bool IsTail(LinkedItem<T> item)
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