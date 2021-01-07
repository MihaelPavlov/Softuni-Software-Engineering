using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            
            Stack<int> nums = new Stack<int>(numbers);

            string input = Console.ReadLine().ToLower();

            while (input!="end")
            {
                string[] cmdArgs = input.Split();
                string cmd = cmdArgs[0];

                if (cmd == "add")
                {
                    int firstNumber = int.Parse(cmdArgs[1]);
                    int secondNumber = int.Parse(cmdArgs[2]);

                    nums.Push(firstNumber);
                    nums.Push(secondNumber);

                }
                else if (cmd =="remove")
                {
                    int firstNumber = int.Parse(cmdArgs[1]);

                    bool checkIfEnoughElements = nums.Count >= firstNumber;

                    if (checkIfEnoughElements==true)
                    {
                        for (int i = 0; i < firstNumber; i++)
                        {
                            nums.Pop();
                        }
                    }
                }

                input = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {nums.Sum()}" );

        }
    }
}
