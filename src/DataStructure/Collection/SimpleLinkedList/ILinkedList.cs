using System;

namespace DataStructure.Collection.SimpleLinkedList
{
    public interface ILinkedList<T>
    {
        int Length { get; }

        LinkedItem<T> Head { get; }
        LinkedItem<T> Tail { get; }

        ILinkedList<T> AddAfter(T data, LinkedItem<T> previousItem);
        ILinkedList<T> AddAfter(LinkedItem<T> newItem, LinkedItem<T> previousItem);

        ILinkedList<T> AddFirst(T data);
        ILinkedList<T> AddFirst(LinkedItem<T> newItem);

        ILinkedList<T> AddLast(T data);
        ILinkedList<T> AddLast(LinkedItem<T> newItem);

        ILinkedList<T> Clear();

        bool Contains(T data);
        LinkedItem<T> Find(T data);

        ILinkedList<T> RemoveFirst();


        ILinkedList<T> RemoveAfter(LinkedItem<T> previousItem);

        bool IsHead(LinkedItem<T> item);
        bool IsTail(LinkedItem<T> item );

    }
}