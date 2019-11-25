using System;
using System.Linq;

namespace _05.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToArray();

            int[] storage = new int[arr.Length];
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        storage[j] = arr[j];
                        
                    }
                }
            }

            foreach (var item in storage)
            {
                Console.WriteLine(item);
            }
        }    
    }
}
