using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam1
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForFoodDay = double.Parse(Console.ReadLine());
            double moneyForSouveniersDay = double.Parse(Console.ReadLine());
            double moneyForHotelDay = double.Parse(Console.ReadLine());

            double neededGas = 29.4;
            double moneyForGas = neededGas * 1.85;
            double moneyForFoodAndSouveniers = 3 * moneyForFoodDay + 3 * moneyForSouveniersDay;

            double firstDayHotel = moneyForHotelDay * 0.9;
            double secondDayHotel = moneyForHotelDay * 0.85;
            double thirdDayHotel = moneyForHotelDay * 0.8;

            double allSum = moneyForGas + moneyForFoodAndSouveniers + firstDayHotel + secondDayHotel + thirdDayHotel;

            Console.WriteLine($"Money needed: {allSum:f2}");

        }
    }
}
