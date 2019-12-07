using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {

            int capacityRoom = int.Parse(Console.ReadLine());

            int peopleGoInCount = 0;
            int coming = 0;
            int setsLeft = 0;
            int price = 0;
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Movie time!")
            {
                coming = int.Parse(command);

               
                peopleGoInCount = peopleGoInCount + coming;
                setsLeft = setsLeft + coming;


                if (coming % 3 == 0)
                {
                    price = price - 5;
                }
                price = price + (coming * 5);

                if (command == "Movie time!")
                {
                    Console.WriteLine($"There are {capacityRoom - setsLeft} seats left in the cinema.");
                    Console.WriteLine($"Cinema income - {price} lv.");
                    break;
                }
                else if (capacityRoom < coming)
                {
                    Console.WriteLine($"The cinema is full.");
                    Console.WriteLine($"Cinema income - {price} lv.");
                    break;
                }

            }


        }
    }
}
