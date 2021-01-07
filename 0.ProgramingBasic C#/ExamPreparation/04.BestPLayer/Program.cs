using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BestPLayer
{
    class Program
    {
        static void Main(string[] args)
        {

            string newPlayerName = Console.ReadLine();
            int newgoals = 0;
            string bestPlayer = string.Empty;
            int bestPlayerGoals =0;

            while (newPlayerName!= "END")
            {
                
                newgoals = int.Parse(Console.ReadLine());

                

                if (newgoals > bestPlayerGoals)
                {
                    bestPlayer = newPlayerName;
                    bestPlayerGoals = newgoals;
                }
                if (newgoals >= 10)
                {
                    break;
                }

                newPlayerName = Console.ReadLine();
                


            }
            Console.WriteLine($"{bestPlayer} is the best player!");

            if (bestPlayerGoals >= 3)
            {
                Console.WriteLine($"He has scored {bestPlayerGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {bestPlayerGoals} goals.");
            }

        }
    }
}
