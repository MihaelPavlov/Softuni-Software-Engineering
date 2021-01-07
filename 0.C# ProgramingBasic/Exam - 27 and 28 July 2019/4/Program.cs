using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int singer = int.Parse(Console.ReadLine());

            ;
            int cuvert = 0;
            int countMoney = 0;
            int quests = 0;
            int counterOFQuest = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "The restaurant is full")
                {
                    break;
                }
                quests = int.Parse(command);

                counterOFQuest += quests;

                
                if (quests < 5)
                {
                    cuvert = quests *100;
                    countMoney += cuvert;
                }
                else if (quests >= 5)
                {
                    cuvert =quests * 70;
                    countMoney += cuvert;
                }

            }

            int leaveSum = countMoney - singer;
            if (singer<=countMoney)
            {
                Console.WriteLine($"You have {counterOFQuest} guests and {leaveSum} leva left.");
            }
            else if (singer > countMoney)          
            {
                Console.WriteLine($"You have {counterOFQuest} guests and {countMoney} leva income, but no singer. ");
            }
            

        }
    }
}
