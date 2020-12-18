using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortedList;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode<string> a = new ListNode<string>();


            a.Add("XYI0");
            a.Add("XYI1");
            a.Add("XYI4");
            a.Add("XYI2");
            a.Add("XYI2");
            a.Add("XYI3");


            foreach (var q in a)
            {
                Console.WriteLine(q);
            }

            a.getValue();

            Console.ReadKey();
        }
    }
}
