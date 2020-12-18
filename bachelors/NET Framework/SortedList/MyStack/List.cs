using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    public class List<T>
    {
        private Node<T> head = new Node<T>();
        int count = 0;
        public void Push(List<T> list, T item)
        {
            Node<T> node = new Node<T>(item);
            node.next = list.head;
            list.head = node;
            count++;
        }

        public void Remove(List<T> list)
        {
            Node<T> temp = list.head;
            Node<T> prev = null;
            if (temp != null)
            {
                list.head = temp.next;
                return;
            }
            while (temp != null)
            {
                prev = temp;
                temp = temp.next;
            }
            if (temp == null)
            {
                return;
            }
            prev.next = temp.next;
        }

        public T Pop()
        {
            var item = GetItem();
            count--;
            return item;
        }

        public T Peek()
        {
            var item = GetItem();
            return item;
        }

        private T GetItem()
        {
            if (head != null)
            {
                var item = head.element;
                return item;
            }
            else
            {
                throw new Exception();
            }
        }

        public int Count()
        {
            return count;
        }

        public bool Contains(T item)
        {
            int i = 0;
            Node<T> a = head;
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

        public void Clear(List<T> list)
        {
            for(int i = 0; i < list.Count(); i++)
            {
                list.Remove(list);
            }
            count = 0;
        }
    }
}
