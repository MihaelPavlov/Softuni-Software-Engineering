using System;
using System.Linq;
using System.Collections.Generic;

namespace _09ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).Distinct().ToArray();
            var divisibleNumbers = GetDivisibleNumber(n, numbers);
            Console.WriteLine(string.Join(" ", divisibleNumbers));
        }

        private static List<int> GetDivisibleNumber (int n , int[]divisior)
        {
            var divisibleNumber = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                bool isDivisible = true;

                foreach (var item in divisior)
                {
                    Predicate<int> isNotDivisor = x => i % x != 0;

                    if (isNotDivisor(item))
                    {
                        isDivisible = false;
                        break;

                    }
                }
                if (isDivisible)
                {
                    divisibleNumber.Add(i);

                }
              

            }
            return divisibleNumber;
        }
    }
}
