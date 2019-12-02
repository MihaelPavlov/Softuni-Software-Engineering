using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountReaLNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(" ")
                .ToArray();


            SortedDictionary<string, int> count = new SortedDictionary<string, int>();

            foreach (var number in numbers)
            {
                if (count.ContainsKey(number))
                {
                    count[number]++;
                }
                else
                {
                    count.Add(number, 1);
                }
            }
            foreach (var item in count)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}
