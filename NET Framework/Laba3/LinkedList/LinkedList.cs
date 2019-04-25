using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows;

namespace LinkedList
{

    /// <summary>
    ///  Двосвязний список.  Доступ до елементу можна отримати по назві елемента.
    /// </summary>
    public class LinkedList<T>: IEnumerable<T>
    {
        public delegate void EventHandler(object sender, MyEventArgs<T> e);
       // public event EventHandler<MyEventArgs<T>> OnRemoved;
        public event EventHandler<MyEventArgs<T>> OnCleared;
        //public delegate void LinkedListHandler(object sender, ForEventArgs<T> e);
       // public event LinkedListHandler Count2;

        public Node<T> myNode;// головний елемент
        public Node<T> element = null;//наступний елемент списку
        public Node<T> First = null;//перший елемент списку

        public int coutElements = 0;
        public int Count => coutElements;//кількість елементів

        /// <summary>
        /// Метод для додавання елементів в список
        /// </summary>
        /// <param name="new_data">Елемент для додавання</param>
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

            //if (Count2 != null)
            //    Count2(this, new MyEventArgs<T>(new_data));
        }
        /// <summary>
        /// Метод для додавання елементів на початок списку
        /// </summary>
        /// <param name="new_data">Елемент для додавання</param>
        public void AddFirst(T new_data)
        {
            Node<T> new_node1 = First;

            Node<T> new_node = new Node<T>(new_data);
            First = new_node;
            First.next = new_node1;

            coutElements++;
        }
        /// <summary>
        /// Цей метод видаляж вказаний елемент зі списку
        /// </summary>
        /// <returns>True у разі виконання</returns>
        public bool Remove(T item)
        {

            try
            {
                if (IsEmpty) 
                    throw new InvalidOperationException();

            }   
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
                Console.Read();
            }

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
                        //OnRemoved(this, new MyEventArgs<T>(item));
                        return true;
                    }

                    last = a;
                    a = a.next;
                }
            }

            myNode = First;
            //OnRemoved(this, new MyEventArgs<T>(item));
            return false;

           
        }

        public bool IsEmpty { get { return Count == 0; } }

        /// <summary>
        /// Цей метод очищає повністю весь список
        /// </summary>
        public void Clear(T list)
        {
            element = null;
            First = null;

            coutElements = 0;
            OnCleared(this, new MyEventArgs<T>(list));
        }
        
        
        /// <summary>
        /// Метод первірки на входження переданого елемента в списку
        /// </summary>
        /// <param name="item">Ключ, який необхідно знайти в LinkedList</param>
        /// <returns>True у разі виконання</returns>
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
            
            //return GetEnumerator();
        }
        //public class ForEventArgs<T> : EventArgs
        //{
        //    public ForEventArgs(T data)
        //    {
        //        Data = data;
        //    }
        //    public T Data { get; set; }
        //}

        
      
    }

    public class MyEventArgs<T> : EventArgs
    {
        public T Key;

        public MyEventArgs(T key)
        {
            Key = key;
        }
    }
}
