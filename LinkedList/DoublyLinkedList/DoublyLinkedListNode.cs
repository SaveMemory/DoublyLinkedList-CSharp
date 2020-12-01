namespace LinkedList.DoublyLinkedList
{
    public class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode(T value, DoublyLinkedListNode<T> previous, DoublyLinkedListNode<T> next)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }

        public T Value { get; set; }

        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Previous { get; set; }
    }
}