using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nSx = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            Stack<int> numbers = new Stack<int>();
            int[] numN = Console.ReadLine()
              .Split()
              .Select(int.Parse)
              .ToArray();

            for (int i = 0; i < numN.Length; i++)
            {              
                numbers.Push(numN[i]);
            }
            for (int i = 0; i < nSx[1]; i++)
            {
                numbers.Pop();
            }
            if (numbers.Contains(nSx[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numbers.Count !=0)
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
