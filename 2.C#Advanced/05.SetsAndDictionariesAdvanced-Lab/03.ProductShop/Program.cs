using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> list = new SortedDictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input!="Revision")
            {
                string[] cmdArgs = input.Split(", ");
                string shop = cmdArgs[0];
                string product = cmdArgs[1];
                double price = double.Parse(cmdArgs[2]);

                if (!list.ContainsKey(shop))
                {
                    list.Add(shop, new Dictionary<string, double>());
                    list[shop].Add(product, price);

                }
                else if (list.ContainsKey(shop))
                {
                    list[shop].Add(product, price);
                }

                input = Console.ReadLine();
            }

            foreach (var magazine in list)
            {
                Console.WriteLine($"{magazine.Key}->");

                foreach (var product in magazine.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value:f1}");
                }
            }
        }
    }
}
