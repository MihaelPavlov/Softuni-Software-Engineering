using System;
using System.Linq;


namespace _01.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = number[0];
            var cols = number[1];
            var matrix = new int[rows, cols];
            int total = 0;
            for (
                int row = 0; row < number[0]; row++)
            {

                int[] currentNumber = Console.ReadLine()
                   .Split(", ")
                   .Select(int.Parse)
                   .ToArray();
                for (
                    int col = 0; col < number[1]; col++)
                {
                    matrix[row, col] = currentNumber[col];
                    total += currentNumber[col];
                }


            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(total);
        }
    }
}
