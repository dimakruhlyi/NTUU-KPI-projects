using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyStack
{
    public class Node<T>
    {
        internal Node<T> next;
        internal T element;
        
        public Node(T value)
        {
            element = value;
            next = null;
        }

        public Node()
        {
            next = null;
        }
    }
}
