using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumLeft = 0;
            int sumRight = 0;

            int countOfNumbers = n * 2;
            for (int i = 0; i < countOfNumbers; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (i<n)
                {
                    sumLeft += currentNumber;
                }
                else
                {
                    sumRight += currentNumber;
                }


                    //Console.WriteLine("Yes, sum =" +sum);
                   
                   //Console.WriteLine("No, diff ="+Math.Abs(number - number2));   
            }
            if (sumRight == sumLeft)
            {
                Console.WriteLine($"Yes, sum = {sumRight}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(sumLeft - sumRight)}");
            }
           ;
        }
    }
}
