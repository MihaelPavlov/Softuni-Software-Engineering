using System;
using System.Linq;

namespace _03.MultidimensionalArrays_Lab
{
    class Program
    {
        static void Main(string[] args)
        {

            //rank -колко дименсия има масива , двуизмерен ли е , триизмерен ?
            //getLenght от 0 ще върна първата дименсия(Демек ще върне редовете)
            //, а от 1 ще върне втората(демек колоните )


            var dimensions = Console.ReadLine()
                 .Split(new[] { ' ', ',' },StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int total = 0; 

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0;  col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                    total += currentRow[col];
                }
            }

            for (int col = 0; col < cols; col++)
            {
                var sum = 0;
                for (int row = 0; row < rows; row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(total);
        }
    }
}
