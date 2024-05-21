using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrolmentSystem
{
    public class SingleLinkedList<T>: ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set;}

        public LinkedListNode<T> Tail { get; private set;}

        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            // Save the head node to a temp so we don't lose it
            // need to set the new Head node Next to it
            LinkedListNode<T> temp = Head;

            // point head to the new node
            Head = node;

            // insert the rest of the list to the head Next
            Head.Next = temp;
            Count ++;

            if (Count == 1)
            {
                Tail = Head;
            }
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
            }
            Tail = node;
            Count ++;
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
            // before: Head -> 3 -> 5
            // after: Head -------> 5

            // Head -> 3 -> null
            // Head ------> null

            if (Head == null)
                throw new InvalidOperationException("The list is empty.");

            var value = Head.Value;
            Head = Head.Next;
            if (Head == null)
            {
                Tail = null;
            }
            return value;

        }

        public T RemoveLast()
        {
            if (Tail == null)
                throw new InvalidOperationException("The list is empty.");

            if (Head == Tail)
            {
                var value = Tail.Value;
                Head = null;
                Tail = null;
                return value;
            }

            var current = Head;
            while (current.Next != Tail)
            {
                current = current.Next;
            }

            var tailValue = Tail.Value;
            Tail = current;
            Tail.Next = null;
            return tailValue;
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
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public  void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool IsReadOnly { get { return false; } }

        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = Head;

            // scenarios:
            // 1. Empty List, current == null, do nothing return false
            // 2. Single node, then previous == null
            // 3. Many nodes:
            //          a: node to remove is the first node
            //          b: node to remove is in the middle or last node

            while(current != null) // while we have a node to remove
            {
                if (current.Value.Equals(item)){
                    // 3b: if the node is in the middle or the end
                    if (previous != null)
                    {
                        // Eg before: Head -> 3 -> 5 -> null
                        //    after: Head -> 3 -------> null
                        previous.Next = current.Next;
                        // if it was at the end, update Tail
                        if (current.Next == null)
                        {
                            Tail = previous;
                        }
                        Count--;
                    }
                    else
                    {
                        // case 2 or 3a
                        RemoveFirst();
                    }
                    return true; // we have removes the node
                }
                previous = current;
                current = current.Next;
            }
            return false; // no nodes to remove
        }


        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while(current != null)
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
            Tail = null;
            Count = 0;
        }
    }

}
