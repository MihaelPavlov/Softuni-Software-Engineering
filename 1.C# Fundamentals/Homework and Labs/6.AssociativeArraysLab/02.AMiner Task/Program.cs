using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.AMiner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> all = new Dictionary<string, int>();


            int count = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "stop")
                {
                    break;
                }
                int command2 = int.Parse(Console.ReadLine());
                

                //string[] resources = command
                //    .Split();

                //int[] quantity = command2
                //    .Split()
                //    .Select(int.Parse)
                //    .ToArray();

                if (!all.ContainsKey(command))
                {
                    all.Add(command, command2);
                }
                else
                {
                    all[command] += command2;
                }
            }
            foreach (var item in all)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }



        }
    }
}
