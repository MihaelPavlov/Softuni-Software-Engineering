using System;

namespace _05.GenericCountMethodStrings
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
            string targetItem = Console.ReadLine();
            int target = box.GreaterValuesThan(targetItem);
            Console.WriteLine(target);
        }
    }
}
