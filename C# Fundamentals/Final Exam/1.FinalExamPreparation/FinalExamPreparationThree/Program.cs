using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamPreparationThree
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> list = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> contestAndPoint = new Dictionary<string, int>();


            while (input != "END")
            {
                string[] cmdArgs = input.Split(" -> ");
                string country = cmdArgs[0];
                string name = cmdArgs[1];
                int namePoint = int.Parse(cmdArgs[2]);

                if (!list.ContainsKey(country))
                {
                    list.Add(country, new Dictionary<string, int>());
                    if (!list.ContainsKey(name))
                    {
                        list[country].Add(name, namePoint);
                        contestAndPoint.Add(country, namePoint);


                    }
                    else
                    {
                        list[country][name] += namePoint;
                        contestAndPoint[country] += namePoint;
                    }


                }
                else
                {
                    if (!list[country].ContainsKey(name))
                    {
                        list[country].Add(name, namePoint);
                        contestAndPoint[country] += namePoint;


                    }
                    else
                    {
                        list[country][name] += namePoint;
                        contestAndPoint[country] += namePoint;
                    }
                }
                input = Console.ReadLine();

               

            }
            foreach (var country1 in contestAndPoint.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{country1.Key}: {country1.Value}");
                foreach (var person in list[country1.Key])
                {
                    Console.WriteLine($"-- {person.Key} -> {person.Value}");
                }
            }
        }
    }
}
