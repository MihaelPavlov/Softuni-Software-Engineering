using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.MatchPhoneNumber
{
    class Program
    {


        static void Main(string[] args)
        {
            var regex = @"(\+359([ -])2(\2)(\d{3})(\2)(\d{4}))\b";
            var number = Console.ReadLine();

            var matched= Regex.Matches(number, regex);

            string[] matchedPhones = matched
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

               Console.WriteLine(string.Join(", ", matchedPhones));

            
                
            
            
        }
    }
}
