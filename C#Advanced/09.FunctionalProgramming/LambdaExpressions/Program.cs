using System;
using System.Linq;
using System.Collections.Generic;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> result = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                ToList(result, input[i]);
            }
            Console.WriteLine("Even numbers ->");
            Console.WriteLine(string.Join(", ", result));
            
        }

        static void ToList(List<int> list, int number)
        {
            if (number%2==0)
            {
                list.Add(number);
            }
            else
            {
                Console.WriteLine(number);
            }
            
        }
    }
}
