using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FanShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int budjet = int.Parse(Console.ReadLine());
            int articulCount = int.Parse(Console.ReadLine());
            int totalSum = 0;

            for (int currentArticul = 1; currentArticul <= articulCount; currentArticul++)
            {
                string articul = Console.ReadLine();

                switch (articul)
                {
                    case "hoodie":totalSum += 30; break;
                    case "keychain":totalSum += 4;break;
                    case "T-shirt":totalSum += 20;break;
                    case "flag":totalSum += 15;break;
                    case "sticker":totalSum += 1;break;
                    default:
                        totalSum++;
                        break;
                }
            }

            if (totalSum <= budjet)
            {
                Console.WriteLine($"You bought {articulCount} items and left with {budjet-totalSum} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalSum - budjet} more lv.");
            }
        }
    }
}
