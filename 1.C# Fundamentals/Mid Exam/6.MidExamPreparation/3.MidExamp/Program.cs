using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MidExamp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> myDeck = Console.ReadLine()
                .Split(":")
                .ToList();

            List<string> newDeck = new List<string>();

            string input = Console.ReadLine();

            while (input != "Ready")
            {
                string[] commandArgs = input.Split(" ");
                string command = commandArgs[0];
                string cardName = commandArgs[1];


                if (command == "Add")
                {
                    if (myDeck.Contains(cardName))
                    {
                        newDeck.Add(cardName);
                    }
                    else if (!myDeck.Contains(cardName))
                    {
                        Console.WriteLine("Card not found.");
                    }


                }
                else if (command == "Insert")
                {
                    int index = int.Parse(commandArgs[2]);
                    if (index >= 0 && index < newDeck.Count)
                    {
                        if (myDeck.Contains(cardName))
                        {
                            newDeck.Insert(index, cardName);
                        }
                        else
                        {
                            Console.WriteLine("Error!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }
                else if (command == "Remove")
                {
                    if (newDeck.Contains(cardName))//тука може да не трябва да проверявам дали е има в моето тесте
                    {
                        newDeck.Remove(cardName);
                    }
                    else if (!newDeck.Contains(cardName))
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (command == "Swap")
                {
                    string cardName2 = commandArgs[2];
                    int getIndex1 = newDeck.IndexOf(cardName);
                    int getIndex2 = newDeck.IndexOf(cardName2);

                    newDeck.Insert(getIndex1, cardName2);
                    newDeck.Insert(getIndex2, cardName);
                    newDeck.RemoveAt(getIndex1 + 1);
                    newDeck.RemoveAt(getIndex2 + 1);

                }
                else if (command == "Shuffle")
                {
                    newDeck.Reverse();
                }

                input = Console.ReadLine();

            }
            Console.WriteLine(string.Join(" ", newDeck));
        }
    }
}
