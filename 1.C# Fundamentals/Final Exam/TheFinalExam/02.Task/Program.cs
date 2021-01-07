using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string patter = @"U\$(?<username>[A-Z]{1}[a-z]{2,})U\$P@\$(?<password>[a-z]{5,}[0-9]+)P@\$";
            Regex regex = new Regex(patter);

            int n = int.Parse(Console.ReadLine());
            int countOfAcounts = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (regex.IsMatch(input))
                {
                    string username = regex.Match(input).Groups["username"].Value;
                    string password = regex.Match(input).Groups["password"].Value;
                    countOfAcounts++;
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {username}, Password: {password}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {countOfAcounts}");



        }
    }
}
