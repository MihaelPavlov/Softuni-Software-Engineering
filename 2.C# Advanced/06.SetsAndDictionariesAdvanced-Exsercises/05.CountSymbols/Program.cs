using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            var dict = new Dictionary<char, int>();

            foreach (var symbol in input)
            {
                if (!dict.ContainsKey(symbol))
                {
                    dict.Add(symbol, 0);
                }
                dict[symbol]++;
            }

            foreach (var item in dict.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
