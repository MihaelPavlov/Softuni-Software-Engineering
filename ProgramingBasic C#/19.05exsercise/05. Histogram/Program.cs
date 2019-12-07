using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int count5 = 0;
            

            for (int count = 1; count <= n; count++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 200)
                {
                    count1++;
                }
                else if (number>=200 && number <= 399)
                {
                    count2++;
                }
                else if(number>=400 && number <= 599)
                {
                    count3++;
                }
                else if(number>=600 && number <= 799)
                {
                    count4++;
                }
                else if(number >= 800)
                {
                    count5++;
                }
            }

            double percent1 = count1 * 1.0 / n * 100;//1.0 zashtoto e double int / int ne moje
            double percent2 = count2 * 1.0 / n * 100;
            double percent3 = count3 * 1.0 / n * 100;
            double percent4 = count4 * 1.0 / n * 100;
            double percent5 = count5 * 1.0 / n * 100;

            Console.WriteLine($"{percent1:F2}%");
            Console.WriteLine($"{percent2:F2}%");
            Console.WriteLine($"{percent3:F2}%");
            Console.WriteLine($"{percent4:F2}%");
            Console.WriteLine($"{percent5:F2}%");
        }
    }
}
