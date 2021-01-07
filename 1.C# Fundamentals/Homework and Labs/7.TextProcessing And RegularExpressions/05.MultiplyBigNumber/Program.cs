using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string longNumber = Console.ReadLine();
            int n2 = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            int temp = 0;

            foreach (char item in longNumber.Reverse())
            {
                int digit = int.Parse(item.ToString());
                int end = digit * n2+ temp;
                int resDigit = end % 10;
               
                sb.Insert(0,resDigit);
                temp = end / 10;
            }
            if (temp >0)
            {
                sb.Insert(0, temp);
            }
            string result = sb.ToString().TrimStart('0');
            if (result.Length==0)
            {
                result = "0";
            }
            
            Console.WriteLine(result);
        }
    }
}
