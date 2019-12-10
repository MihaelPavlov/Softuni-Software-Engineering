using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input.Reverse());

            int total = int.Parse(stack.Pop());
            while (stack.Any())
            {
                var nextChar = stack.Pop();

                if (nextChar == "+")
                {
                    var secondNumber = int.Parse(stack.Pop());
                    total += secondNumber;

                }
                else if (nextChar == "-")
                {
                    var secondNumber = int.Parse(stack.Pop());
                    total -= secondNumber;
                }

            }

            Console.WriteLine(total);


        }
    }
}
