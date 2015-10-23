namespace DataStructure.Collection.SimpleLinkedList
{
    public class LinkedItem<T>
    {
        public LinkedItem(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public LinkedItem<T> Next { get; set; }
    }
}
