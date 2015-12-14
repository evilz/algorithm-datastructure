namespace DataStructure.Collection.LinkedLists
{
    
    public class SinglyLinkedItem<T>
    {
        public SinglyLinkedItem(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public SinglyLinkedItem<T> Next { get; set; }
    }
}
