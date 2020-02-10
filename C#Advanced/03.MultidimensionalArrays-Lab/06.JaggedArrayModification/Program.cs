using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());


            var cols = rows;

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = currentRow;
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] cmdArtgs = command.Split(" ");
                string cmd = cmdArtgs[0];
                int row = int.Parse(cmdArtgs[1]);
                int col = int.Parse(cmdArtgs[2]);
                int value = int.Parse(cmdArtgs[3]);
                if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine();
                    continue;

                }

                if (cmd == "Add")
                {

                    matrix[row][col] += value;




                }
                else if (cmd == "Subtract")
                {

                    matrix[row][col] -= value;


                }
                command = Console.ReadLine();


            }
            for (int row = 0; row < rows; row++)
            {

                for (int col = 0; col < rows; col++)
                {
                    Console.Write(matrix[row][col] + " " +
                        "");
                }
                Console.WriteLine();
            }
        }
    }
}
