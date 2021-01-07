using System;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;


namespace train
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < number.Length; i++)
            {
                int max = number.Max();
                Console.WriteLine(max);
            }
            
            

        }
    }
}
