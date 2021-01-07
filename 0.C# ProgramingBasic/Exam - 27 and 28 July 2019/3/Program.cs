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
            string typeOfSushi = Console.ReadLine();
            string nameOfRestaurant = Console.ReadLine();
            int Porcii = int.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();

            double price = 0;

            if (nameOfRestaurant == "Sushi Zone")
            {
                if (typeOfSushi== "sashimi")
                {
                    price = 4.99;
                }
                else if (typeOfSushi == "maki")
                {
                    price = 5.29;
                }
                else if (typeOfSushi == "uramaki")
                {
                    price = 5.99;
                }
                else if (typeOfSushi == "temaki")
                {
                    price = 4.29;
                }
            }
            else if (nameOfRestaurant == "Sushi Time")
            {
                if (typeOfSushi == "sashimi")
                {
                    price = 5.49;
                }
                else if (typeOfSushi == "maki")
                {
                    price = 4.69;
                }
                else if (typeOfSushi == "uramaki")
                {
                    price = 4.49;
                }
                else if (typeOfSushi == "temaki")
                {
                    price = 5.19;
                }
            }
            else if (nameOfRestaurant == "Sushi Bar")
            {
                if (typeOfSushi == "sashimi")
                {
                    price = 5.25;
                }
                else if (typeOfSushi == "maki")
                {
                    price = 5.55;
                }
                else if (typeOfSushi == "uramaki")
                {
                    price = 6.25;
                }
                else if (typeOfSushi == "temaki")
                {
                    price = 4.75;
                }     
            }
            else if (nameOfRestaurant == "Asian Pub")
            {
                if (typeOfSushi == "sashimi")
                {
                    price = 4.50;
                }
                else if (typeOfSushi == "maki")
                {
                    price = 4.80;
                }
                else if (typeOfSushi == "uramaki")
                {
                    price = 5.50;
                }
                else if (typeOfSushi == "temaki")
                {
                    price = 5.50;
                }
            }

            double allSum = Porcii * price;
            double forHome = 0;


            
            if (nameOfRestaurant != "Sushi Zone" && nameOfRestaurant != "Sushi Time" && nameOfRestaurant != "Sushi Bar" && nameOfRestaurant != "Asian Pub")
            {
                Console.WriteLine($"{nameOfRestaurant} is invalid restaurant!");
            }
            else if (symbol == "Y")
            {
                forHome = allSum * 0.20;
                Console.WriteLine($"Total price: {Math.Ceiling(allSum + forHome)} lv.");
            }
            else if (symbol == "N")
            {
                Console.WriteLine($"Total price: {Math.Ceiling(allSum)} lv.");
            }



            //if(otbor!= "Argentina" && otbor != "Brazil" && otbor != "Croatia" && otbor != "Denmark" )

        }
    }
}
