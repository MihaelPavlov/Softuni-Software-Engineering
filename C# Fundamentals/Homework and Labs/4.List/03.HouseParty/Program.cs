using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands =int.Parse(Console.ReadLine());

            List<string> guest = new List<string>();

            string line = "";

            for (int i = 1; i <= numberOfCommands; i++)
            {
                line = Console.ReadLine();
                string[] tokens = line.Split(" ");
                
                string command = tokens[2];
                string name = tokens[0];

                if (command =="going!")
                {
                    if (!guest.Contains(name))
                    {
                        guest.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    
                    
                }
                else if (command == "not")
                {
                    
                  
                    if (guest.Contains(name))
                    {
                        guest.Remove(name);
                    }
                    else if(!guest.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                    guest.Remove(name);
                }

                


            }
            foreach (string item in guest)
            {
                Console.WriteLine(item);
            }
        }
    }
}
