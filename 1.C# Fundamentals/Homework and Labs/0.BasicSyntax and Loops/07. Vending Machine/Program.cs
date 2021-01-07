using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string money = Console.ReadLine();

            double sum = 0;
            double sum2 = 0;


            while (money != "Start")
            {
                sum = double.Parse(money);

                if (sum == 0.1 || sum == 0.2 || sum == 0.5 || sum== 1 ||sum == 2 )
                {
                    sum2 += sum;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {sum}");
                }
                money = Console.ReadLine();
            }

            string nameProduct = Console.ReadLine();
            
            while (nameProduct != "End")
            {
                if (nameProduct == "Nuts")
                {
                    if (sum2 - 2.0 < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine($"Purchased nuts");
                        sum2 = sum2 - 2.0;
                    }
                }
                else if (nameProduct == "Water")
                {
                    if (sum2 - 0.7 < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine("Purchased water");
                        sum2 = sum2 - 0.7;
                    }
                }
                else if (nameProduct == "Coke")
                {
                    if (sum2 - 1.0 < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine("Purchased coke");
                        sum2 = sum2 - 1.0;
                    }
                }
                else if (nameProduct == "Crisps")
                {
                    if (sum2 - 1.5 < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine("Purchased crisps");
                        sum2 = sum2 - 1.5;                
                    }                
                }
                else if (nameProduct == "Soda")
                {
                    if (sum2 - 0.8 < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine("Purchased soda");
                        sum2 = sum2 - 0.8;
                    }
                }
                
                else
                {
                    Console.WriteLine("Invalid product");
                }
                nameProduct = Console.ReadLine();

                
            }
            Console.WriteLine($"Change: {sum2:F2}");

        }
    }
}
