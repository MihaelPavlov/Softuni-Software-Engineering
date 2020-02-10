using System;
using System.Linq;

namespace Jagged_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] arr = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                arr[row] = currentRow;
                //for (int col = 0; col < currentRow.Length; col++)
                //{
                //    arr[row][col] = currentRow[col];
                //}
            }

        }
    }
}
