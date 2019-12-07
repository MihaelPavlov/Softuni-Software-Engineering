using System;
using System.Linq;
using System.Collections.Generic;

namespace _08.Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> system = new Dictionary<string, List<string>>();
            List<string> list = new List<string>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commandArgs = input.Split(" -> ");
                string companyName = commandArgs[0];
                string number = commandArgs[1];

                if (!system.ContainsKey(companyName))
                {
                    system.Add(companyName, list);
                    list.Add(number);
                    list = new List<string>();
                    
                    
                }
                else
                {
                    //how to check in the list in the dictionary
                    if (!system[companyName].Contains(number))
                    {
                        system[companyName].Add(number);
                    }


                }
                input = Console.ReadLine();
            }
            foreach (var item in system.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}");
                foreach (var item2 in item.Value)
                {
                    Console.WriteLine($"-- {item2}");
                }
            }


        }

    }
}
