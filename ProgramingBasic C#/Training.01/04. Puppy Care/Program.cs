using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Puppy_Care
{
    class Program
    {
        static void Main(string[] args)
        {
            int buyFoodKg = int.Parse(Console.ReadLine());
            int buyFoodGrm = buyFoodKg * 1000;
            int foodEnough = 0;
            string command = string.Empty;
            

            while (true)
            {
                string giveTheDog = Console.ReadLine();


                if (giveTheDog == "Adopted")
                {
                    break;
                }

                foodEnough += int.Parse(giveTheDog);

            }
            if (foodEnough <= buyFoodGrm)
            {
                Console.WriteLine($"Food is enough! Leftovers: {buyFoodGrm - foodEnough} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {foodEnough - buyFoodGrm} grams more.");
            }




        }
    }
}
