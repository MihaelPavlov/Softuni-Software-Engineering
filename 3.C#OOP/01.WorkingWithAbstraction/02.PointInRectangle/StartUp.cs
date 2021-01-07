using System;
using System.Linq;

namespace _02.PointInRectangle
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var rectangle = new Rectangle(input[0], input[1], input[2], input[3]);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] number = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                Point point = new Point(number[0], number[1]);

                Console.WriteLine(rectangle.Contains(point));
            }

        }
    }
}
