using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.BonusSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            int countOfLectures = int.Parse(Console.ReadLine());
            int initialBonus = int.Parse(Console.ReadLine());

            Dictionary<double, double> students = new Dictionary<double, double>();
           
            for (int i = 0; i < countOfStudents; i++)
            {
                double readStudent = double.Parse(Console.ReadLine());

                double totalBonus = (readStudent / countOfLectures * (5.0 + initialBonus));

                students.Add(readStudent, totalBonus);
                
            }
            double biggerValue = Math.Ceiling(0.0);
            double valueName = 0;
            foreach (var student in students)
            {

                if (student.Value > biggerValue)
                {
                    biggerValue = student.Value;
                    valueName = student.Key;
                }



            }
            Console.WriteLine($"The maximum bonus score for this course is {biggerValue}.The student has attended {valueName} lectures.");

        }
    }
}
