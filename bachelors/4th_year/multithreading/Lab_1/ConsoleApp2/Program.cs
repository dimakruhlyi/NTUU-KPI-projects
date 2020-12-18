using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace ConsoleApp2
{
    class Program
    {
        public static int N = 20000;
        public static int[,] arr = new int[N, N];
        public static int[,] trans = new int[N, N];
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();

           // Console.WriteLine("\t\t\t\t *** Before Threading");
           // timer.Start();
           // Init();
           // //Print(arr, N);
           // Console.WriteLine("\n");
           // timer.Stop();
           // Console.WriteLine("Time elapsed init: {0} milliseconds \n", timer.Elapsed.TotalMilliseconds);
           // timer.Reset();
           // timer.Start();
           // Transpose();
           //// Print(trans, N);
           // timer.Stop();
           // Console.WriteLine("\n");
           // Console.WriteLine("Time elapsed transpose: {0} milliseconds \n", timer.Elapsed.TotalMilliseconds);
           // timer.Reset();


            Console.WriteLine("\t\t\t\t *** After Threading");
            timer.Start();
            Thread thread1 = new Thread(new ThreadStart(Init));
            thread1.Start();
            //Print(arr, N);
            Console.WriteLine("\n");
            thread1.Interrupt();
            timer.Stop();
            Console.WriteLine("Time elapsed init: {0} milliseconds \n", timer.Elapsed.TotalMilliseconds);
            timer.Reset();
            timer.Start();
            Thread thread = new Thread(new ThreadStart(Transpose));
            thread.Start();
            //Print(trans, N);
            Console.WriteLine("\n");
            thread.Interrupt();
            timer.Stop();
            Console.WriteLine("Time elapsed transpose: {0} milliseconds \n", timer.Elapsed.TotalMilliseconds);
            timer.Reset();

            Console.ReadKey();
        }
        public static void Transpose()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    trans[j, i] = arr[i, j];
                }
            }
        }

        public static void Init()
        {
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    arr[i,j] = random.Next(99);
                }
                
            }
        }
        
        public static void Print(int[,] arr, int n)
        {

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(String.Format("{0,3}", arr[i, j]));
                }
                Console.WriteLine();

            }
        }
    }
}