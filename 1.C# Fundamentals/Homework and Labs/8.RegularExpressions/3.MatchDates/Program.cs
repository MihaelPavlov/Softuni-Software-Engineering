using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"(?<day>[0-9]{2})(?<separator>[\/.-])(?<mount>[A-Z][a-z]{2})\k<separator>(?<year>[0-9]{4})";
            var dates = Console.ReadLine();

             var matched = Regex.Matches(dates, regex);

            string[] matchedPhones = matched
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();
            foreach (Match date in matched)
            {
                var day = date.Groups["day"].Value;
                var mount = date.Groups["mount"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {mount}, Year: {year}");
            }

        }
    }
}
