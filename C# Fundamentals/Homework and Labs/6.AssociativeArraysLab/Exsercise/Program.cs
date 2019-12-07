using System;
using System.Collections.Generic;
using System.Linq;

namespace Exsercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> studentInfo = new Dictionary<string, string>();
            Dictionary<string, string> moreInfo = new Dictionary<string, string>();
            string input = Console.ReadLine();


            while (input != "end")
            {
                string[] commandArgs = input.Split(" ");
                string nameOrCommand = commandArgs[0];
                

                
                if (nameOrCommand == "FindNumber")
                {
                    if (studentInfo.ContainsKey(commandArgs[1]))
                    {
                        Console.WriteLine(studentInfo.Values);
                    }
                }
                else if (!studentInfo.ContainsKey(nameOrCommand))
                {
                    studentInfo.Add(commandArgs[0], commandArgs[1]);
                    moreInfo.Add(commandArgs[2], commandArgs[3]);
                }
                
                input = Console.ReadLine();
            }
        }
    }
}
