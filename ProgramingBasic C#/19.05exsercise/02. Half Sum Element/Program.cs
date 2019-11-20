using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;// ako imash vupros kak da nameri nai golqmoto chislo.
            //
            int totalSum = 0;

            for (int count = 1;count <= n; count++)//koe chislo podred az vuvejdam 
            {
                int number = int.Parse(Console.ReadLine());
                totalSum += number;//trupame chislata number v totalSum

                if (number>max)
                {
                    max = number;// zapazvame max chisloto v max
                }
            }
            int sumOthers = totalSum - max;//sumata na vsi4ki ostanali
            if (max == sumOthers)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = {0}",max);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = {0}",Math.Abs(max-sumOthers));
            }
        }
    }
}
