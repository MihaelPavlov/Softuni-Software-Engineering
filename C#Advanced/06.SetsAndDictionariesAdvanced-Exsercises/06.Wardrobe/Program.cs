using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());

                    for (int j = 1; j < input.Length; j++)
                    {
                        string cloth = input[j];
                        if (!wardrobe[color].ContainsKey(cloth))
                        {
                            wardrobe[color].Add(cloth, 0);
                        }
                        wardrobe[color][cloth]++;

                    }
                }
                else if (wardrobe.ContainsKey(color))
                {
                    for (int j = 1; j < input.Length; j++)
                    {
                        string cloth = input[j];
                        if (!wardrobe[color].ContainsKey(cloth))
                        {
                            wardrobe[color].Add(cloth, 0);
                        }
                        wardrobe[color][cloth]++;

                    }
                }
              
            }
            string[] whatIwant = Console.ReadLine().Split();
            string colorWant = whatIwant[0];
            string dress = whatIwant[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var items in color.Value)
                {
                    if (color.Key == colorWant && items.Key== dress)
                    {
                        Console.WriteLine($"* {items.Key} - {items.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {items.Key} - {items.Value}");

                    }
                }
            }


        }
    }
}
