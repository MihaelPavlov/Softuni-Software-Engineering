using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Exsersice__data_types
{
    class Program
    {
        static void Main(string[] args)
        {
            //    OutFall 4   $39.99
            //    CS: OG  $15.99
            //    Zplinter Zell	$19.99
            //    Honored 2   $59.99
            //    RoverWatch  $29.99
            //    RoverWatch Origins Edition  $39.99

            float money = float.Parse(Console.ReadLine());
            string command = "";
            double cashBalance = 0;
            double priceGame = 0;
            double allPriceGame = 0;

            while (command != "Game Time")
            {
               command = Console.ReadLine();

                if (command == "OutFall 4")
                {
                    priceGame = 39.99;
                    cashBalance += money;
                    cashBalance -= priceGame;

                    if (money == 0)
                    {
                        Console.WriteLine("Out of money");
                        break;
                    }
                    else if (money >= priceGame)
                    {
                        Console.WriteLine("Bought " + command);
                        allPriceGame += priceGame;
                    }
                    else if (money < priceGame)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (command== "CS: OG" )
                {
                    priceGame = 15.99;
                    
                    if (money == 0)
                    {
                        Console.WriteLine("Out of money");
                        break;
                    }
                    else if (money >= priceGame)
                    {
                        Console.WriteLine("Bought " + command);
                        cashBalance += money;
                        cashBalance -= priceGame;
                        allPriceGame += priceGame;

                    }
                    else if (money < priceGame)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else if (money == 0)
                    {
                        Console.WriteLine("Out of money!");
                        break;
                    }

                }
                else if (command == "Zplinter Zell")
                {
                    priceGame = 19.99;
                    
                   
                    if (money <= priceGame)
                    {
                        Console.WriteLine("Bought " + command);
                        cashBalance += money;
                        cashBalance -= priceGame;
                        allPriceGame += priceGame;
                    }
                    else if (money < priceGame)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                     else if (money == 0)
                    {
                        Console.WriteLine("Out of money");
                        break;
                    }
                    else if (money == 0)
                    {
                        Console.WriteLine("Out of money!");
                        break;
                    }

                }
                else if (command =="Honored 2")
                {
                    priceGame = 59.99;
                 
                    if (money == 0)
                    {
                        Console.WriteLine("Out of money");
                        break;
                    }
                    else if (money >= priceGame)
                    {
                        Console.WriteLine("Bought " + command);
                        cashBalance += money;
                        cashBalance -= priceGame;
                        allPriceGame += priceGame;
                    }
                    else if (money < priceGame)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else if (money == 0)
                    {
                        Console.WriteLine("Out of money!");
                        break;
                    }
                }
                else if (command == "RoverWatch")
                {
                    priceGame = 29.99;
                    
                    if (money == 0)
                    {
                        Console.WriteLine("Out of money");
                        break;
                    }
                    else if (money >= priceGame)
                    {
                        Console.WriteLine("Bought " + command);
                        cashBalance += money;
                        cashBalance -= priceGame;
                        allPriceGame += priceGame;
                    }
                    else if (money < priceGame)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else if (money == 0)
                    {
                        Console.WriteLine("Out of money!");
                        break;
                    }
                }
                else if (command== "RoverWatch Origins Edition")
                {
                    priceGame = 39.99;
                   
                    if (money == 0)
                    {
                        Console.WriteLine("Out of money");
                        break;
                    }
                    else if (money >= priceGame)
                    {
                        Console.WriteLine("Bought " + command);
                        cashBalance += money;
                        cashBalance -= priceGame;
                        allPriceGame += priceGame;
                    }
                    else if (money < priceGame)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else if (money == 0)
                    {
                        Console.WriteLine("Out of money!");
                        break;
                    }

                }
                else if (command == "Game Time")
                {
                    break;
                }
                else if(command != "RoverWatch Origins Edition" && command != "RoverWatch" && command != "Honored 2" && command != "Zplinter Zell" && command != "CS: OG" && command != "OutFall 4" )
                {
                    Console.WriteLine("Not Found");
                }
                
            }
            double endmoney =Math.Abs( money - allPriceGame);
            if (endmoney == 0 )
            {
                Console.WriteLine("Out of money!");
              

            }
            else
            {
                Console.WriteLine($"Total spent: ${allPriceGame:F2}. Remaining: ${money - allPriceGame:F2}");

            }

        }



    }
}
