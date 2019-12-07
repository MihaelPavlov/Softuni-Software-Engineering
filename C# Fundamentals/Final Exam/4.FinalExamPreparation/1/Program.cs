using System;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountBatches = int.Parse(Console.ReadLine());
            int end = 0;

            for (int i = 0; i < amountBatches; i++)
            {
                int flour = int.Parse(Console.ReadLine());
                int sugar = int.Parse(Console.ReadLine());
                int cocoa = int.Parse(Console.ReadLine());

                int flourCups = flour / 140;
                int sugarSpoons = sugar / 20;
                int cocoaSpoons = cocoa / 10;
                
                
                int total = Math.Min(flourCups, sugarSpoons);
                if (flourCups == 0 || sugarSpoons == 0 || cocoaSpoons == 0)
                {
                    Console.WriteLine($"Boxes of cookies: {end}");
                    Console.WriteLine("Ingredients are not enough for a box of cookies.");
                    Console.WriteLine($"Total boxes: {end}");
                    break;
                }
                else
                {
                    int result = Math.Min(total, cocoaSpoons);
                    int endResult = (140 + 10 + 20) * result / 25;
                    end += endResult / 5;
                    Console.WriteLine($"Boxes of cookies: {end}");
                }
                
                
            }
            Console.WriteLine($"Total boxes: {end}");
        }
    }
}
