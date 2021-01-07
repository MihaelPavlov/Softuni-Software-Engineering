using System;
using System.Text.RegularExpressions;

namespace _03.SoftuniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"%(?<name>[A-Z][a-z]+)%(?<separator>[^|$%.]*?)<(?<product>\w+)>\k<separator>\|(?<quantity>[0-9])\|\k<separator>(?<price>[0-9]+\.?[0-9]+)\$";
            double totalIncome = 0.0;
            string input = Console.ReadLine();

            while (input!="end of shift")
            {
                Regex order = new Regex(regex);
                if (order.IsMatch(input))
                {
                    string customerName = order.Match(input).Groups["name"].Value;
                    string product = order.Match(input).Groups["product"].Value;
                    int quantity = int.Parse(order.Match(input).Groups["quantity"].Value);
                    double price = double.Parse(order.Match(input).Groups["price"].Value);

                    double money = quantity * price;
                    Console.WriteLine($"{customerName}: {product} - {money:F2}");
                    totalIncome += quantity * price;

                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
