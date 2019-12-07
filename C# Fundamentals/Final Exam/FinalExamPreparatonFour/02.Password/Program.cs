using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _02.Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string patter = @"(?<start>[\S]+)>(?<firstGr>[0-9]{3})\|(?<secondGr>[a-z]{3})\|(?<thirdGr>[A-Z]{3})\|(?<fourGr>[^<>]+)<\k<start>";
            Regex regex = new Regex(patter);
            int n = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (regex.IsMatch(input))
                {
                    StringBuilder validPassword = new StringBuilder();
                    string numbers =regex.Match(input).Groups["firstGr"].Value;
                    string lower =regex.Match(input).Groups["secondGr"].Value;
                    string upper =regex.Match(input).Groups["thirdGr"].Value;
                    string chars =regex.Match(input).Groups["fourGr"].Value;

                    validPassword.Append(numbers);
                    validPassword.Append(lower);
                    validPassword.Append(upper);
                    validPassword.Append(chars);
                    Console.WriteLine($"Password: {validPassword}");


                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
