using System;
using System.Linq;


namespace _05.SquarewithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];


            int theBiggestSum = 0;
            string safeRow = "";
            string safeCol = "";
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] readRowsNumber = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = readRowsNumber[col];
                }
            
            }


            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                

                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    int sum = 0;
                    sum += matrix[row, col]
                        + matrix[row, col + 1]
                        + matrix[row + 1, col]
                        + matrix[row + 1, col + 1];
                    if (sum> theBiggestSum)
                    {
                        theBiggestSum = sum;
                        safeRow = matrix[row, col].ToString() + " "+ matrix[row,col+1].ToString();
                        safeCol = matrix[row+1, col].ToString() + " "+ matrix[row+1,col+1].ToString();
                       

                    }
                }
            }

            Console.WriteLine(safeRow);
            Console.WriteLine(safeCol);
            Console.WriteLine(theBiggestSum);
        }
    }
}
