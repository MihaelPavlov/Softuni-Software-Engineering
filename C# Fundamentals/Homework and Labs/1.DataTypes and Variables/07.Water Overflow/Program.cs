using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            //имаме воден танк 255 литра
            // на следващите редува получа литри които се добавят към танка
            //ако не е пълно изпринти Insufficient capacity
            //и продължи да четеш
            //на последния ред изпринти литрите в танка

            int number = int.Parse(Console.ReadLine());
            double counterOfLitr = 0;

            for (int i = 1; i <= number; i++)
            {
                double maxCapacity = int.Parse(Console.ReadLine());
                counterOfLitr += maxCapacity;
                if (counterOfLitr > 255)
                {
                    counterOfLitr = counterOfLitr - maxCapacity;
                    Console.WriteLine("Insufficient capacity!");
                }
                
            }
            Console.WriteLine(counterOfLitr);

        }
    }
}
