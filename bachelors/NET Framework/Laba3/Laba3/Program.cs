using System;
using LinkedList;
using System.Collections;
namespace Laba3
{
    class Program
    {
        

        static void Main(string[] args)
        {
            LinkedList<string> lkdList = new LinkedList<string>();

            //lkdList.Count2 += (obj, events) =>
            //{
            //    Console.WriteLine(((LinkedList<string>)obj).Count + ") " + events.Data);
            //};



            lkdList.Add("Sasha");
            lkdList.Add("Oleh");
            lkdList.Add("Nikolay");
            lkdList.Add("Peter");
            lkdList.Add("Dima");

            //foreach (var val in (IEnumerable)lkdList)
            //{

            //    Console.WriteLine(val);
            //}
            foreach (var val in lkdList)
            {
                Console.WriteLine(val);
            }
            //lkdList.OnRemoved += RemoveInCollectionMessage<string>;



            lkdList.Remove("Oleh");
            Console.WriteLine("\n\t****After Removing****");
            foreach (var val in lkdList)
            {
                Console.WriteLine(val);
            }

            bool temp_check;
            temp_check = lkdList.Contains("Nikolay");
            Console.WriteLine("\nComparing is:"+temp_check);

            lkdList.OnCleared += ClearCollectionMessage;
            //lkdList.OnCleared(new object(), new MyEventArgs<string>("gjjgfd"));
            lkdList.Clear("lol");
            Console.WriteLine("\n\t****After Clearing****");
            foreach (var val in lkdList)
            {
                Console.WriteLine(val);
            }
            Console.ReadKey();

        }
        //static private void RemoveInCollectionMessage<T>(object sender, MyEventArgs<T> e)
        //{
        //    Console.WriteLine($"Object in Collection {sender} with key {e.Key} removed");
        //}
        static private void ClearCollectionMessage(object sender, EventArgs e)
        {
            Console.WriteLine($"\nCollection {sender} cleared");
        }

        //public class MyEventArgs<T> : EventArgs
        //{
        //    public T Key;

        //    public MyEventArgs(T key)
        //    {
        //        Key = key;
        //    }
        //}

    }
}
