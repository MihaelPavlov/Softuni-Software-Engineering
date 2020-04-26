using System;

namespace _01.Working_with_abstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string symbol = "*";
            int index = 0;
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < index; j++)
                {
                    Console.Write(symbol);
                }
                index++;
                Console.WriteLine();
               
            }
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0 - 1; j >= index; j--)
                {
                    Console.Write(symbol);
                }
                index--;
                Console.WriteLine();
            }
        }
    }
}
