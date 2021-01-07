using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Lili
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int singleToyPrice = int.Parse(Console.ReadLine());

            int toysCounter = 0;
            int giftMoney = 10;
            double savedMoney = 0;
            int takenFromBrother = 0;

            for (int year = 1; year <= age; year++)
            {
                if (year % 2 == 0)
                {
                    takenFromBrother++;
                    savedMoney += giftMoney;
                    giftMoney += 10;
                }
                else
                {
                    toysCounter++;
                }
            }
            double moneyFromToys = toysCounter * singleToyPrice;
            double finalSum = moneyFromToys + savedMoney - takenFromBrother;

            if (finalSum >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {finalSum - washingMachinePrice:F2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachinePrice-finalSum:F2}");
            }

        }
    }
}
