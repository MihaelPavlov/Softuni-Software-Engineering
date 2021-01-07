using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Going_home
{
    class Program
    {
        static void Main(string[] args)
        {
            int km = int.Parse(Console.ReadLine());
            double benzinFor100km = double.Parse(Console.ReadLine());
            double PriceForBenzin1Liter = double.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());

            double carCut = km * benzinFor100km / 100;
            double allCarRazhod = carCut * PriceForBenzin1Liter;
            double allMoney = allCarRazhod - money;
            double moneySpent = money - allCarRazhod;
            double moneyLeft = money / 5.0;

            if (money>=allCarRazhod)
            {
                Console.WriteLine($"You can go home. {moneySpent:f2} money left.");
            }
            else if(money<allCarRazhod)
            {
                Console.WriteLine($"Sorry, you cannot go home. Each will receive {moneyLeft:f2} money.");
            }
            

        }
    }
}
