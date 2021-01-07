using System;
using System.Linq;

namespace _03.PrimalDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var rows = n;
            var cols = n;
            int[,] matrix = new int[rows, cols];
            int total = 0;
            int counter = 0;
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                    


                }
                for (int count = 0; count < matrix.GetLength(0); count++)
                {
                    
                    
                    if (counter == count)
                    {
                        total += matrix[row, count];
                        counter++;
                        break;
                    }
                   
                }
            }
            Console.WriteLine(total);

        }
    }
}
