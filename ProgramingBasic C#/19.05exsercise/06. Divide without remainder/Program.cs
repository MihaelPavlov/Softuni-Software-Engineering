using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Divide_without_remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int countp1 = 0;
            int countp2 = 0;
            int countp3 = 0;

            for (int count = 1; count <= n; count++)
            {
                int number = int.Parse(Console.ReadLine());

                if(number % 2 == 0 )//процентно делене без остатък на 2
                {
                    countp1++;
                }
                if (number % 3 == 0)
                {   
                    countp2++;
                }
                if(number % 4 == 0)
                { 
                    countp3++;
                }
            }

            double percent1 = countp1 * 1.00 /n * 100;
            double percent2 = countp2 * 1.00 / n * 100;
            double percent3 = countp3 * 1.00 / n * 100;
        
             
            Console.WriteLine($"{percent1:F2}%");
            Console.WriteLine($"{percent2:F2}%");
            Console.WriteLine($"{percent3:F2}%");
        }
    }
}
