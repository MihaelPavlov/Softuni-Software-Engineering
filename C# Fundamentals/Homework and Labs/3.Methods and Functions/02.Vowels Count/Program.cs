using System;
using System.Linq;

namespace Methods___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            PrintingVowels(firstChar, secondChar);
        }

        static void PrintingVowels(int a , int b)
        {
            if (a<b)
            {
                for (int i = a + 1; i < b; i++)
                {
                    Console.Write((char)i + " ");

                }
            }
            else
            {
                for (int i = b + 1; i < a; i++)
                {
                    Console.Write((char)i + " ");

                }
            }
            
            











        }
    }
}
