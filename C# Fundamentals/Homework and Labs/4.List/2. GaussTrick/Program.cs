using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int originalLenght = numbers.Count;


            for (int i = 0; i < originalLenght/2; i++)
            {
                
                
                 numbers[i] += numbers[numbers.Count - 1];
                
                numbers.RemoveAt(numbers.Count - 1);
                
                


            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
