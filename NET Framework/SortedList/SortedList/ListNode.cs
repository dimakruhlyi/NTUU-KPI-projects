using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows;

namespace SortedList
{
    public class ListNode<T> : IEnumerable<T>, ICollection<T>
    {
        internal Node<T> myNode;
        internal Node<T> Head = null;
        internal Node<T> First = null;

        internal int size = 0;
        public int Count => size;
        public bool IsReadOnly => false;


        private void Insert(T new_data)
        {
            if (First != null)
            {
                Node<T> new_node = new Node<T>(new_data);
                Head.Next = new_node;

                Head = new_node;
            }
            else
            {
                myNode = new Node<T>(new_data);

                Head = myNode;
                First = myNode;
            }

            size++;
        }

        internal void InsertAfter(Node<T> position, T new_data)
        {
            Node<T> new_node = new Node<T>(new_data);
            new_node.Next = position.Next;

            position.Next = new_node;

            size++;
        }

        internal void InsertAfter(T new_data)
        {
            Node<T> new_node1 = First;

            Node<T> new_node = new Node<T>(new_data);
            First = new_node;
            First.Next = new_node1;

            size++;
        }

        public void Add(T item)
        {
            var comparer = Comparer<T>.Default;

            if (First == null)
            {
                Insert(item);
            }
            else
            {
                Node<T> mark = First;
                Node<T> last = mark;

                for (int i = 0; i < Count; i++)
                {
                    if (comparer.Compare(mark.Value, item) > 0)
                    {
                        if (mark == First)
                        {
                            InsertAfter(item);
                        }
                        else
                        {
                            InsertAfter(last, item);
                        }
                        break;
                    }

                    last = mark;
                    mark = mark.Next;
                }

                if (mark == null)
                {
                    Insert(item);
                }
            }

            myNode = First;
        }

        public bool Remove(T item)
        {
            Node<T> a = First.Next;
            var comparer = Comparer<T>.Default;

            if (Contains(item))
            {
                if (comparer.Compare(First.Value, item) == 0)
                {
                    First = First.Next;
                    size--;
                    myNode = First;
                    return true;
                }
                

                Node<T> last = First;

                while (a.Next != null)
                {
                    if (comparer.Compare(a.Value, item) == 0)
                    {
                        last.Next = a.Next;

                        if (a == Head)
                        {
                            Head = last;
                        }

                        size--;
                        myNode = First;
                        return true;
                    }

                    last = a;
                    a = a.Next;
                }
            }

            myNode = First;
            return false;
        }

        public bool Contains(T item)
        {
            int i = 0;

            Node<T> a = First;
            var comparer = Comparer<T>.Default;

            while (a.Next != null)
            {
                i++;

                if (comparer.Compare(a.Value, item) == 0)
                {
                    return true;
                }
          
                a = a.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            throw new NotSupportedException("Hasn't implementation for this collection");
        }

        public void Clear()
        {
            Head = null;
            First = null;

            size = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (myNode != null)
            {
                T currentValue = myNode.Value;
                myNode = myNode.Next;
                yield return currentValue;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void getValue()
        {
            myNode = First;
            Node<T> get = First;
            int i = 0;

            while (get != null)
            {
                i++;
                Console.WriteLine(i + ") - " + get.Value);
                get = get.Next;
            }

        }
    }
}