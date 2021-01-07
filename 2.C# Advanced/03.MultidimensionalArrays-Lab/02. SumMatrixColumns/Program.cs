using System;
using System.Linq;

namespace _02._SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensional = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();

            var rows = dimensional[0];
            var cols = dimensional[1];
            var matrix = new int[rows, cols];
            
            for (int row = 0; row < rows; row++)
            {
                int[] currentNumbers = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentNumbers[col];
                }
            }
            for (int row = 0; row < cols; row++)
            {
                int total = 0;
                for (int col = 0; col < rows; col++)
                {
                    total += matrix[col,row];
                }
                Console.WriteLine(total);
            }
        }
    }
}
