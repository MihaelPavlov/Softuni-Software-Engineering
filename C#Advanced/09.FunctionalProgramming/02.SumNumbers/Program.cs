using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Console.ReadLine().Split(", ").Select(Parse);
            Console.WriteLine(string.Join(", ", result));
            Console.WriteLine(result.Count());
            Console.WriteLine(result.Sum());
        }
        static int Parse (string str)
        {
            //from string to int .The easy way is int.Parse
            //  "31321" => 31321
            //The hard way
            int number = 0;
            foreach (var ch in str)
            {
                number *= 10;
               number+= ch - '0';
            }
            return number;
        }
    }
}
