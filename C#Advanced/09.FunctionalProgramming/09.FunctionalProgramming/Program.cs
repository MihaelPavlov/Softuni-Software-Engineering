using System;
using System.Linq;

namespace _09.FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            string x = "adada";


            PrintResult(5, Square);
            PrintResult(5, Factorial);

            Action<int> action = PrintoConsoleWithLines;
            action += PrintoConsole;
            action(3);
            var input = new[] { 4,9, 13, 2, 13, 2321, 3112 };
            var result = input.Where(x => x % 2==0);
            Console.WriteLine(string.Join(", ", result));
        }

        static void PrintoConsoleWithLines (int x)
        {
            Console.WriteLine("================");
            Console.WriteLine($"   Result:  {x}");
            Console.WriteLine("================");
        }
        static void PrintoConsole(int x)
        {
            
            Console.WriteLine($"   Result:  {x}");
           
        }
        static void PrintResult (int x ,Func<int,long> func)
        {
            var result = func(x);
            Console.WriteLine("================");
            Console.WriteLine($"   Result:  {result}");
            Console.WriteLine("================");
        }
        static long Factorial(int number) 
        {
            long result = 1;

            for (int i = 2; i < number; i++)
            {
                result *= i;
            }
            return result;
        }
        static long Square (int number)
        {
            return number * number;
        }

    }
}
