using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks_Planner_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] task = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            List<int> inCompleteTask = new List<int>();
            int countComplete = 0;
            int countDropped = 0;
            int inCount = 0;

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] commandArgs = input.Split(" ");
                string command = commandArgs[0];

                if (command == "Complete")
                {
                    int index = int.Parse(commandArgs[1]);
                    if (index >= 0 && index < task.Length)//така проверявам дали индекса е валиден
                    {
                        task[index] = 0;
                    }
                    else
                    {
                       
                    }

                }
                else if (command == "Change")
                {
                    int index = int.Parse(commandArgs[1]);
                    int time = int.Parse(commandArgs[2]);

                    if (index >= 0 && index < task.Length)
                    {
                        //task.RemoveAt(index);
                        //task.Insert(index, time);
                        task[index] = time;
                    }
                    else
                    {
                       
                    }

                }
                else if (command == "Drop")
                {
                    int index = int.Parse(commandArgs[1]);

                    if (index >= 0 && index < task.Length)
                    {
                        task[index] = -1;
                    }
                    else
                    {
                        
                    }

                }
                else if (commandArgs[1] == "Completed")
                {
                    for (int i = 0; i < task.Length; i++)
                    {
                        if (task[i] == 0)
                        {

                            countComplete++;

                        }
                    }
                    Console.WriteLine(countComplete);
                }
                else if (commandArgs[1] == "Incomplete")
                {
                    for (int i = 0; i < task.Length; i++)
                    {
                        if (task[i] > 0 && task[i] <= 5)
                        {

                            inCount++;

                        }
                    }
                    Console.WriteLine(inCount);
                }
                else if (commandArgs[1] == "Dropped")
                {
                    for (int i = 0; i < task.Length; i++)
                    {
                        if (task[i] == -1)
                        {

                            countDropped++;

                        }
                    }
                    Console.WriteLine(countDropped);
                }
                input = Console.ReadLine();
            }


            for (int i = 0; i < task.Length; i++)
            {
                if (task[i] >= 1 && task[i] <= 5)
                {
                    inCompleteTask.Add(task[i]);

                }
            }
            Console.WriteLine(string.Join(" ",inCompleteTask));
        }
    }
}
