using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRoom
{
    class Program
    {
        static void Main(string[] args)
        {

            string mount = Console.ReadLine();
            int hoursPlayed = int.Parse(Console.ReadLine());
            int peopleNumber = int.Parse(Console.ReadLine());
            string dayTime = Console.ReadLine();

            double priceForHour = 0;
           
            if (mount == "march" || mount == "april"|| mount == "may")
            {

                if (dayTime=="day")
                {
                    priceForHour = 10.50; ;
                }
                else if (dayTime == "night")
                {
                    priceForHour = 8.40;
                }
               
                
            }
            if (mount == "june" || mount == "july" || mount == "august")
            {
                if (dayTime == "day")
                {
                    priceForHour = 12.60; ;
                }
                else if (dayTime == "night")
                {
                    priceForHour = 10.20;
                }
            }

            if (peopleNumber >= 4)
            {
                priceForHour = priceForHour - 0.10 * priceForHour;
                
            }
            if (hoursPlayed >= 5)
            {
                priceForHour = priceForHour - 0.50 * priceForHour;
            }


            double totalCost = priceForHour * peopleNumber;
            Console.WriteLine($"Price per person for one hour: {priceForHour:F2}");
            Console.WriteLine($"Total cost of the visit: {totalCost*peopleNumber:F2}");
        }
    }
}
