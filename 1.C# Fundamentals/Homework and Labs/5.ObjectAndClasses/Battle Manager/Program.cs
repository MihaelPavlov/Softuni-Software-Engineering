using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle_Manager
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> personNamesList = new List<string>();
            List<int> healthList = new List<int>();
            List<int> energyList = new List<int>();

            string line = "";

            while (true)
            {
                line = Console.ReadLine();
                string[] command = line.Split(":");
                string realCommand = command[0];
              //  string personName = command[1];
             //   string healt = command[2];
             //  string energy = command[3];


                if (realCommand == "Add")
                {
                    
                    int heal = int.Parse(command[2]);
                    int energ = int.Parse(command[3]);
                    if (personNamesList.Contains(command[1]))
                    {
                        healthList.Add(heal);
                        energyList.Add(energ);
                    }
                    else
                    {
                        personNamesList.Add(command[1]);
                        healthList.Add(heal);
                        energyList.Add(energ);
                    }
                    
                }
                else if (realCommand == "Ättack")
                {
                    if (personNamesList.Contains(command[1]) && personNamesList.Contains(command[2]))
                    {
                        int dmg = int.Parse(command[3]);
                        healthList()

                    }
                }
            }
         

        }
    }
}
