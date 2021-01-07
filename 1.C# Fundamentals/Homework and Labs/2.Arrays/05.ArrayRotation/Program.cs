using System;
using System.Linq;

namespace _05.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] days = new string[6];
            days[0] = "Monday";

            int day = int.Parse(Console.ReadLine());

            if (day == 1)
            {
                Console.WriteLine(days[0]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
