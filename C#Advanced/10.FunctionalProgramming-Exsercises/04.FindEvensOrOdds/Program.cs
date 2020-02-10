using System;
using System.Collections.Generic;
using System.Linq;


namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            int from = numbers[0];
            int to = numbers[1];

            Predicate<int> predicate = command == "odd" ?
              new Predicate<int>((n) => n % 2 != 0) : new
              Predicate<int>((n) => n % 2 == 0);

            List<int> res = new List<int>();

            for (int i = from; i <= to; i++)
            {
                if (predicate(i))
                {
                    res.Add(i);
                }
            }
            Console.WriteLine(string.Join(" " , res));
        }
    }
}
