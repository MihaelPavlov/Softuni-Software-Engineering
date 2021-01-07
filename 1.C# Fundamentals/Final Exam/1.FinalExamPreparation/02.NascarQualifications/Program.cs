using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.NascarQualifications
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            string command = Console.ReadLine();
            List<string> race = new List<string>(input);
            while (command != "end")
            {
                string[] cmdArgs = command.Split(" ");
                string cmd = cmdArgs[0];
                string racer = cmdArgs[1];

                if (cmd == "Race")
                {
                    if (!race.Contains(racer))
                    {
                        race.Add(racer);
                    }

                }
                else if (cmd == "Accident")
                {
                    if (race.Contains(racer))
                    {
                        race.Remove(racer);
                    }
                    
                }
                else if (cmd == "Box")
                {
                    if (race.Contains(racer))
                    {
                        int index = race.IndexOf(racer);
                        if (index+1  <= race.Count - 1)
                        {
                            race.Reverse(index, index+1);
                            //race.Insert(index + 1, racer);
                            //race.RemoveAt(index);
                        }
                    }
                }
                else if (cmd == "Overtake")
                {
                    if (race.Contains(racer))
                    {
                        int racersCount = int.Parse(cmdArgs[2]);
                        int index = race.IndexOf(racer);
                        if (index+ race.Count  <= race.Count)
                        {
                            race.Insert(index + racersCount, racer);
                        }
                    }
                    

                }











                command = Console.ReadLine();

            }
            Console.WriteLine(string.Join(" ~ ", race));
        }
    }
}
