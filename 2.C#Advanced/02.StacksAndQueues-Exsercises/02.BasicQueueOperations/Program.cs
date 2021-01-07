using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nSx = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new Queue<int>();
            int[] numN = Console.ReadLine()
              .Split()
              .Select(int.Parse)
              .ToArray();

            for (int i = 0; i < numN.Length; i++)
            {
                numbers.Enqueue(numN[i]);
            }
            for (int i = 0; i < nSx[1]; i++)
            {
                numbers.Dequeue();
            }
            if (numbers.Contains(nSx[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numbers.Count != 0)
                {
                    Console.WriteLine(numbers.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }

            }
        }
    }
}
