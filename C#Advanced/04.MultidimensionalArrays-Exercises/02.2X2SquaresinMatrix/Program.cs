using System;
using System.Linq;

namespace _02._2X2SquaresinMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            char[,] matrix =new char [rows, cols];
            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentNumber = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentNumber[col];

                }
            }

            var sum = 0;
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    sum = matrix[row, col];
                    if ( sum == matrix[row,col]&&sum== matrix[row,col+1] 
                        && sum == matrix[row+1, col]
                        && sum == matrix[row+1, col + 1])
                    {
                        counter++;
                    }

                }
            }
            Console.WriteLine(counter) ;
        }
    }
}
