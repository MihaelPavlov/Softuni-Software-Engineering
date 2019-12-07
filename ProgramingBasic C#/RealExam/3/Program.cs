using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            string projekciq = Console.ReadLine();
            string packetMovie = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());

            double price = 0;


            if(projekciq == "John Wick")
            {
                if (packetMovie == "Drink")
                {
                    price = 12;
                }
                else if(packetMovie == "Popcorn")
                {
                    price = 15;
                }
                else if(packetMovie == "Menu")
                {
                    price = 19;
                }
            }
            else if (projekciq == "Star Wars")
            {
                if (packetMovie == "Drink")
                {
                    price = 18;
                }
                else if (packetMovie == "Popcorn")
                {
                    price = 25;
                }
                else if (packetMovie == "Menu")
                {
                    price = 30;
                }
            }
            else if (projekciq == "Jumanji")
            {
                if (packetMovie == "Drink")
                {
                    price = 9;
                }
                else if (packetMovie == "Popcorn")
                {
                    price = 11;
                }
                else if (packetMovie == "Menu")
                {
                    price = 14;
                }
            }

            double allPrice = price * tickets;
            double promotion = 0;

            if (projekciq == "Star Wars")
            {
                
                if (tickets >= 4)
                {
                    promotion = allPrice * 0.30;
                    allPrice = allPrice - promotion;
                }
            }
            else if (projekciq == "Jumanji")
            {
                if (tickets == 2)
                {
                    promotion = allPrice * 0.15;
                    allPrice = allPrice - promotion;
                }
            }

            Console.WriteLine($"Your bill is {allPrice:f2} leva.");



        }
    }
}
