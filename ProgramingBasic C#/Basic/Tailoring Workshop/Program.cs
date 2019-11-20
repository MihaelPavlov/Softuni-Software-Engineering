using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int tables = int.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double areaTables =tables * (lenght + 2 * 0.30) * (width + 2 * 0.30);
            double areaKareta =tables* ( lenght / 2 )* (lenght / 2);


            double priceUsd = areaTables * 7 + areaKareta * 9;
            double priceBgn = priceUsd * 1.85;

            Console.WriteLine($"{priceUsd:F2} USD");
            Console.WriteLine($"{priceBgn:f2} BGN");

        }
    }
}
