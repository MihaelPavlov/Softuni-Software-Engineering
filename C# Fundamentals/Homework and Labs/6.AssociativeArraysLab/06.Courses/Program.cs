using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)                                                                                                          
        {
            Dictionary<string, List<string>> info = new Dictionary<string, List<string>>();
            List<string> studentNames = new List<string>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input.Split(" : ");
                string courseName = tokens[0];
                string nameStudent = tokens[1];

                if (!info.ContainsKey(courseName))
                {
                    info.Add(courseName,studentNames);
                    studentNames.Add(nameStudent);
                    studentNames = new List<string>();
                }
                else
                {

                    info[courseName].Add(nameStudent);
                    //MY WAY
                  // info[courseName] += Environment.NewLine+($"-- {nameStudent}");
                    
                }

                input = Console.ReadLine();
            
          
            }
            foreach (var course in info.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}"); // here i get the count of the list 
                foreach (var item in course.Value.OrderBy(x=>x)) // here i get only the value of the front foreach 
                {
                    Console.WriteLine($"-- {item}");
                }
            }
           
          

                
        }
    }
}
