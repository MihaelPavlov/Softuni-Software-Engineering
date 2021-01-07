using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            dict["fragments"] = 0;
            dict["motes"] = 0;
            dict["shards"] = 0;

            Dictionary<string, int> junkElements = new Dictionary<string, int>();

            bool haveWinner = false;
            while (true)
            {

                
                var tokens = Console.ReadLine()
                    .ToLower()
                    .Split(" ")
                    .ToArray();

                for (int i = 0; i < tokens.Length; i += 2)
                {
                    string type = tokens[i + 1];
                    int quantity = int.Parse(tokens[i]);
                    if (type == "fragments" || type == "motes" || type == "shards")
                    {
                        if (!dict.ContainsKey(type))
                        {
                            dict.Add(type, quantity);
                        }
                        else
                        {
                            dict[type] += quantity;
                        }
                    }
                    else
                    {
                        if (!junkElements.ContainsKey(type))
                        {
                            junkElements.Add(type, quantity);

                        }
                        else
                        {
                            junkElements[type] += quantity;
                        }
                    }

                    if (dict["fragments"] >= 250)
                    {
                        dict["fragments"] -= 250;
                        Console.WriteLine("Valanyr obtained!");
                        haveWinner = true;
                        break;
                    }


                    else if (dict["motes"] >= 250)
                    {
                        dict["motes"] -= 250;
                        Console.WriteLine("Dragonwrath obtained!");
                        haveWinner = true;
                        break;
                    }



                    else if (dict["shards"] >= 250)
                    {
                        dict["shards"] -= 250;
                        Console.WriteLine("Shadowmourne obtained!");
                        haveWinner = true;
                        break;
                    }

                    

                }
                if (haveWinner == true)
                {
                    break;
                }
            }


            foreach (var item in dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junkElements.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
    }
}
