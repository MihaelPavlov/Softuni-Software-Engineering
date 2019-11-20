using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            double budjet = double.Parse(Console.ReadLine());
            int numberOfSerial =int.Parse(Console.ReadLine());

            double price = 0;
            double priceCount2 = 0;
            

            for (int i = 1; i <= numberOfSerial; i++)
            {
                string nameOfSerial = Console.ReadLine();
                double priceForSerial = double.Parse(Console.ReadLine());

                if(nameOfSerial == "Thrones")
                {
                    price = price +(priceForSerial * 0.50);
                    
                }
                else if(nameOfSerial == "Lucifer")
                {
                    price = price + (priceForSerial * 0.40);
                    
                }
                else if (nameOfSerial == "Protector")
                {
                    price = price +( priceForSerial * 0.30);
                }
                else if (nameOfSerial == "TotalDrama")
                {
                    price = price + (priceForSerial * 0.20);
                    
                }
                else if (nameOfSerial == "Area")
                {
                    price = price +( priceForSerial * 0.10);
                }

                priceCount2 = priceForSerial + priceCount2;
                
                
            }
            double priceForSerial2 = priceCount2 - price;
            double leftPrice =Math.Abs (budjet - (priceCount2 - price));
            
            if (budjet >= priceForSerial2)
            {
                Console.WriteLine($"You bought all the series and left with {leftPrice:f2} lv.");

            }
            else if (budjet < priceForSerial2)
            {
                Console.WriteLine($"You need {leftPrice:f2} lv. more to buy the series!");
            }
                

        }
    }
}
