using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                           .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToList();
            string command = Console.ReadLine();
            Func<List<int>, List<int>> add = x=>x.Select(x=>x+1).ToList();
            Func< List<int>, List<int>> multiply = x => x.Select(number => number * 2).ToList();
            Func< List<int>, List<int>> subtract = x => x.Select(number => number -1).ToList();
            Action< List<int>> print = x =>
            {
                Console.WriteLine(string.Join(" " , x));
                
            };

            while (command != "end")
            {
                if (command == "add")
                {
                   numbers=add(numbers);
                }
                else if (command == "multiply")
                {
                   numbers= multiply(numbers);
                }
                else if (command == "subtract")
                {
                    numbers=subtract(numbers);
                }
                else if (command == "print")
                {
                    print(numbers);
                }


                command = Console.ReadLine();

            }
            

            
        }
    }
}
