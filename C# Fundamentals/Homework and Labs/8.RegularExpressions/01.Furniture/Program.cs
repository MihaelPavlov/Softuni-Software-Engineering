using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            //a greshno li e vmesto + da napishesh {1,}
            string pattern = @">>(?<name>[A-Za-z]{1,})<<(?<price>[0-9]{1,}\.?[0-9]{0,})!(?<quantity>[0-9]{1,})";
          //  Regex regex = new Regex(pattern);
            string input = Console.ReadLine();
            double money = 0;
            List<string> names = new List<string>();
           
            while (input != "Purchase")
            {
                var match = Regex.Matches(input, pattern);
               //Match match = regex.Match(input);
               //Succes проверявам дали има нещо което съвпада 
                foreach (Match item in match)
                {
                    var name = item.Groups["name"].Value;
                    var price = double.Parse(item.Groups["price"].Value);
                    var quantity = int.Parse(item.Groups["quantity"].Value);
                    names.Add(name);
                    money += price * quantity;
                    
                }
                


                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine($"Total money spend: {money:F2}");
            
        }
    }
}
