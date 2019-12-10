﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new Queue<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0)
                {
                    numbers.Enqueue(input[i]);
                }
            }



           string result = String.Join(", ", numbers.ToArray());
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i]);
            }







        }
    }
}
