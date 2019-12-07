using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Exsercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string patter = @"[A-Z]*[a-z]*(?<tag>[*@])(?<name>[A-Z]{1}[a-z]{2,})(?<tag0>[*@]): \[(?<tag1>[a-z]*[A-Z]*)\]\|\[(?<tag2>[a-z]*[A-Z]*)\]\|\[(?<tag3>[a-z]*[A-Z]*)\]\|$";

            Regex regex = new Regex(patter);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string tag = regex.Match(input).Groups["tag"].Value;   
                string tag0 = regex.Match(input).Groups["tag0"].Value;

                if (regex.IsMatch(input))
                {
                    if (tag == tag0)
                    {
                        string name = regex.Match(input).Groups["name"].Value;
                        char tag1 = char.Parse(regex.Match(input).Groups["tag1"].Value);
                        char tag2 = char.Parse(regex.Match(input).Groups["tag2"].Value);
                        char tag3 = char.Parse(regex.Match(input).Groups["tag3"].Value);

                        int symbol = tag1;
                        int symbol1 = tag2;
                        int symbol2 = tag3;
                        Console.WriteLine($"{name}: {symbol} {symbol1} {symbol2}");

                    }
                    else
                    {
                        Console.WriteLine("Valid message not found!");
                    }
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }

            }
        }
    }
}
