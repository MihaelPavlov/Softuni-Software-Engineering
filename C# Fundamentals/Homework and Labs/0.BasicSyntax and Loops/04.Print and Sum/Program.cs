using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Print_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int allSum = 0;

            for (int i = start; i <= end; i++)
            {
                allSum += i;
                Console.Write($" {i}");
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {allSum}");
           

        }
    }
}
