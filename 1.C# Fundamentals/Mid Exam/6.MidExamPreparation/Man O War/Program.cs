using System;
using System.Collections.Generic;
using System.Linq;

namespace Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToArray();

            int[] warShip = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToArray();

            int maximumHealtCapacity = int.Parse(Console.ReadLine());

            int count = 0;
            bool win = false;
            string input = null;
            while ((input = Console.ReadLine())!="Retire")
            {
                string[] line = input.Split(" ");
                string command = line[0];
                int index = -1;
                int damage = 0;

               
                if (command == "Fire")
                {

                     index = int.Parse(line[1]);
                    damage = int.Parse(line[2]);

                    // startiindex = 0
                    // endindex = 4
                    // count = 5 - 5
                    // 0 1 2 3 4 5
                    // 9 8 7 6 2
                    if (index >= 0 && index < warShip.Length)
                    {
                        warShip[index] -= damage;
                        if (warShip[index] <= 0)
                        {
                            Console.WriteLine($"You won! The enemy ship has sunken.");
                            win = true;
                        }
                    }
                }
                else if (command == "Defend")
                {
                     index = int.Parse(line[1]);
                    int endIndex = int.Parse(line[2]);
                    damage = int.Parse(line[3]);
                    //проверявам дали индекса е по голям от броя на индексите в листа
                    if (index >= 0 && index < myShip.Length &&
                        endIndex > 0 && endIndex < myShip.Length)
                    {
                        for (int i = index; i <= endIndex; i++)
                        {

                            myShip[i] -= damage;
                            if (myShip[i]<=0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                win = true;
                                break;
                            }

                        }
                    }
                }
                else if (command == "Repair")
                {
                    index = int.Parse(line[1]);
                    int health = int.Parse(line[2]);

                    if (index >= 0 && index < myShip.Length)
                    {
                        myShip[index] += health;
                        if (myShip[index] > maximumHealtCapacity)
                        {
                            myShip[index] = maximumHealtCapacity;
                        }
                    }

                }
                else if (command == "Status")
                {
                    foreach (int sections in myShip)
                    {
                        double temp = 0.2 * maximumHealtCapacity;
                        if (sections<temp)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine($"{count} sections need repair.");
                }

                if (win)
                {
                    break;
                }

            }
           
            if (!win)
            {
                int myshipSum = 0;
                int warshipSum = 0;

                foreach (int i in myShip)
                {
                    myshipSum += i;
                }
                foreach (int i in warShip)
                {
                    warshipSum += i;
                }
               
                    Console.WriteLine($"Pirate ship status: {myshipSum}");
                    Console.WriteLine($"Warship status: {warshipSum}");
                
            }
            





        }
    }
}
