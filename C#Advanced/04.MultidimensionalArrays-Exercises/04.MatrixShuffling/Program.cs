using System;
using System.Linq;
namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int rows = n[0];
            int cols = n[1];

            string[,] matrix = new string[rows, cols];


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currentNumber = Console.ReadLine().Split(" ").ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentNumber[col];

                }
            }




            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }             
                string[] cmdArgs = input.Split(" ");
                string command = cmdArgs[0];
                if (command!="swap" ||cmdArgs.Length!=5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                int row1 = int.Parse(cmdArgs[1]);
                int col1 = int.Parse(cmdArgs[2]);
                int row2 = int.Parse(cmdArgs[3]);
                int col2 = int.Parse(cmdArgs[4]);
                if (row1>=0 && row1<matrix.GetLength(0) 
                    && col1>=0 && col1<matrix.GetLength(1)
                    &&row2 >=0 && row2<matrix.GetLength(0)
                    &&col2 >=0 && col2<matrix.GetLength(1))
                {

                    string safeOne = matrix[row1, col1];
                    string first = matrix[row1, col1] = matrix[row2, col2];
                    string second = matrix[row2, col2] = safeOne;
                 
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                  
                }

               
                for (int printRow = 0; printRow < matrix.GetLength(0); printRow++)
                {
                    for (int printCol = 0; printCol < matrix.GetLength(1); printCol++)
                    {
                        Console.Write(matrix[printRow, printCol] + " ");
                    }
                    Console.WriteLine();
                }



            }
        }
    }
}
