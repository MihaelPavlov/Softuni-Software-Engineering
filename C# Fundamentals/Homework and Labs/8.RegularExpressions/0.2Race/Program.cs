using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace _0._2Race
{
    class Program
    {
        static void Main(string[] args)
        {
            // как да взимам само числата без да закачам другите знаци след първата буква
            string namePatter = "[a - zA - z]";
            string digitPatter = "\\d";
            Regex nameRegex = new Regex(namePatter);
            Regex digitRegex = new Regex(digitPatter);
            string[] participants = Regex.Split(Console.ReadLine(), ",\\s+");
            string input = Console.ReadLine();

            while (input!="end of race")
            {
                MatchCollection charsCollection = nameRegex.Matches(input);
                string name = string.Join("", charsCollection);

                if (participants.Contains(name))
                {
                    MatchCollection digitsCollection = digitRegex.Matches(input);
                    int distance = 0;
                    foreach (Match  match in digitsCollection)
                    {
                        int digit = int.Parse(match.Value );
                        distance += digit;
                    }
                }
                
                //string name = string.Empty;

                //foreach (Match match in charsCollection)
                //{
                //    name += match.Value;
                //}
                input = Console.ReadLine();


            }

               
        }
    }
}
