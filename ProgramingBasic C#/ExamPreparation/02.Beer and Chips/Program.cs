using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Beer_and_Chips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budjet = double.Parse(Console.ReadLine());
            int bottleBeer = int.Parse(Console.ReadLine());
            int packetChips = int.Parse(Console.ReadLine());

            double priceBeer = bottleBeer * 1.20;
            double priceChips = priceBeer *0.45;
            double priceChipses =Math.Ceiling( priceChips * packetChips);
            double allMoneyForFood = priceBeer + priceChipses;
            double leftMoney = budjet - allMoneyForFood;
            double moneyNeeded = allMoneyForFood - budjet;

            if (budjet>=allMoneyForFood)
            {
                Console.WriteLine($"{name} bought a snack and has {leftMoney:F2} leva left.");
            }
            else if (budjet<allMoneyForFood)
            {
                Console.WriteLine($"{name} needs {moneyNeeded:F2} more leva!");
            }
        }
    }
}
