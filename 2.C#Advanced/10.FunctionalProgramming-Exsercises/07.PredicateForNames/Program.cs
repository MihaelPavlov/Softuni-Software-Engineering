using System;
using System.Linq;
using System.Collections.Generic;


namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Func<List<string>,  List<string>> func = x =>
             {
                 List<string> shorterNames = new List<string>();
                 foreach (var item in names)
                 {
                     if (item.Length <= n )
                     {
                         shorterNames.Add(item);
                         Console.WriteLine(item);
                     }
                 }
                 return shorterNames;
             };

            func(names);
        } 

         static void ShorterNames( int n, string[] names)
        {
            
            foreach (var item in names)
            {

            }
        }
    }
}
