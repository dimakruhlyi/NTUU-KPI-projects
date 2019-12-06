using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab5_V
{
    class Program
    {
        static Random myRandom = new Random();
        static int sizeData = 20;
        static List<int> data_1 = new List<int>();
        static List<int> data_2 = new List<int>();
        static Task[] myTask;

        static void Main(string[] args)
        {
            Console.WriteLine("Main start");

            myTask = new Task[]
                {
                    new Task(Processing_1),
                    new Task(Processing_2),
                };

           
            myTask[0].Start();
            myTask[1].Start();

            myTask[1].Wait();
            data_2.Sort();

            Console.Write("Mas Result - ");
            for (int i = 0; i < data_2.Count; i++)
            {
                Console.Write(data_2[i] + " ");
            }

            Console.WriteLine("\nMain stop");
            Console.ReadKey();
        }

        static public void Processing_1()
        {
            Console.WriteLine("P1 start");

            Console.Write("Mas P1 - ");
            for (int i = 0; i < sizeData; i++)
            {
                data_1.Add(myRandom.Next(0, 100));
                Console.Write(data_1[i] + " ");
            }
            Console.WriteLine();

            int max = data_1.Max();
            for (int i = 0; i < data_1.Count;)
            {
                if (data_1[i] < 0.5 * max)
                {
                    data_1.Remove(data_1[i]);
                }
                else
                {
                    i++;
                }
            }

            Console.WriteLine("P1 stop");
        }

        static public void Processing_2()
        {
            Console.WriteLine("P2 start");

            Console.Write("Mas P2 - ");
            for (int i = 0; i < sizeData; i++)
            {
                data_2.Add(myRandom.Next(0, 100));
                Console.Write(data_2[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < data_2.Count;)
            {
                if (data_2[i] % 2 != 0)
                {
                    data_2.Remove(data_2[i]);
                }
                else
                {
                    i++;
                }
            }

            myTask[0].Wait();

            for (int i = 0; i < data_2.Count;)
            {
                bool check = true;
                int j = 0;
                while ( j < data_1.Count && check)
                {
                    if (data_2[i] == data_1[j])
                    {
                        check = false;
                    }
                    else
                    {
                        j++;
                    }
                }

                if (!check)
                {
                    data_2.Remove(data_2[i]);
                }
                else
                {
                    i++;
                }
            }

            Console.WriteLine("P2 stop");
        }
    }
}