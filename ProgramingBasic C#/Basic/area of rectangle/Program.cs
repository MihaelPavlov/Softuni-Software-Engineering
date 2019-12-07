using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace area_of_rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double area =Math.Abs( x1 - x2);
            double perimetar =Math.Abs( y1 - y2);

            double area1 = area * perimetar;
            double perimetar2 = 2 * (area + perimetar);

            Console.WriteLine($"{area1:f2}");
            Console.WriteLine($"{perimetar2:F2}");


        }
    }
}
