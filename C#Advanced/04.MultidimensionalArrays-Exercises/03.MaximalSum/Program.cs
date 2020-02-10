using System;
using System.Linq;

namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            long theBiggestSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentNumber = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentNumber[col];

                }
            }

            string firstLine = "";
            string secondLine = "";
            string thirdLine = "";

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {


                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = 0;
                    sum = matrix[row, col]
                        + matrix[row, col + 1]
                        + matrix[row, col + 2]
                        + matrix[row + 1, col]
                        + matrix[row + 1, col + 1]
                        + matrix[row + 1, col + 2]
                        + matrix[row + 2, col]
                        + matrix[row + 2, col + 1]
                        + matrix[row + 2, col + 2];
                    if (sum>=theBiggestSum)
                    {
                        theBiggestSum = sum;
                        firstLine = (matrix[row, col]+" "+ matrix[row, col + 1] + " " + matrix[row, col + 2]).ToString();
                        secondLine = (matrix[row+1, col] + " " + matrix[row+1, col + 1] + " " + matrix[row+1, col + 2]).ToString();
                        thirdLine = (matrix[row+2, col] + " " + matrix[row+2, col + 1] + " " + matrix[row+2, col + 2]).ToString();


                    }
                }
            }
            Console.WriteLine($"Sum = {theBiggestSum}");
            Console.WriteLine(firstLine);
            Console.WriteLine(secondLine);
            Console.WriteLine(thirdLine);
        }
    }
}
