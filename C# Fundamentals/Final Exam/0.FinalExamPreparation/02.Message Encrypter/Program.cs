using System;
using System.Text.RegularExpressions;

namespace _02.Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[A-Z]*[a-z]*(?<tag1>[@*])(?<name>[A-Z][a-z]{2,})(?<tag2>[@*])";
            string pattern2 = @": (?<tagName>\[(?<nL>[a-z]*[A-Z]*[0-9]*)\]\|\[(?<nL1>[a-z]*[A-Z]*)\]\|\[(?<nL2>[a-z]*[A-Z]*[0-9]*)\]\|)$";
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Regex regex = new Regex(pattern);
                Regex regex2 = new Regex(pattern2);


                var name = regex.Match(input).Groups["name"].Value;
                var tag1 = regex.Match(input).Groups["tag1"].Value;
                var tag2 = regex.Match(input).Groups["tag2"].Value;

                if (regex.IsMatch(input))
                {
                    if (tag1==tag2)
                    {
                        var tagName = regex2.Match(input).Groups["nL"].Value;
                        var tagName1 = regex2.Match(input).Groups["nL1"].Value;
                        var tagName2 = regex2.Match(input).Groups["nL2"].Value;
                        if (regex2.IsMatch(input))
                        {
                            int symbol = char.Parse(tagName);
                            int symbol1 = char.Parse(tagName1);
                            int symbol2 = char.Parse(tagName2);

                            Console.Write(name);
                            Console.WriteLine($": {symbol} {symbol1} {symbol2}");
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
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
