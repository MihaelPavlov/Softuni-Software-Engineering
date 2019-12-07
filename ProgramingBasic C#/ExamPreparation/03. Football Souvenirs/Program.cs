using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Football_Souvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string otbor = Console.ReadLine();
            string typeSouvenier = Console.ReadLine();
            int boughtSouvenier = int.Parse(Console.ReadLine());
            double price = 0;

            
            if (otbor == "Argentina" )
            {
                if (typeSouvenier == "flags")
                {
                    price = 3.25;
                }
                else if (typeSouvenier == "caps")
                {
                    price = 7.20;
                }
                else if (typeSouvenier == "posters")
                {
                    price = 5.10;
                }
                else if (typeSouvenier == "stickers")
                {
                    price = 1.25;
                }
               
            }

            else if (otbor == "Brazil")
            {
                if (typeSouvenier == "flags")
                {
                    price = 4.20;
                }
                else if (typeSouvenier == "caps")
                {
                    price = 8.50;
                }
                else if (typeSouvenier == "posters")
                {
                    price = 5.35;
                }
                else if (typeSouvenier == "stickers")
                {
                    price = 1.20;
                }
              
            }
            else if (otbor == "Croatia")
            {
                if (typeSouvenier == "flags")
                {
                    price = 2.75;
                }
                else if (typeSouvenier == "caps")
                {
                    price = 6.90;
                }
                else if (typeSouvenier == "posters")
                {
                    price = 4.95;
                }
                else if (typeSouvenier == "stickers")
                {
                    price = 1.10;
                }
            }
            else if (otbor == "Denmark")
            {
                if (typeSouvenier == "flags")
                {
                    price = 3.10;
                }
                else if (typeSouvenier == "caps")
                {
                    price = 6.50;
                }
                else if (typeSouvenier == "posters")
                {
                    price = 4.80;
                }
                else if (typeSouvenier == "stickers")
                {
                    price = 0.90;
                }
                

            }
           if(otbor!= "Argentina" && otbor != "Brazil" && otbor != "Croatia" && otbor != "Denmark" )
            {
                Console.WriteLine("Invalid country!");
            }
           else if (typeSouvenier != "flags" && typeSouvenier != "caps" && typeSouvenier != "posters"&& typeSouvenier != "stickers"  )
            {
                Console.WriteLine("Invalid stock!");
            }
           else
            {
                Console.WriteLine($"Pepi bought {boughtSouvenier} {typeSouvenier} of {otbor} for {(price * boughtSouvenier):F2} lv.");
            }
            
               
            
            


        }
    }
}
