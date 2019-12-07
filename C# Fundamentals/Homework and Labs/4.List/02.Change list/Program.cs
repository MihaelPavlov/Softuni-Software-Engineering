using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Change_list
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToList();

            string line = Console.ReadLine();

            while (line!="end")
            {
                string[] tokens = line.Split(" ");
                string command = tokens[0];

                if (command=="Delete")
                {
                    int commandNumber = int.Parse(tokens[1]);
                    numbers.RemoveAll(n => n == commandNumber);
                }
                else if (command == "Insert")
                {
                    int currentNumber = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    numbers.Insert(index, currentNumber);
                }
                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",numbers));

        }
    }
}
