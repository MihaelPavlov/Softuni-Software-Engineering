using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity_Company
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfDays = int.Parse(Console.ReadLine());
            int countOfWorkers = int.Parse(Console.ReadLine());
            int countOfCakes = int.Parse(Console.ReadLine());
            int countOfGoffreti = int.Parse(Console.ReadLine());
            int countOfPancakes = int.Parse(Console.ReadLine());

            double moneyCake = countOfCakes * 45;
            double moneyGoffreti = countOfGoffreti * 5.80;
            double moneyPancakes = countOfPancakes * 3.20;
            
            double moneyPerDay = (moneyCake + moneyGoffreti + moneyPancakes) * countOfWorkers;

            double allMoney = moneyPerDay * countOfDays;
            double afterPayship = allMoney - (allMoney / 8);


            Console.WriteLine($"{afterPayship:f2}");
        }
    }
}
