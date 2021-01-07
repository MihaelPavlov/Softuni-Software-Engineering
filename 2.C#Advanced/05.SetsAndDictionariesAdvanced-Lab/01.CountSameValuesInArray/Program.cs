using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split(" ")
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> safe = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                double value = input[i];

                if (!safe.ContainsKey(value))
                {
                    safe.Add(value,1);
                    
                }
                else if(safe.ContainsKey(value))
                {
                    safe[value] += 1;
                }
            }

            foreach (var item in safe)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
