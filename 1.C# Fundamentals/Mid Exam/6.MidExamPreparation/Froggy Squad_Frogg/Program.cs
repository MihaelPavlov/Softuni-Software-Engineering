using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy_Squad_Frogg
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frogs = Console.ReadLine()
                .Split(" ")
                .ToList();

            var print = new List<string>();

            string input = Console.ReadLine();

            while (input!="Print")
            {
                string[] commandArgs = input.Split(" ");
                string command = commandArgs[0];

                if (command == "Join")
                {
                    string name = commandArgs[1];
                    if (!frogs.Contains(name))
                    {
                        frogs.Add(name);
                    }
                }
                else if (command == "Jump")
                {
                    string name = commandArgs[1];
                    int index = int.Parse(commandArgs[2]);

                    if (index >= 0 && index < frogs.Count)
                    {
                        frogs.Insert(index, name);
                    }
                }
                else if (command == "Dive")
                {
                    int index = int.Parse(commandArgs[1]);

                    if (index >= 0 && index < frogs.Count)
                    {
                        frogs.RemoveAt(index);
                    }
                }
                else if (command == "First")
                {
                    int count = int.Parse(commandArgs[1]);
                    if (count > frogs.Count)
                    {
                        count = frogs.Count;
                    }
                    print = frogs.Take(count).Select(x => x).ToList();
                    Console.WriteLine(string.Join(" ", print));
                }
                else if (command == "Last")
                {
                    int count = int.Parse(commandArgs[1]);
                    if (count > frogs.Count)
                    {
                        count = frogs.Count;
                    }
                    frogs.Reverse();
                    print = frogs.Take(count).Select(x => x).ToList();
                    print.Reverse();
                    frogs.Reverse();
                    Console.WriteLine(string.Join(" ", print));
                }
                else if (commandArgs[1] == "Normal")
                {

                    Console.WriteLine($"Frogs: {string.Join(" ", frogs)}");
                    break;
                }
                else if (commandArgs[1] == "Reversed")
                {
                    frogs.Reverse();
                    Console.WriteLine($"Frogs: {string.Join(" ", frogs)}");
                    break;
                }
                
                input = Console.ReadLine();
            }
            
            
                
            
            
                    
        }
    }
}
