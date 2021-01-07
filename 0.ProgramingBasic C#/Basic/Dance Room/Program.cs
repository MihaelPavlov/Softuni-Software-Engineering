using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double wardrobeArea = double.Parse(Console.ReadLine());

            double areaOfTheRoom = (lenght * 100) * (width * 100);
            double wardrobe = (wardrobeArea * 100) * (wardrobeArea * 100);
            double bench = areaOfTheRoom / 10;
            double freeSpace = areaOfTheRoom - wardrobe - bench;
            double dancers = Math.Floor(freeSpace / (40 + 7000));

            Console.WriteLine(dancers);


        }
    }
}
