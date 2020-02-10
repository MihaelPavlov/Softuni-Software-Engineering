using System;
using System.Linq;

namespace _04.SymbolinMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var rows = n;
            var cols = n;

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().ToArray();

                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col].ToString();
                }
            }

            string toFind = Console.ReadLine();
            bool findIt = false;
            int rowEnd = 0;
            int colEnd = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].Contains(toFind))
                    {
                        rowEnd = row;
                        colEnd = col;
                        Console.WriteLine($"({rowEnd}, {colEnd})");

                       findIt=true;
                    }
                   
                }
            }

            if (findIt==false)
            {
                Console.WriteLine($"{toFind} does not occur in the matrix");
            }
        }
    }
}
