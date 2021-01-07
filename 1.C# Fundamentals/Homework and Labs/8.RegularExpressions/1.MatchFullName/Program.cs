using System;
using System.Text.RegularExpressions;

namespace _1.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            string names = Console.ReadLine();

            MatchCollection matched = Regex.Matches(names, regex);

            foreach (Match item in matched)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine();
        }
    }
}
