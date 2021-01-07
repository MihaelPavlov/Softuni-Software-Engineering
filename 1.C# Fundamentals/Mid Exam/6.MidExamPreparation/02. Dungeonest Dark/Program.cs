using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Dungeonest_Dark
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine()
                .Split("|")
                .ToArray();
            

            int health = 100;
            int coins = 0;
            int roomCount = 0;
            bool win = false;

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] commandArgs = rooms[i].Split(" ");
                string command = commandArgs[0];
                roomCount++;
                if (command== "potion")
                {
                    if (health== 100)
                    {
                        Console.WriteLine("You healed for 0 hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else
                    {
                        int healing = int.Parse(commandArgs[1]);
                        health = health + healing;
                        int rlyhealing = health - 100;
                        int rlyhealing2 = healing - rlyhealing;
                        if (health>100)
                        {
                            
                            health = 100;
                            Console.WriteLine($"You healed for {rlyhealing2} hp.");
                            Console.WriteLine($"Current health: {health} hp.");
                        }
                        else
                        {
                            Console.WriteLine($"You healed for {healing} hp.");
                            Console.WriteLine($"Current health: {health} hp.");
                        }
                        
                    }
                }
                else if (command =="chest")
                {
                   int addCoins = int.Parse(commandArgs[1]);
                    coins += addCoins;
                    Console.WriteLine($"You found {addCoins} coins.");
                }
                else
                {
                    int attackOfTheMonster = int.Parse(commandArgs[1]);
                    health = health - attackOfTheMonster;
                    if (health>0)
                    {
                        Console.WriteLine($"You slayed {command}.");
                    }
                    else if (health<=0)
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {roomCount}");
                        win = false;
                        break;
                    }
                    
                }
                win = true;
            }
            if (win == true)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
