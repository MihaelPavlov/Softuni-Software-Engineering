using System;
using System.Collections.Generic;
using System.Linq;


namespace FinalExamPreparationTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> bandList = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandTime = new Dictionary<string, int>();

            while (input!="start of concert")
            {
                string[] cmdArgs = input.Split(new string[] { "; ", ", " }, new StringSplitOptions());
                string command = cmdArgs[0];
                string nameBand = cmdArgs[1];

                if (command=="Add")
                {
                    if (!bandList.ContainsKey(nameBand))
                    {
                        bandList.Add(nameBand, new List<string>());
                        for (int i = 2; i < cmdArgs.Length; i++)
                        {
                            if (!bandList[nameBand].Contains(cmdArgs[i]))
                            {
                                bandList[nameBand].Add(cmdArgs[i]);
                            }
                            
                        }
                    }
                    else
                    {
                        for (int i = 2; i < cmdArgs.Length; i++)
                        {
                            if (!bandList[nameBand].Contains(cmdArgs[i]))
                            {
                                bandList[nameBand].Add(cmdArgs[i]);
                            }

                        }

                    }
                }
                else if (command=="Play")
                {
                    int time = int.Parse(cmdArgs[2]);

                    if (!bandTime.ContainsKey(nameBand))
                    {
                        bandTime.Add(nameBand, time);
                    }
                    else
                    {
                        bandTime[nameBand] += time;
                    }
                }




                input = Console.ReadLine();
            }
            string finalInput = Console.ReadLine();
            int total = 0;
            foreach (var band in bandTime)
            {
                total += band.Value;
               
            }
            Console.WriteLine($"Total time: {total}");
            foreach (var band in bandTime.OrderByDescending(x=>x.Value).ThenBy(b=>b.Key))
            {
                total += band.Value;
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            Console.WriteLine(finalInput);
            foreach (var bandName in bandList[finalInput])
            {
                Console.WriteLine($"=> {bandName}");
            }
        }
    }
}
