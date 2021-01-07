using System;
using System.Numerics;

namespace _1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Reading arrays from the Console
            
            //int n = int.Parse(Console.ReadLine());
            //int[] arr = new int[n];
            ////обхождаме масива и слагаме стойности на всички променливи.
            //for (int i = 0; i < n; i++)
            //{
            //    arr[i] = int.Parse(Console.ReadLine());
            //}

            ////String arrays
            //string val ues = Console.ReadLine();
            //string[] items = values.Split();
            //int[] arr2 = new int[items.Length];

            //for (int i = 0; i < items.Length; i++)
            //{
            //    arr[i] = int.Parse(items[i]);
            //}


            //foreach

            int[] number = { 1, 2, 3, 4, 5 };
            foreach  (int numbers in number)
            {
                
                Console.WriteLine(numbers);
            }

        }
    }
}
