using System;
using System.Collections.Generic;
using System.Linq;

namespace Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine()
                .Split("|")
                .ToList();

            string line = Console.ReadLine();
            while (line != "Yohoho!")
            {
                List<string> command = line.Split(" ").ToList();
                string cmd = command[0];

                if (cmd == "Loot")
                {               //маха първия елемент и взимаме останалите ,и ги слагаме в масива
                    string[] items = command.Skip(1).ToArray();
                    LootChest(items, chest);
                }
                else if (cmd == "Drop")
                {
                    int dropIndex = int.Parse(command[1]);
                    DropChest(dropIndex, chest);
                }
                else if (cmd == "Steal")
                {
                    int count = int.Parse(command[1]);
                    StealChest(count, chest);
                }
                line = Console.ReadLine();
            }
            double average = GetAverageChest(chest);

            if (chest.Count != 0)
            {
                Console.WriteLine($"Average treasure gain: {average:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }

        private static double GetAverageChest(List<string> chest)
        {
            double sum = 0;
            foreach (string item in chest)
            {
                sum += item.Length;

            }
            double average = sum / chest.Count;
            return average;
        }

        private static void StealChest(int count, List<string> chest)
        {
            int index = chest.Count - count;

            string[] deleteItems = null;


            if (index >= 0)
            {
                deleteItems = chest.Skip(index).ToArray();
                chest.RemoveRange(index, count);
            }
            else
            {
                deleteItems = chest.ToArray();
                chest.Clear();
            }

            Console.WriteLine(string.Join(", ", deleteItems));

        }

        private static void DropChest(int dropIndex, List<string> chest)
        {
            if (IsValidIndex(dropIndex, chest))
            {
                string items = chest[dropIndex];//Тук запазваме Думичката която е на този индекс и после я добавяме в края 
                chest.RemoveAt(dropIndex);
                chest.Add(items);
            }




        }

        private static bool IsValidIndex(int index, List<string> list)
        {
            return index >= 0 && index < list.Count;
        }

        private static void LootChest(string[] items, List<string> chest)
        {
            foreach (string item in items)
            {
                if (!chest.Contains(item))
                {
                    chest.Insert(0, item);
                }


            }
        }
    }
}
