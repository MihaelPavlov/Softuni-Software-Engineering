using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0._6_TicketCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hoursPerDay = int.Parse(Console.ReadLine());
            double totalSumForParking = 0;
            double sumPerDay = 0;

            for (int currenDay = 1; currenDay <= days; currenDay++)
            {
                for (int currentHours = 1; currentHours <= hoursPerDay; currentHours++)
                {
                    if (currenDay % 2 == 0 && currentHours % 2 != 0)
                    {
                        totalSumForParking += 2.50;
                        sumPerDay += 2.50;
                    }
                    if(currenDay % 2 != 0 && currentHours % 2 == 0)
                    {
                        totalSumForParking += 1.25;
                        sumPerDay += 1.25;
                    }
                    if ((currenDay % 2 == 0 && currentHours % 2 == 0 || currenDay % 2 != 0 && currentHours % 2 != 0))
                    {
                        totalSumForParking++;
                        sumPerDay++;
                    }             
                }
                Console.WriteLine($"Day: {currenDay} - {sumPerDay:f2} leva");
                sumPerDay = 0;
            }
            Console.WriteLine($"Total: {totalSumForParking:f2} leva");


                
        }
    }
}
