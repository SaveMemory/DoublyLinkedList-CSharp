using System;
using System.Collections;
using System.Collections.Generic;
using LinkedList.DoublyLinkedList;

namespace LinkedList.SortedList
{
    public class SortedList<T> : ICollection where T : IComparable
    {
        public SortedListNode<T> Head { get; private set; }
        public SortedListNode<T> Tail { get; private set; }
        
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

        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        public void Add(T value)
        {
            var adding = new SortedListNode<T>(value);
                
            if (Head == null)
            {
                Head = adding;
                Tail = Head;
            }
            else if(Head.Value.CompareTo(value) >= 0)
            {
                adding.Next = Head;
                Head.Previous = adding;
                Head = adding;
            }
            else if(Tail.Value.CompareTo(value) < 0)
            {
                adding.Previous = Tail;
                Tail.Next = adding;
                Tail = adding;
            }
            else
            {
                var insertBefore = Head;
                while (insertBefore.Value.CompareTo(value) < 0)
                {
                    insertBefore = insertBefore.Next;
                }

                adding.Next = insertBefore;
                adding.Previous = insertBefore.Previous;
                insertBefore.Previous = adding;
            }

            Count++;
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
        
        private SortedListNode<T> Find(T value)
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