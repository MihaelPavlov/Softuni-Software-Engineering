using System;
using System.Collections.Generic;
using System.Linq;


namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            Func<string, int, bool> isEqualOrLargerFunc = (word, criteria) => word.Sum(x => x) >= criteria;


            Func<string[], Func<string, int, bool>, string> myFunc = (names, isLargerFunc) =>
               names.FirstOrDefault(x => isLargerFunc(x, n));
            string targetName = myFunc(input, isEqualOrLargerFunc);

            Console.WriteLine(targetName);
           
        }
    }
}
