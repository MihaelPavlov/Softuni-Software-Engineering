using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfStudents = Console.ReadLine();
            double counter = 0;
            double allGrades = 0.0;
            double expelCounts = 0;
                    
            while(counter < 12)
            {
                double grades = double.Parse(Console.ReadLine());

                if(grades >= 4.00)
                {
                    allGrades += grades;
                    counter++;
                }
                else
                {
                    expelCounts++;
                }
                
                if(expelCounts == 2)
                {
                    Console.WriteLine($"{nameOfStudents} has been excluded at {counter + expelCounts -1} grade");
                    grades++;
                    return;
                }
            }
            double sum = allGrades / 12;
            Console.WriteLine($"{nameOfStudents} graduated. Average grade: {sum:F2}");
         }
    }
}
