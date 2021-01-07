using System;
using System.Linq;

namespace Methods___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string enter = Console.ReadLine();

            
            
        }

        static void PrintingVowels(string name)
        {
            int count = 0;

            for (int i = 0; i < name.Length; i++)
            {
                if (name.Contains("a")|| name.Contains("e")||name.Contains("i")||name.Contains("o")||name.Contains("u"))
                {
                    count++;
                }
            }


        }
    }
}
