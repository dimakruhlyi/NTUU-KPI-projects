using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[100500];
            
            int countElements = 0, max = 0, min = 0,
                indexMax = 0, indexMin = 0, controlSum = 0;
            
            while (true)
            {
                MyArray.Fill(array, random.Next(1, 100));
                min = array[0];
                max = array[0];
                array[47] = 99;
                array[204] = 1;


                Parallel.ForEach(array, x =>
                {
                   
                    Interlocked.Increment(ref countElements);
                    controlSum = Convert.ToByte(controlSum) ^ Convert.ToByte(x);
                    if (x < min)
                    {
                        min = x;
                        indexMin = countElements - 1;
                    }
                    if (x > max)
                    {
                        max = x;
                        indexMax = countElements - 1;
                    }
                });

                Console.WriteLine("Count of elements is: " + countElements);
                Console.WriteLine("Max element is: " + max+" max index is:"+ indexMax);
                Console.WriteLine("Min element is: " + min + " min index is:" + indexMin);
                Console.WriteLine("Control sum is: "+controlSum);
                Console.ReadKey();
            }


        }
    }
    static class MyArray
    {
        public static void Fill(this Array x, object y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x.SetValue(y, i);
            }
        }
    }
}

