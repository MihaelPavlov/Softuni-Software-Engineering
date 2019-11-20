using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int originNumber= int.Parse(Console.ReadLine());
            int number = originNumber;
            int sum = 0;

            while (number>0)
            {
                int lastDigit = number % 10;
                number /= 10;

                int currentFactorial = 1;

                for (int i = 2; i <= lastDigit; i++)
                {
                    currentFactorial *= i;
                }

                sum += currentFactorial;
            }
            bool issStrong = originNumber == sum;

            if (issStrong)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
