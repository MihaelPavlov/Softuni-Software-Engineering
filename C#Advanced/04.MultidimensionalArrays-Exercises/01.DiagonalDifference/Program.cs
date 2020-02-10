using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;
            

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                var currentNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();


                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentNumbers[col]; 
                }
            }
            int counter = 0;

            //Primary Diagonal
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (counter==col)
                    {
                        primaryDiagonalSum += matrix[row,col];
                        counter++;
                        break;
                    }
                }
            }

            //second variation for get diagonal 
            //int diagonalOne = 0;
            //for (int row = 0; row < n; row++)
            //{
            //    diagonalOne += matrix[row, row];
            //}


            counter =0;
            //Secondary Diagonl
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (counter == col)
                    {

                        secondaryDiagonalSum += matrix[row, col];
                        counter++;
                        break;
                    }
                }
                    
                
            }
            Console.WriteLine(Math.Abs(primaryDiagonalSum-secondaryDiagonalSum));



        
        }
    }
}
