using System;
using System.Collections.Generic;
using System.Linq;


namespace _08._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            FillTheMatrix(matrix, n, n);

            string[] numbers = Console.ReadLine().Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
          
            bool isBombThere = false;
            var aliveCells = new List<int>();

            for (int boombs = 0; boombs < numbers.Length; boombs += 2)
            {
                int boomRow = int.Parse(numbers[boombs]);
                int boomCol = int.Parse(numbers[boombs + 1]);
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (boomRow == row && boomCol == col)
                        {
                            if (matrix[boomRow, boomCol] <= 0)
                            {
                                continue;
                            }
                            else
                            {
                                if (isValidCellInMatrix(row - 1, col - 1, matrix))//8
                                {
                                    if (matrix[row - 1, col - 1] > 0)
                                    {
                                        matrix[row - 1, col - 1] -= matrix[row, col];

                                    }
                                }
                                if (isValidCellInMatrix(row - 1, col, matrix))//1
                                {

                                    if (matrix[row - 1, col] > 0)
                                    {
                                        matrix[row - 1, col] -= matrix[row, col];

                                    }

                                }
                                if (isValidCellInMatrix(row - 1, col + 1, matrix))//2
                                {

                                    if (matrix[row - 1, col + 1] > 0)
                                    {
                                        matrix[row - 1, col + 1] -= matrix[row, col];

                                    }
                                }
                                if (isValidCellInMatrix(row, col + 1, matrix))//3
                                {

                                    if (matrix[row, col + 1] > 0)
                                    {
                                        matrix[row, col + 1] -= matrix[row, col];

                                    }
                                }
                                if (isValidCellInMatrix(row + 1, col + 1, matrix))//4
                                {

                                    if (matrix[row + 1, col + 1] > 0)
                                    {
                                        matrix[row + 1, col + 1] -= matrix[row, col];

                                    }
                                }
                                if (isValidCellInMatrix(row + 1, col, matrix))//5
                                {

                                    if (matrix[row + 1, col] > 0)
                                    {
                                        matrix[row + 1, col] -= matrix[row, col];

                                    }
                                }
                                if (isValidCellInMatrix(row + 1, col - 1, matrix))//6
                                {

                                    if (matrix[row + 1, col - 1] > 0)
                                    {
                                        matrix[row + 1, col - 1] -= matrix[row, col];

                                    }
                                }
                                if (isValidCellInMatrix(row, col - 1, matrix))//7
                                {

                                    if (matrix[row, col - 1] > 0)
                                    {
                                        matrix[row, col - 1] -= matrix[row, col];

                                    }
                                }
                            }
                        }
                        if (boomRow == row && boomCol == col)
                        {
                            matrix[boomRow, boomCol] = 0;
                        }

                    }
                }
            }
            foreach (var item in matrix)
            {
                if (item > 0)
                {
                    aliveCells.Add(item);
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells.Count}");
            Console.WriteLine($"Sum: {aliveCells.Sum()}");
            PrintIntMatrix(matrix);

        }
        static void FillTheMatrix(int[,] matrix, int rows, int cols)
        {

            for (int row = 0; row < rows; row++)
            {
                int[] currentNumber = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentNumber[col];
                }
            }

        }
        static void PrintIntMatrix(int[,] matrix)
        {
            // Console.WriteLine();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }


        }
        static bool isValidCellInMatrix(int row, int col, int[,] matrix)
        {
            if (0 <= row && row < matrix.GetLength(0) && 0 <= col && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
