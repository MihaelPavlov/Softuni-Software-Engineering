using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentList = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                string name = input[0];
                double grade = double.Parse(input[1]);

                if (!studentList.ContainsKey(name))
                {
                    studentList.Add(name, new List<double>());
                    studentList[name].Add(grade);
                }
                else if (studentList.ContainsKey(name))
                {
                    studentList[name].Add(grade);
                }
                
            }
            
            foreach (var student in studentList)
            {
                Console.Write($"{student.Key} ->");
                foreach (var grades in student.Value)
                {
                    Console.Write($" {grades:F2}");
                }
                Console.Write($" (avg: {student.Value.Average():F2})");
                Console.WriteLine();
              
                    
                  
               
            }
        }
    }
}
