using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());


            double[][] matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] currentNumbers = Console.ReadLine().Split().Select(double.Parse).ToArray();


                matrix[row] = new double[currentNumbers.Length];
                for (int col = 0; col < currentNumbers.Length; col++)
                {

                    matrix[row][col] = currentNumbers[col];
                }

            }
            int counter = 0;
            bool isEqualLenght = false;

            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {//If a row and the one below it have equal length,
             //multiply each element in both of them by 2, otherwise - divide by 2.

                if (matrix[i].Count() == matrix[i + 1].Count())
                {
                    matrix[i] = matrix[i].Select(x => x * 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[i] = matrix[i].Select(x => x / 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x / 2).ToArray();
                }
            }
            string line = Console.ReadLine();
            while (line!="End")
            {
                string[] cmdArgs = line.Split();
                string command = cmdArgs[0];


                if (command== "Add")
                {
                    int row = int.Parse(cmdArgs[1]);
                    int col = int.Parse(cmdArgs[2]);
                    int addValue = int.Parse(cmdArgs[3]);

                    if (row>=0 && row<matrix.Length
                        && col >=0 && col<matrix[row].Length)
                    {
                        matrix[row][col] += addValue;
                    }
                  
                }
                else if (command=="Subtract")
                {
                    int row = int.Parse(cmdArgs[1]);
                    int col = int.Parse(cmdArgs[2]);
                    int substractValue = int.Parse(cmdArgs[3]);


                    if (row >= 0 && row < matrix.Length
                      && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] -= substractValue;
                    }
                }








                line = Console.ReadLine();
            }


            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}


