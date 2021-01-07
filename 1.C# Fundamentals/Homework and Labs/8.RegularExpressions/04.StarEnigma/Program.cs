using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {//@(?<name>[A-Z][a-z]+)[0-9]*[@\-!:>]+(?<population>[0-9]+)!(?<attackType>[AD])![@\-!:>]+(\d+)
            //@(?<name>[A-Z][a-z]+)[^@\-!:>]*?:(?<population>\d+)[^@\-!:>]*?!(?<attackType>[AD])![^@\-!:>]*?->(?<soldierCount>\d+)
            string patter = @"(?<count>[s,t,a,r,S,T,A,R])";
            string patterPlanetInfo = @"@(?<name>[A-Z][a-z]+)[^@\-!:>]*?:(?<population>\d+)[^@\-!:>]*?!(?<attackType>[AD])![^@\-!:>]*?->(?<soldierCount>\d+)";
            int n = int.Parse(Console.ReadLine());
            StringBuilder decryptMessage = new StringBuilder();
            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            Regex patter1 = new Regex(patter);//1

            

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var match = patter1.Matches(input);
                var count = match.Count;
                             
                for (int j = 0; j < input.Length; j++)
                {
                    char newChar = input[j];
                    decryptMessage.Append((char)(newChar - count));
                    
                }
                Regex regex = new Regex(patterPlanetInfo);//2

                if (regex.IsMatch(decryptMessage.ToString()))
                {
                    string name = regex.Match(decryptMessage.ToString()).Groups["name"].Value;
                    string attackType = regex.Match(decryptMessage.ToString()).Groups["attackType"].Value;
                    if (attackType =="A")
                    {
                      
                        attacked.Add(name);
                    }
                    else if (attackType == "D")
                    {
                        destroyed.Add(name);

                    }
                   
                    
                }
      
                decryptMessage = new StringBuilder();


            }
            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (var item in attacked.OrderBy(item=>item))
            {
                Console.WriteLine($"-> {item}");
            }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (var item in destroyed.OrderBy(item=>item))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
