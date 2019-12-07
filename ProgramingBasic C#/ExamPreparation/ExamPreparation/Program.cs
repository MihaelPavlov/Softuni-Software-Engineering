using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int sectorsOnStadion = int.Parse(Console.ReadLine());
            int capasityStadion = int.Parse(Console.ReadLine());
            double priceForOneTicket = double.Parse(Console.ReadLine());

            double allMoney = capasityStadion * priceForOneTicket;
            double moneyForOneSector = allMoney / sectorsOnStadion;
            double moneyForCharity = (allMoney - (moneyForOneSector * 0.75)) / 8;


            Console.WriteLine($"Total income - {allMoney:f2} BGN");
            Console.WriteLine($"Money for charity - {moneyForCharity:f2} BGN");
        }
    }
}
