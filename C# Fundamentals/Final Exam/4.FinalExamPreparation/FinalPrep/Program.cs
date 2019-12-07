using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace FinalPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            string patter = @"@(?<name>[A-Z]{1}[a-z]+)(?<trash>[^@\-!:>]+)!(?<goodBad>[A-Z]{1})!";
            Regex regex = new Regex(patter);
            while (input!="end")
            {
                StringBuilder decode = new StringBuilder();

                for (int j = 0; j < input.Length; j++)
                {
                    char symbol = input[j];


                    decode.Append((char)(symbol - n));
                }

                if (regex.IsMatch(decode.ToString()))
                {
                    string name = regex.Match(decode.ToString()).Groups["name"].Value;
                    string goodBad = regex.Match(decode.ToString()).Groups["goodBad"].Value;
                    if (goodBad == "G")
                    {
                        Console.WriteLine($"{name}");
                    }

                }

                input = Console.ReadLine();
            }
                
            
        }
    }

}
