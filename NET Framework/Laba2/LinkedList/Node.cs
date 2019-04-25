
namespace LinkedList
{
    public class Node<T>
    {
        public Node<T> next;
        public T element;

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
