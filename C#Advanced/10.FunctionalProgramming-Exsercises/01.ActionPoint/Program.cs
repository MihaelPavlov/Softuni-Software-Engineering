using System;
using System.Linq;


namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNames = Console.ReadLine().Split();


            Action<string> action =PrintNewLine ;


            for (int i = 0; i < inputNames.Length; i++)
            {
                action(inputNames[i]);

            }

        }
        static void PrintNewLine(string name)
        {
            Console.WriteLine(name);
        }
    }
}
