namespace LinkedList.SortedList
{
    public class SortedListNode<T>
    {
        public SortedListNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public SortedListNode<T> Next { get; set; }
        public SortedListNode<T> Previous { get; set; }
    }
}