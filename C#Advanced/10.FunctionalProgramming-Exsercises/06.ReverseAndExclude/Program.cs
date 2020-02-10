using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int divisibleNumber = int.Parse(Console.ReadLine());
            
            Func<List<int>, List<int>> func = x =>
               {
                   List<int> newNumber = new List<int>();
                   for (int i = 0; i < numbers.Count; i++)
                   {
                       if (numbers[i] % divisibleNumber != 0)
                       {
                           newNumber.Add(numbers[i]);
                       }
                       
                   }

                   newNumber.Reverse();
                   Console.WriteLine(string.Join(" " , newNumber));

                   return newNumber;
               };


            func(numbers);
        }

    }
}
