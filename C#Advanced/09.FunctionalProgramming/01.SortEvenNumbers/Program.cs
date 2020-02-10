using System;
using System.Linq;
using System.Collections.Generic;
namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            // with Linq
            var result1 = Console.ReadLine().Split(", ").Select(int.Parse)
                .Where(x => x % 2 == 0).OrderBy(x => x);
            Console.WriteLine(string.Join (", " , result1));


            //FirstVariation
            int[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var result = numbers.Where(x => x % 2 == 0);
            var end = result.OrderBy(x => x);
            Console.WriteLine(string.Join(", ", end));


            IsEven(numbers);
        }
        //SecondVariation
        static void IsEven(int[] number)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i]%2==0)
                {
                    result.Add(number[i]);
                }
            }
            Console.WriteLine(string.Join(", ", result.OrderBy(x=>x )));
        }
    }
}
