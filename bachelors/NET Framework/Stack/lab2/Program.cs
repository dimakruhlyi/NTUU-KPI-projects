using System;
using MyStack;


namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var myStack = new MyStack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            Console.WriteLine("First:" + myStack.Peek());
            Console.WriteLine("Count:" + myStack.Count());
            Console.WriteLine("First:" + myStack.Pop());
            Console.WriteLine("Second:" + myStack.Pop());
            Console.WriteLine("Count:" + myStack.Count());
            myStack.Push(3);
            Console.WriteLine(myStack.Contains(5));
            Console.WriteLine("Count:" + myStack.Count());
            Console.WriteLine("First:" + myStack.Peek());
            myStack.Clear();
            Console.ReadKey(); 
        }
    }
}
