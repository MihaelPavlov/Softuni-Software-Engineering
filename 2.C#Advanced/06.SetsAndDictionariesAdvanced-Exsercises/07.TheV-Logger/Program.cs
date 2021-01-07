using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var nameAndFollowers = new Dictionary<string,List<string>>();
            var nameAndFollowings = new Dictionary<string,List<string>>();
            
            while (input!="Statistics")
            {
                string[] cmdArgs = input.Split();
                string name = cmdArgs[0];
                string command =cmdArgs[1];

                if (command== "joined")
                {
                    if (!nameAndFollowers.ContainsKey(name))
                    {
                        nameAndFollowers.Add(name, new List<string>());
                        nameAndFollowings.Add(name, new List<string>());

                    }
                }
                else if (command=="followed")
                {
                    string secondName = cmdArgs[2];

                    if (nameAndFollowers.ContainsKey(name) && nameAndFollowers.ContainsKey(secondName))
                    {
                        if (secondName!=name)
                        {
                            if (!nameAndFollowers[secondName].Contains(name))
                            {
                                nameAndFollowers[secondName].Add(name);
                                nameAndFollowings[name].Add(secondName);

                            }
                        }
                    }

                }
                input = Console.ReadLine();
            }
            string getNameFamous = string.Empty;
            foreach (var item in nameAndFollowers.OrderByDescending(x => x.Value.Count))
            {
               getNameFamous=item.Key;
                break;
            }
            Console.WriteLine($"The V-Logger has a total of {nameAndFollowers.Count} vloggers in its logs.");
            int counter = 1;




            foreach (var item in nameAndFollowers.OrderByDescending(x=>x.Value.Count).ThenBy(x=>nameAndFollowings.Values))
            {
                
                Console.WriteLine($"{counter}. {item.Key} : {item.Value.Count} followers, {nameAndFollowings[item.Key].Count} following");
                
                foreach (var name in item.Value.OrderBy(x=>x))
                {
                    if (getNameFamous == item.Key)
                    {
                        Console.WriteLine($"*  {name}");

                    }
                    nameAndFollowers.Remove(item.Key);
                    nameAndFollowings.Remove(item.Key);
          

                }
                counter++;
                break;
                  
            }

            foreach (var item in nameAndFollowers.OrderByDescending(x=>x.Value.Count))
            {
              
                    Console.WriteLine($"{counter}. {item.Key} : {item.Value.Count} followers, {nameAndFollowings[item.Key].Count} following");


                
                counter++;
            }


        }
    }
}
