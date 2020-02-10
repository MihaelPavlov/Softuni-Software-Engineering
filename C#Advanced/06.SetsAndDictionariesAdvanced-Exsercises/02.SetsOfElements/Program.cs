using System;
using System.Collections.Generic;
using System.Linq;
namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];

            var elementsN = new Dictionary<int, int>();
            var elementsM = new Dictionary<int, int>();
          

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!elementsN.ContainsKey(number))
                {
                    elementsN.Add(number, 0);
                }
            }
            for (int i = 0; i < m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!elementsM.ContainsKey(number))
                {
                    elementsM.Add(number, 0);
                }
            }

            int counter = 0;
            List<int> unique = new List<int>();


            foreach (var item in elementsN)
            {
                var element = item.Key;

                foreach (var item2 in elementsM)
                {
                    var element2 = item2.Key;

                    if (element== element2)
                    {
                        unique.Add(element);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", unique));


        }
    }
}
