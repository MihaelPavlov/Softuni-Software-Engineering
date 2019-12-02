using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> carsRegistry = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] commandArgs = input.Split(" ");
                string cmd = commandArgs[0];
                string name = commandArgs[1];

                if (cmd == "register")
                {
                    string licensePlatNumber = commandArgs[2];
                    if (!carsRegistry.ContainsKey(name))
                    {

                        carsRegistry.Add(name, licensePlatNumber);
                        Console.WriteLine($"{name} registered {licensePlatNumber} successfully");


                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlatNumber}");
                    }


                }
                else if (cmd == "unregister")
                {
                    if (!carsRegistry.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        carsRegistry.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                }
            }
            foreach (var item in carsRegistry)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }

        }
    }
}
