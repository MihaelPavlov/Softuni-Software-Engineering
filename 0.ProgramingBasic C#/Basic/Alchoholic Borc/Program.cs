using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alchoholic_Borc
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceWhiskey = double.Parse(Console.ReadLine());
            double ltBeer = double.Parse(Console.ReadLine());
            double ltWine = double.Parse(Console.ReadLine());
            double ltRakia = double.Parse(Console.ReadLine());
            double ltWhiskey = double.Parse(Console.ReadLine());

            double priceRakia = priceWhiskey / 2;
            double priceWine = priceRakia - (0.4 * 25);
            double priceBeer = priceRakia - (0.8 * 25);

            double allPriceRakia = ltRakia * priceRakia;
            double allPriceWine = ltWine * priceWine;
            double allPriceBeer = ltBeer * priceBeer;
            double allPriceWhiskey = ltWhiskey * priceWhiskey;

            double allPrice = allPriceBeer + allPriceRakia + allPriceWhiskey + allPriceWine;

            Console.WriteLine($"{allPrice:F2}");
           

        }
    }
}
