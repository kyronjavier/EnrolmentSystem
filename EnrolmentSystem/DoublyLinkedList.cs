using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnrolmentSystem
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }

        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            // save the head node in a temp variable so we won't lose it
            LinkedListNode<T> temp = Head;

            // point head to the new node
            Head = node;

            // insert the rest of the list behind the head
            Head.Next = temp;

            if(Count == 0)
            {
                Tail = Head;
            }
            else
            {
                // before: Head ------> 5 <-> 7 -> null
                // after: Head -> 3 <-> 5 <-> 7 -> null


                // temp.Previous was null, now Head
                temp.Previous = Head;
            }
            Count++;
        }

        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        public void AddLast(LinkedListNode<T> node)
        {
            // case when no nodes, we add the first node
            // which is both the Head and Tail
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            Count++;
        }

        public LinkedListNode<T> Find(T value)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public T RemoveFirst()
        {
            if (Head == null)
                throw new InvalidOperationException("The list is empty.");

            var value = Head.Value;
            Head = Head.Next;
            if (Head == null)
            {
                Tail = null;
            }
            else
            {
                Head.Previous = null;
            }
            return value;
        }

        public T RemoveLast()
        {
            if (Tail == null)
                throw new InvalidOperationException("The list is empty.");

            var value = Tail.Value;
            Tail = Tail.Previous;
            if (Tail == null)
            {
                Head = null;
            }
            else
            {
                Tail.Next = null;
            }
            return value;
        }

    public void Add(T item)
        {
            AddFirst(item);
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                // Head -> 3 -> 5 -> 7
                // Value: 5
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool IsReadOnly {  get { return false; } }

        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = Head;

            // scenarios: 
            // 1. Empty list, current == null, do nothing return false
            // 2. Single node, then previous == null
            // 3. Multiple nodes:
            //          a. node to be removed is the first node
            //          b. node to remove is in the middle or last

            while (current != null)
            {
                if(current.Value.Equals(item)) { 
                // 3b: if its a node in the middle or end
                    if (previous == null) {
                        // Eg. Head -> 3 -> 5 -> null
                        //     Head -> 3 ------> null
                        previous.Next = current.Next;

                        if(current.Next == null) {
                            Tail = previous;
                        }
                        else
                        {
                            // remove 5
                            // before: Head -> 3 <-> 5 <-> 7 <-> null
                            // after: Head -> 3 <-> 7 -> null
                            current.Next.Previous = previous;
                        }
                        Count--;
                    }
                    else
                    {
                        // case 2 or 3a
                        RemoveFirst();
                    }
                    return true; // node removed
                }
                previous = current;
                current = current.Next;
            }
            return false; // no nodes to remove
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            Head = null;
            Tail =null;
            Count = 0;
        }


    }
}
