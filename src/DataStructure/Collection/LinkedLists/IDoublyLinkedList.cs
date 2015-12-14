namespace DataStructure.Collection.LinkedLists
{
    public interface ISinglyLinkedList<T>
    {
        int Length { get; }

        SinglyLinkedItem<T> Head { get; }
        SinglyLinkedItem<T> Tail { get; }

        ISinglyLinkedList<T> AddAfter(T data, SinglyLinkedItem<T> previousItem);
        ISinglyLinkedList<T> AddAfter(SinglyLinkedItem<T> newItem, SinglyLinkedItem<T> previousItem);

        ISinglyLinkedList<T> AddFirst(T data);
        ISinglyLinkedList<T> AddFirst(SinglyLinkedItem<T> newItem);

        ISinglyLinkedList<T> AddLast(T data);
        ISinglyLinkedList<T> AddLast(SinglyLinkedItem<T> newItem);

        ISinglyLinkedList<T> Clear();

        bool Contains(T data);
        SinglyLinkedItem<T> Find(T data);

        ISinglyLinkedList<T> RemoveFirst();


        ISinglyLinkedList<T> RemoveAfter(SinglyLinkedItem<T> previousItem);

        bool IsHead(SinglyLinkedItem<T> item);
        bool IsTail(SinglyLinkedItem<T> item );

    }
}