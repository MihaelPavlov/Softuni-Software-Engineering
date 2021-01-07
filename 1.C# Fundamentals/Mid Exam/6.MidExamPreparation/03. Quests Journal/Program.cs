using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Quests_Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine()
                .Split(", ")
                .ToList();


            string line = Console.ReadLine();
            while (line !="Retire!")
            {
               
                string[] commandArgs = line.Split(" - ");
                string command = commandArgs[0];
                string quest = commandArgs[1];

                if (command == "Start")
                {
                    if (journal.Contains(quest))
                    {
                        
                    }
                    else
                    {
                        journal.Add(quest);
                    }
                }
                else if (command == "Complete")
                {

                    if (!journal.Contains(quest))
                    {
                        
                    }
                    else
                    {
                        journal.Remove(quest);
                    }
                }
                else if (command == "Side Quest")
                {

                    List<string> listStringSplit = quest
                        .Split(":")
                        .ToList();

                    string leftSide =listStringSplit[0];
                    string rightSide = listStringSplit[1];
                    if (journal.Contains(leftSide))
                    {
                        int index = journal.IndexOf(leftSide);
                        if (!journal.Contains(rightSide))
                        {
                            journal.Insert(index +1 , rightSide);
                        }
                    }
                    
                  
                }
                else if (command=="Renew")
                {
                    if (journal.Contains(quest))
                    {
                        journal.Remove(quest);
                        journal.Add(quest);
                    }
                }
                line = Console.ReadLine();
                
            }
            Console.Write(string.Join(", ",journal));
        }
    }
}
