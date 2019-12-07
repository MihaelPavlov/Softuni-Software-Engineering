using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _12.SoftuniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d)\|[^|$%.]*?(?<price>[0-9]+\.?[0-9]+)\$";

            double totalIncome = 0.0;
            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                Regex order = new Regex(pattern);

                if (order.IsMatch(input))
                {
                    string customerName = order.Match(input).Groups["customer"].Value;
                    string productName = order.Match(input).Groups["product"].Value;
                    int count = int.Parse(order.Match(input).Groups["count"].Value);
                    double price = double.Parse(order.Match(input).Groups["price"].Value);

                    double totalPrice = price * count;
                    totalIncome += totalPrice;

                    Console.WriteLine($"{customerName}: {productName} - {totalPrice:f2}");
                }





                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalIncome:F2}");

        }
    }
}
