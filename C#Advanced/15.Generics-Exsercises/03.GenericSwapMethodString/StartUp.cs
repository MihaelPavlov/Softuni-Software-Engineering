using System;
using System.Linq;

namespace _03.GenericSwapMethodString
{
     public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();


            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                box.Values.Add(input);
            }
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int a = numbers[0];
            int b = numbers[1];
            box.Swap(a, b);
            Console.WriteLine(box);
        }
    }
}
