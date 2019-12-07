using System;
using System.Collections.Generic;
using System.Linq;


namespace _02.FeedTheAnimals
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> zoo = new Dictionary<string, int>();
            Dictionary<string, List<string>> zoo2 = new Dictionary<string, List<string>>();

            while (input != "Last Info")
            {
                string[] cmdArgs = input.Split(":");
                string command = cmdArgs[0];

                if (command == "Add")
                {
                    string animalName = cmdArgs[1];
                    int dailyFoodLimit = int.Parse(cmdArgs[2]);
                    string area = cmdArgs[3];
                    
                    if (!zoo.ContainsKey(animalName) )
                    {

                        zoo.Add(animalName, dailyFoodLimit);
                        if (!zoo2.ContainsKey(area))
                        {
                            zoo2.Add(area, new List<string>());
                            zoo2[area].Add(animalName);
                        }
                        else
                        {
                            zoo2[area].Add(animalName);
                        }
                    }
                    else
                    {

                        zoo[animalName] += dailyFoodLimit;
                    }
                }
                else if (command == "Feed")
                {
                    string animalName = cmdArgs[1];
                    int food = int.Parse(cmdArgs[2]);
                    string area = cmdArgs[3];
                    if (zoo.ContainsKey(animalName))
                    {
                        zoo[animalName] -= food;
                        if (zoo[animalName] <= 0)
                        {
                            Console.WriteLine($"{animalName} was successfully fed");
                            zoo.Remove(animalName);
                            zoo2.Remove(area);
                        }
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Animals:");
            foreach (var item in zoo.OrderByDescending(x => x.Value).ThenBy(b => b.Key))
            {

                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}g");

                }


            }
            Console.WriteLine("Areas with hungry animals:");
            foreach (var item in zoo2.OrderByDescending(x => x.Value.Count))
            {
                if (item.Value.Count>0)
                {
                    Console.WriteLine($"{item.Key} : {item.Value.Count}");

                }




            }

        }
    }
}
