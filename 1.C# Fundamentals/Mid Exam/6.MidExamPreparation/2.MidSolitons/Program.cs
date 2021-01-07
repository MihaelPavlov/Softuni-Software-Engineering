using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.MidSolitons
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> weoponParts = Console.ReadLine()
                .Split("|")
                .ToList();
            List<string> even = new List<string>();
            List<string> odd = new List<string>();


            string input = Console.ReadLine();
            while (input != "Done")
            {
                string[] commandArgs = input.Split(" ");


                if (commandArgs[1] == "Left")
                {
                    int index = int.Parse(commandArgs[2]);
                    if (index >= 0 && index+1 < weoponParts.Count)
                    {
                        if (index < 0 && index >= weoponParts.Count)
                        {

                        }
                        else
                        {
                            string getIndexValue = weoponParts[index];
                            if (index == 0)
                            {

                            }
                            else
                            {
                                weoponParts.Insert(index - 1, getIndexValue);
                                weoponParts.RemoveAt(index + 1);
                            }


                        }
                    }

                }
                if (commandArgs[1] == "Right")
                {
                    int index = int.Parse(commandArgs[2]);


                    if (index >= 0 && index+2 < weoponParts.Count)
                    {
                        if (index + 2 > weoponParts.Count)
                        {

                        }
                        else
                        {
                            string getIndexValue = weoponParts[index];

                            weoponParts.Insert(index + 2, getIndexValue);
                            weoponParts.RemoveAt(index);
                        }

                    }
                }
                 if (commandArgs[1] == "Even")
                {
                    for (int i = 0; i < weoponParts.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            even.Add(weoponParts[i]);
                        }
                        else
                        {
                            odd.Add(weoponParts[i]);
                        }
                    }
                    if (commandArgs[1] == "Even")
                    {
                        foreach (var item in even)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                    }


                }
                 if (commandArgs[1] == "Odd")
                {                  
                    for (int i = 0; i < weoponParts.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            even.Add(weoponParts[i]);
                        }
                        else
                        {
                            odd.Add(weoponParts[i]);
                        }
                    }

                    if (commandArgs[1] == "Odd")
                    {
                        foreach (var item in odd)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                    }
                }


                input = Console.ReadLine();
            }
            
            Console.WriteLine($"You crafted {(string.Join("", weoponParts))}!");

        }
    }
}
