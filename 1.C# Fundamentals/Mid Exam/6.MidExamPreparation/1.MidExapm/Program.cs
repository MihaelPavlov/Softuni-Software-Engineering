using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.MidExapm
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountBiscuitsDay = int.Parse(Console.ReadLine());
            int countWorker = int.Parse(Console.ReadLine());
            double biscuitsFor30Days = double.Parse(Console.ReadLine());

            double oneMount = 30;
            int count = 0;
            double countEarns = 0;
            double pastMount = 0;
            double countDays = 0;
            while (count!=30)
            {
                if (count % 3 == 0)
                {
                    countEarns =Math.Floor (countEarns + ((amountBiscuitsDay * countWorker) * 0.75));
                    countDays++;
                }
                else
                {
                    pastMount = pastMount + (amountBiscuitsDay * countWorker);
                }
                count++;
            }
                  
            double total = (pastMount + countEarns);
            double total2 =  total - biscuitsFor30Days;
            double endTotal =Math.Abs(total2 /biscuitsFor30Days) * 100;

            if (biscuitsFor30Days<total)
            {
                Console.WriteLine($"You have produced {total} biscuits for the past month.");

                Console.WriteLine($"You produce {endTotal:F2} percent more biscuits.");

            }
            else if(biscuitsFor30Days>total)
            {
                Console.WriteLine($"You have produced {total} biscuits for the past month.");

                Console.WriteLine($"You produce {endTotal:f2} percent less biscuits.");

            }
        }
    }
}
