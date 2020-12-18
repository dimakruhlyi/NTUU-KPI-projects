using System;
using System.Linq;

namespace MyStack
{
    public class MyStack<T>
    {
        private List<T> items = new List<T>();

        public MyStack()
        {
            items = new List<T>();

        }

        public void Push(T item)
        {
            items.Push(items, item);
        }

        public T Pop()
        {
            var item = items.Pop();
            items.Remove(items);
            return item;
        }

        public T Peek()
        {
            var item = items.Peek();
            return item;
        }

        public int Count()
        {
            return items.Count();
        }

        public void Clear()
        {
            items.Clear(items);
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }
    }
}