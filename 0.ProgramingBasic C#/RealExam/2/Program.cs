using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string serialName = Console.ReadLine();
            double episodeTime = int.Parse(Console.ReadLine());
            double restTime =int.Parse(Console.ReadLine());

            double lunchTime = (restTime * 1 /8) ;
            double rest =restTime * 1 / 4;
            double leaveTime = (restTime - lunchTime - rest);
            double difference = leaveTime - episodeTime;

            if (difference < 0)
            {
                difference = Math.Floor(difference);
            }
            else
            {
                difference = Math.Ceiling(difference);
            }

            if (difference>=0)
            {
                Console.WriteLine($"You have enough time to watch {serialName} and left with {difference} minutes free time.");
            }
            else 
            {
                Console.WriteLine($"You don't have enough time to watch {serialName}, you need {Math.Abs(difference)} more minutes.");
            }


        }
    }
}
