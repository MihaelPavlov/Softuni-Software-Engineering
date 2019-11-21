using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            // номера на предметите равни на номера на студентите
            // уборудването е  lightsabers,belts, robes
            // имам сумата която е за уборудването ,колко ученика и цена на всеки предмет/
            //трябва да сметнем колоко ще му струва
            //lightsabers се чупат и трябва 10% повече да купим
            //също всеки 6 ти belts е безплатен.

            double allMoney = double.Parse(Console.ReadLine());
            double numbersStudents = double.Parse(Console.ReadLine());
            double priceLightsaber = double.Parse(Console.ReadLine());
            double priceRobe = double.Parse(Console.ReadLine());
            double priceBelt = double.Parse(Console.ReadLine());



            
            double sabers = Math.Ceiling(numbersStudents * 0.10);
            double allSabers = priceLightsaber * (sabers+numbersStudents);
            double allRobes = priceRobe * numbersStudents;

            double belt = numbersStudents;
            double belst2 = belt;
            while (belst2 >= 6)
            {
                numbersStudents--;
                belst2 -= 6;
            }
            double allBelts = priceBelt * numbersStudents;



            double endPrice = allSabers + allRobes + allBelts;


            if (allMoney>=endPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {endPrice:F2}lv.");
            }
            else
            {
                double neededMoney = endPrice - allMoney;
                Console.WriteLine($"Ivan Cho will need {neededMoney:F2}lv more.");
            }
        }
    }
}
