using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CitiesByContinentAndCountry
{
   class Program
    {
        static void Main(string[] args)
        {
         
            int n = int.Parse(Console.ReadLine());
           

            Dictionary<string, Dictionary<string, List<string>>> list = new Dictionary<string, Dictionary<string, List<string>>>();

        

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] cmd = input.Split();
                string continent = cmd[0];
                string country = cmd[1];
                string cities = cmd[2];


                if (!list.ContainsKey(continent))
                {
                    list.Add(continent, new Dictionary<string, List<string>>());
                    if (!list[continent].ContainsKey(country))
                    {
                        list[continent].Add(country, new List<string>());
                        list[continent][country].Add(cities);
                    }

                }
                else if (list.ContainsKey(continent))
                {
                    if (!list[continent].ContainsKey(country))
                    {
                        list[continent].Add(country, new List<string>());
                        list[continent][country].Add(cities);
                    }
                    else
                    {
                        list[continent][country].Add(cities);
                    }
                }




              
            }

            foreach (var continent in list)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.Write($"{country.Key} -> ");
                   
                        Console.Write($"{string.Join(", ",country.Value)}");
                    
                    Console.WriteLine();
                }
            }
        }
    }
}
