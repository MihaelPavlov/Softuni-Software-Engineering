using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> academy = new Dictionary<string, List<double>>();
            List<double> grades = new List<double>();

            int n = int.Parse(Console.ReadLine());

            

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!academy.ContainsKey(name))
                {
                    academy.Add(name, grades);
                    grades.Add(grade);
                    grades = new List<double>();

                }
                else
                {
                    academy[name].Add(grade);
                }

            }
            Dictionary<string, double> endScore = new Dictionary<string, double>();
            
                foreach (var item in academy.OrderByDescending(x=>x.Value.Average()))
                {
                    if (item.Value.Average() >= 4.5) 
                    {
                    Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
                    }
                }
               
            
            
            
        }
    }
}
