using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training._01
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeForRest = int.Parse(Console.ReadLine());
            double priceForOnePart = double.Parse(Console.ReadLine());
            double priceForOneProgram = double.Parse(Console.ReadLine());
            double priceForFrape = double.Parse(Console.ReadLine());

            double relax = 0;
            double relax2 = 0;
            double timeForRelax = 0;
            double spendMoneyPart = 0;
            double spendMoneyProgram = 0;
            double allSpendMoney = 0;

            timeForRest -= 5;
            relax = 3 * 2;
            relax2 = 2 * 2;
            timeForRelax = timeForRest - (relax + relax2);
            spendMoneyPart = 3 * priceForOnePart;
            spendMoneyProgram = 2 * priceForOneProgram;
            allSpendMoney = spendMoneyPart + spendMoneyProgram + priceForFrape;

            Console.WriteLine($"{allSpendMoney:F2}");
            Console.WriteLine(timeForRelax);








        }
    }
}
