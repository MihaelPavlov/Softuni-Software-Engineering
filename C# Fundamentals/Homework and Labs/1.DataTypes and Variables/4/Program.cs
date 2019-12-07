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
            int n = int.Parse(Console.ReadLine());
            int sumDigit = 0;

            for (int i = 1; i <= n; i++)
            {
                
                char latin = Console.ReadLine()[0];
                Console.Write((int)latin);

                sumDigit += latin;

            }
            Console.WriteLine("The sum equals: " + sumDigit);
        }
    }
}
