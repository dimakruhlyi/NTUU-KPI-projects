using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circl1 = new Circle();
            Circle circlt2 = new Circle(0, 0, 3);
            Rectangle rect1 = new Rectangle();
            Rectangle rect2 = new Rectangle(2, 5);
            Console.WriteLine("When radius = 0, length: " + circl1.P() + "\n");
            Console.WriteLine("When radius = 3, length: " + circlt2.P() + "\n");
            Console.WriteLine("************************************************ \n");
            Console.WriteLine("Perymetr 1: " + rect1.Perymetr() + "\n");
            Console.WriteLine("Perymetr 2: " + rect2.Perymetr() + "\n");
            Console.ReadKey();
        }
    }
}
