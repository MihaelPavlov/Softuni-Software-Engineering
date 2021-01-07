using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.BattleManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> dictOneHealth = new Dictionary<string, int>();
            Dictionary<string, int> dictTwoEnergy = new Dictionary<string, int>();



            while (input != "Results")
            {
                string[] cmdArgs = input.Split(":");
                string command = cmdArgs[0];

                if (command=="Add")
                {
                    string personName = cmdArgs[1];
                    int health = int.Parse(cmdArgs[2]);
                    int energy = int.Parse(cmdArgs[3]);

                    if (!dictOneHealth.ContainsKey(personName))
                    {
                        dictOneHealth.Add(personName, health);
                        dictTwoEnergy.Add(personName, energy);
                    }
                    else
                    {
                        dictOneHealth[personName] += health;
                       
                    }

                }
                else if (command=="Attack")
                {
                    string attackerName = cmdArgs[1];
                    string defenderName = cmdArgs[2];
                    int damage = int.Parse(cmdArgs[3]);
                    if (dictOneHealth.ContainsKey(attackerName) && dictOneHealth.ContainsKey(defenderName))
                    {
                        dictOneHealth[defenderName] -= damage;
                        
                        if (dictOneHealth[defenderName]<=0)//carful
                        {
                            dictOneHealth.Remove(defenderName);
                            dictTwoEnergy.Remove(defenderName);
                            Console.WriteLine($"{defenderName} was disqualified!");
                        }
                        //attacker
                        dictTwoEnergy[attackerName] -= 1;
                        if (dictTwoEnergy[attackerName]<=0)
                        {
                            dictOneHealth.Remove(attackerName);
                            dictTwoEnergy.Remove(attackerName);
                            Console.WriteLine($"{attackerName} was disqualified!");

                        }
                    }
                }
                else if (command=="Delete")
                {
                    string username = cmdArgs[1];

                    if (dictOneHealth.ContainsKey(username))
                    {
                        dictOneHealth.Remove(username);
                        dictTwoEnergy.Remove(username);
                    }
                    else if (username== "All")
                    {
                        dictOneHealth.Clear();
                        dictTwoEnergy.Clear();
                    }
                }
                input = Console.ReadLine();

            }

            Console.WriteLine($"People count: {dictOneHealth.Count}");
            foreach (var person in dictOneHealth.OrderByDescending(x=>x.Value).ThenBy(b=>b.Key))
            {
                Console.WriteLine($"{person.Key} - {person.Value} - {dictTwoEnergy[person.Key]}");
            }
        }
    }
}
