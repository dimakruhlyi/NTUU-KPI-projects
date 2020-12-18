using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortedList;

namespace SortedList
{
    internal class Node<T>
    {
        internal T Value { get; }
        internal Node<T> Next;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }

        public Node()
        {
            Next = null;
        }
    }
        
}
