using System;
using System.Collections.Generic;
using System.Collections;

namespace Deque
{
    public class Deque<T> : IEnumerable<T>  // двусвязный список
    {
        public delegate void DequeHandler(object sender, ForEventArgs<T> e);
        public event DequeHandler Count;

        DoublyNode<T> head; // головной/первый элемент
        DoublyNode<T> tail; // последний/хвостовой элемент
        public int count;  // количество элементов в списке
        
        /// <summary>
        /// Метод добавляет элемент в конец дека
        /// </summary>
        /// <param name="data">Элемент для добавления</param>
        public void AddLast(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        /// <summary>
        /// Метод добавляет элемент в начало дека
        /// </summary>
        /// <param name="data">Элемент для добавления</param>
        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;

            if (Count != null)
                Count(this, new ForEventArgs<T>(data));
        }

        /// <summary>
        /// Этот метод удаляет первый элемент.
        /// </summary>
        /// <returns>Удаленный первый элемент</returns>
        public T RemoveFirst()
        {

            try
            {
                if (count == 0)
                    throw new InvalidOperationException();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error!: {e.Message}");
                Console.Read();
            }

          
            T output = head.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            count--;
            return output;
        }

        /// <summary>
        /// Этот метод удаляет последний элемент.
        /// </summary>
        /// <returns>Удаленный последний элемент</returns>
        public T RemoveLast()
        {
            try
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error!: {e.Message}");
                Console.Read();
            }

            T output = tail.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            count--;
            return output;
        }
        
        public T First
        {
            get
            {
                try
                {
                    if (IsEmpty)
                        throw new InvalidOperationException();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error!: {e.Message}");
                    Console.Read();
                }
                return head.Data;
            }
        }
        public T Last
        {
            get
            {
                try
                {
                    if (IsEmpty)
                        throw new InvalidOperationException();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error!: {e.Message}");
                    Console.Read();
                }
                return tail.Data;
            }
        }

        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
    public class ForEventArgs<T> : EventArgs
    {
        public ForEventArgs(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}
