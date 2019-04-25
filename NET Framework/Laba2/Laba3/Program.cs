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


            lkdList.Add("Sasha");
            lkdList.Add("Oleh");
            lkdList.Add("Nikolay");
            lkdList.Add("Peter");
            lkdList.Add("Dima");

            foreach (var val in (IEnumerable)lkdList)
            {
               
                Console.WriteLine(val);
            }

           

            lkdList.Remove("Oleh");
            Console.WriteLine("\n\t****After Removing****");
            foreach (var val in lkdList)
            {
                Console.WriteLine(val);
            }

            bool temp_check;
            temp_check = lkdList.Contains("Nikolay");
            Console.WriteLine("\nComparing is:"+temp_check);

            lkdList.Clear();
            Console.WriteLine("\n\t****After Clearing****");
            foreach (var val in lkdList)
            {
                Console.WriteLine(val);
            }
            Console.ReadKey();

        }
    }
}
