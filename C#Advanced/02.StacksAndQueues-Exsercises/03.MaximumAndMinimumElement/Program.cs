using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = input.Split(" ");
                string cmd = cmdArgs[0];

                if (cmd == "1")
                {
                    int number = int.Parse(cmdArgs[1]);
                    numbers.Push(number);


                }
                else if (cmd == "2")
                {
                    if (numbers.Count!=0)
                    {
                        numbers.Pop();
                    }
                    
                }
                else if (cmd =="3")
                {
                    if (numbers.Count != 0)
                    {
                        Console.WriteLine(numbers.Max());

                    }
                }
                else if (cmd == "4")
                {
                    if (numbers.Count != 0)
                    {
                        Console.WriteLine(numbers.Min());
                    }
                    
                }

                input = Console.ReadLine();

                
            }
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
