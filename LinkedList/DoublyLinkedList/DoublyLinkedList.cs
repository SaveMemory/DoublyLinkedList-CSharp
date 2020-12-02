using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : ICollection
    {
        public DoublyLinkedListNode<T> Head { get; private set; }
        public DoublyLinkedListNode<T> Tail { get; private set; }
        
        public int Count { get; private set; }
        public bool IsSynchronized { get; private set; }
        public object SyncRoot { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;

            while (current.Next != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetReverseEnumerator()
        {
            var current = Tail;

            while (current.Previous != null)
            {
                yield return current.Value;
                current = current.Previous;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }
        
        public void AddHead(T value)
        {
            var adding = new DoublyLinkedListNode<T>(value, null, Head);
            
            if (Head != null)
            {
                Head.Previous = adding;
            }

            Head = adding;

            Tail ??= Head;

            Count++;
        }

        public void AddTail(T value)
        {
            var adding = new DoublyLinkedListNode<T>(value, null, Tail);

            if (Tail != null)
            {
                Tail.Next = adding;
            }

            Tail = adding;

            Head ??= Tail;
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        public bool Remove(T value)
        {
            var found = Find(value);
            
            if (found == null)
            {
                return false;
            }

            var previous = found.Previous;
            var next = found.Next;

            if (previous is null)
            {
                Head = next;
                if (Head != null)
                {
                    Head.Previous = null;
                }
            }
            else
            {
                previous.Next = next;
            }

            if (next is null)
            {
                Tail = previous;

                if (Tail != null)
                {
                    Tail.Next = null;
                }
            }
            else
            {
                next.Previous = previous;
            }

            Count--;

            return true;
        }
        
        private DoublyLinkedListNode<T> Find(T value)
        {
            var current = Head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                    return current;

                current = current.Next;
            }

            return null;
        }
    }
}