using System;
using System.Linq;
using System.Collections.Generic;
namespace _09_FactorialDivision
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

            while (line!= "End")
            {
                string[] tokens = line.Split(" ");
                string cmd = tokens[0];

                if (cmd == "Add")
                {
                    int numberCommand = int.Parse(tokens[1]);
                    numbers.Add(numberCommand);
                }


                if (cmd == "Insert")
                {
                    int numberCommand = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);

                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.Insert(index, numberCommand);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if(cmd == "Remove")
                {

                    int index = int.Parse(tokens[1]);
                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }

                }
                else if (line.Contains("Shift left"))
                {
                    int count = int.Parse(tokens[2]);
                    for (int i = 0; i < count; i++)
                    {
                        int currentNumber = numbers[0];
                        numbers.RemoveAt(0);
                        numbers.Add(currentNumber);
                    }
                }
                else if (line.Contains("Shift right"))
                {
                    int count = int.Parse(tokens[2]);
                    for (int i = 0; i < count; i++)
                    {
                        int currentNumber = numbers[numbers.Count - 1];
                        numbers.RemoveAt(numbers.Count - 1);
                        numbers.Insert(0, currentNumber);
                    }
                }

                line = Console.ReadLine();            
            }
            Console.WriteLine(string.Join(" ",numbers));
            
        }
       
       
        
        
    }
}
