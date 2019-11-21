using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0._9_SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            //напиши програма която изчислява всичко изкарано.
            //източникът има начален добив
            //което е индикатор колко подправки могат да се изкарат през първия ден
            // за втория ден поправките трябват да спаднат с 10 от първите
            // и третия 10 от втория
            // екипа яде по 26 всеки ден .значи - 26 
            //

            // int extractSpice , int consume ,int leaving,

            int amount = int.Parse(Console.ReadLine());
            
            int dayCounter = 0;
            int total = 0;


            while (amount>=100)
            {

                total += amount;
                total -= 26;
                amount -= 10;
                dayCounter++;

                if (amount < 100)
                {
                    total -= 26;
                    break;
                }
            }
            

            Console.WriteLine(dayCounter);
            Console.WriteLine(total);
        }
    }
}
