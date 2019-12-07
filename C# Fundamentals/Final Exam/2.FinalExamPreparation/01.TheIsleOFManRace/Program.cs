using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;


namespace _01.TheIsleOFManRace
{
    class Program
    {
        static void Main(string[] args)
        {
            string patter = @"(?<split>[#$%&*])(?<name>[A-z]+)\k<split>=(?<numbers>[0-9]+)!!(?<code>.+)";
          


            string input = Console.ReadLine();

            while (true)
            {
                Regex regex = new Regex(patter);

                if (regex.IsMatch(input))
                {
                    string name = regex.Match(input).Groups["name"].Value;
                    int number = int.Parse(regex.Match(input).Groups["numbers"].Value);
                    string code = regex.Match(input).Groups["code"].Value;
                    StringBuilder newCode = new StringBuilder();
                    if (code.Length == number)
                    {
                       
                        for (int i = 0; i < code.Length; i++)
                        {
                            char symbol = (char)(code[i]+number);
                            
                            
                            newCode.Append(symbol.ToString());
                        }
                        Console.WriteLine($"Coordinates found! {name} -> {newCode}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }               
                else
                {
                    Console.WriteLine("Nothing found!");
                }
                input = Console.ReadLine();
            }
        }
    }
}
