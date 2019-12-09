using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Drawing;

namespace Lab3_V
{
    class Program
    {
        public static int N = 10000;
        public static int[,] arr = new int[N, N];
        public static int[,] trans = new int[N, N];
     

        static void Main(string[] args)
        {
            Random random = new Random();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    arr[i, j] = random.Next(99);
                }
            }

            Console.WriteLine("\t Before");
            //Print(arr,N);
            Parallel.For(0, N, Transpose);
         
                
            Console.WriteLine("\t After");
            //Print(trans, N);
            Console.WriteLine("\t Inf");
            Console.ReadKey();
        }

        public static void Transpose(int i)
        {
            for (int j = 0; j < N; j++)
            {
                trans[j, i] = arr[i, j];
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