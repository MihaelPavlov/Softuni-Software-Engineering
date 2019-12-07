using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lekcii
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int oddSum = 0;
            int evenSum = 0;

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (i % 2 == 0) //chislo na chetna poziciq
                {
                    evenSum += currentNumber;
                }
                else
                {
                    oddSum += currentNumber;
                }
            }

            if(evenSum == oddSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {evenSum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(oddSum-evenSum)}");
            }


            
        }
    }
}
