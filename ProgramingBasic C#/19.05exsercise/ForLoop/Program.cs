using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            string givemeNUmber = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            if (givemeNUmber == "Give me number")
            {
                for (int grade = 1; grade <= 12; grade++)
                {
                    Console.Write("Scream like idiot ");
                    Console.WriteLine(grade);
                    Console.Beep();
                }
            }
            int grade1 = int.Parse(Console.ReadLine());
            while (grade1 != 12)
            {
                Console.WriteLine(grade1);
                Console.Beep();
                grade1++;
            }

        }
    }
}
