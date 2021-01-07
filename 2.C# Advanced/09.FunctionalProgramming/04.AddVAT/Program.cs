using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse);

            var numberWithVat = number.Select(x => x * 1.20M);// M - decimal
            foreach (var item in numberWithVat)
            {
                Console.WriteLine(item);
            }
        }
    }
}
