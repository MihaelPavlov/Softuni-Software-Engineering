using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> supermarket = new Queue<string>();
            int count = 0;
            while (input != "End")
            {

                if (input == "Paid")
                {
                    while (supermarket.Any())
                    {
                        Console.WriteLine(supermarket.Dequeue());
                        count--;
                    }
                    input = Console.ReadLine();
                    continue;
                }
                supermarket.Enqueue(input);
                count++;

                input = Console.ReadLine();


            }
            Console.WriteLine($"{count} people remaining.");
        }
    }
}
