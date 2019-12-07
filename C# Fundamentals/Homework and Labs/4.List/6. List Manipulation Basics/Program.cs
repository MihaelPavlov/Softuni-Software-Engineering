using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._List_Manipulation_Basics
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

                if (command == "Add")
                {
                    int currentNumber = int.Parse(tokens[1]);
                    numbers.Add(currentNumber);
                }
                else if (command == "Remove")
                {
                    int currentNumber = int.Parse(tokens[1]);
                    numbers.Remove(currentNumber);
                }
                else if (command =="RemoveAt")
                {
                    int currentNumber = int.Parse(tokens[1]);
                    numbers.RemoveAt(currentNumber);
                }
                else if (command=="Insert")
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
