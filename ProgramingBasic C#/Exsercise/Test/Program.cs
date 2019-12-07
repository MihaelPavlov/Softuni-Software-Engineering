using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int price = 0;

            if (dates=="21-23")
            {
                if (destination == "France")
                {
                    price = 30;
                }
                else if(destination == "Italy")
                {
                    price = 28;
                }
                else if (destination == "Germany")
                {
                    price = 32;
                }
            }
            else if (dates == "24-27")
            {
                if (destination == "France")
                {
                    price = 35;
                }
                else if (destination == "Italy")
                {
                    price = 32;
                }
                else if (destination == "Germany")
                {
                    price = 37;
                }
            }
            else if (dates == "28-31")
            {
                if (destination == "France")
                {
                    price = 40;
                }
                else if (destination == "Italy")
                {
                    price = 39;
                }
                else if (destination == "Germany")
                {
                    price = 43;
                }
            }
            int allPrice = days * price;
            Console.WriteLine($"Easter trip to {destination:F2} : {allPrice:f2} leva.");
        }
    }
}
