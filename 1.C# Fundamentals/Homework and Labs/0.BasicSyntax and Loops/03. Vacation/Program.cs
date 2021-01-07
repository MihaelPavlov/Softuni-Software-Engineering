using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string typePeople = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;

            if (typePeople == "Students")
            {
                if (people>= 30)
                {
                    
                    if (day == "Friday")
                    {
                        price = 8.45;
                    }
                    else if (day == "Saturday")
                    {
                        price = 9.80;
                    }
                    else if (day == "Sunday")
                    {
                        price = 10.46;

                    }
                    price = price - 0.15 * price;
                }
                else
                {
                    if (day == "Friday")
                    {
                        price = 8.45;
                    }
                    else if (day == "Saturday")
                    {
                        price = 9.80;
                    }
                    else if (day == "Sunday")
                    {
                        price = 10.46;

                    }
                }
            }
            else if (typePeople == "Business")
            {
                if (day == "Friday")
                {
                    price = 10.90;
                    if (people>= 100)
                    {
                        price = (people - 10) * 10.90;
                    }
                }
                else if (day == "Saturday")
                {
                    price = 15.60;
                    if (people >= 100)
                    {
                        price = (people - 10) * 15.60;
                    }
                }
                else if (day == "Sunday")
                {
                    price = 16;
                    if (people >= 100)
                    {
                        price = (people - 10) * 16;
                    }
                }
                else
                {
                    if (day == "Friday")
                    {
                        price = 10.90;
                        if (people >= 100)
                        {
                            price = (people - 10) * 10.90;
                        }
                    }
                    else if (day == "Saturday")
                    {
                        price = 15.60;
                        
                    }
                    else if (day == "Sunday")
                    {
                        price = 16;
                    }
                }
            }
            else if (typePeople == "Regular")
            {
                if (people >= 10 && people <= 20)
                {
                   
                    if (day == "Friday")
                    {
                        price = 15;
                    }
                    else if (day == "Saturday")
                    {
                        price = 20;
                    }
                    else if (day == "Sunday")
                    {
                        price = 22.50;
                    }
                    price = price - 0.5 * price;
                }
                else
                {
                    if (day == "Friday")
                    {
                        price = 15;
                    }
                    else if (day == "Saturday")
                    {
                        price = 20;
                    }
                    else if (day == "Sunday")
                    {
                        price = 22.50;
                    }
                }
                
            }

                  
            

            double endPrice = people * price;

            Console.WriteLine($"Total price: {endPrice:F2}");
                
                    
                    
            
        }
    }
}
