using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            double wedth = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double averageHeightOfAstronaust = double.Parse(Console.ReadLine());

            double capacityOfRocket = wedth * height * lenght;
            double capacityOneRoom = (averageHeightOfAstronaust + 0.40) * 2 * 2;

            double havePlaceFor =Math.Floor(capacityOfRocket / capacityOneRoom);

            if(havePlaceFor>=3 && havePlaceFor <= 10)
            {
                Console.WriteLine($"The spacecraft holds {havePlaceFor} astronauts.");
            }
            else if (havePlaceFor < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if (havePlaceFor > 10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }



        }
    }
}
