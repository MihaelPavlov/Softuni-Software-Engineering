using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19._05Exsercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxPoorGrades = int.Parse(Console.ReadLine());
            int counterBadGrade = 0;
            double sumGrades = 0;
            int counterTask = 0;
            string task = Console.ReadLine();
            string lastTask = "";


            while (task != "Enough")
            {
               
                counterTask++;
                int grade = int.Parse(Console.ReadLine());
                sumGrades += grade;
                lastTask = task;
                
                if(grade <= 4)
                {
                    counterBadGrade++;
                    if (counterBadGrade == maxPoorGrades)
                    {
                        Console.WriteLine($"You need a break, {counterBadGrade} poor grades.");
                        break;
                    }
                }
                task = Console.ReadLine();
            }
            if (task == "Enough")
            {
                double averageGrades = sumGrades / counterTask;
                Console.WriteLine($"Average score: {averageGrades:f2}");
                Console.WriteLine($"Number of problems {counterTask}");
                Console.WriteLine($"Last problem: {lastTask}");
            }

        }
    }
}
