using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows;

namespace LinkedList
{
    public class LinkedList<T>: IEnumerable<T>
    {
        
        public Node<T> myNode;
        public Node<T> element = null;
        public Node<T> First = null;

        public int coutElements = 0;
        public int Count => coutElements;


        public void Add(T new_data)
        {
            if (First != null)
            {
                Node<T> new_node = new Node<T>(new_data);
                element.next = new_node;

                element = new_node;
            }
            else
            {
                myNode = new Node<T>(new_data);

                element = myNode;
                First = myNode;
            }

            coutElements++;
        }

        public void AddFirst(T new_data)
        {
            Node<T> new_node1 = First;

            Node<T> new_node = new Node<T>(new_data);
            First = new_node;
            First.next = new_node1;

            coutElements++;
        }

        public bool Remove(T item)
        {
            Node<T> a = First.next;
            var comparer = Comparer<T>.Default;

            if (Contains(item))
            {
                if (comparer.Compare(First.element, item) == 0)
                {
                    First = First.next;
                    coutElements--;
                    myNode = First;
                    return true;
                }


                Node<T> last = First;

                while (a.next != null)
                {
                    if (comparer.Compare(a.element, item) == 0)
                    {
                        last.next = a.next;

                        if (a == element)
                        {
                            element = last;
                        }

                        coutElements--;
                        myNode = First;
                        return true;
                    }

                    last = a;
                    a = a.next;
                }
            }

            myNode = First;
            return false;
        }

        public void Clear()
        {
            element = null;
            First = null;

            coutElements = 0;
        }

        public bool Contains(T item)
        {
            int i = 0;

            Node<T> a = First;
            var comparer = Comparer<T>.Default;

            while (a.next != null)
            {
                i++;

                if (comparer.Compare(a.element, item) == 0)
                {
                    return true;
                }

                a = a.next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (myNode != null)
            {
                T currentValue = myNode.element;
                myNode = myNode.next;
                yield return currentValue;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotFiniteNumberException();

            return GetEnumerator();
        }

    }
}
