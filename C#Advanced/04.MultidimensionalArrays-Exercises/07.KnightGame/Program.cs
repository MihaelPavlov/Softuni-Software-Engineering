using System;
using System.Linq;
using System.Collections.Generic;


namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            //FillTheMatrix
            for (int row = 0; row < n; row++)
            {
                char[] currentChars = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentChars[col];

                }
            }
            int count = 0;
            int counterBadHorse = 0;
            int maxKnightInDanger = -1;
            int dangerousKnightRow = 0;
            int dangerousKnightCol = 0;
            while (true)
            {
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        char currentChar = matrix[row, col];
                        //
                        if (currentChar == 'K')
                        {


                            if (row - 1 >= 0 && row - 1 < matrix.GetLength(0) && col - 2 >= 0 && col - 2 < matrix.GetLength(1)) //1
                            {
                                char currentSymbol = matrix[row - 1, col - 2];
                                if (currentSymbol == 'K')
                                {
                                
                                    counterBadHorse++;
                                   // PrintMatrix(matrix);

                                }
                            }
                            if (row + 1 >= 0 && row + 1 < matrix.GetLength(0) && col - 2 >= 0 && col - 2 < matrix.GetLength(1))//2
                            {
                                char currentSymbol = matrix[row + 1, col - 2];
                                if (currentSymbol == 'K')
                                {
                                 
                                    counterBadHorse++;
                                   // PrintMatrix(matrix);


                                }
                            }
                            if (row + 2 >= 0 && row + 2 < matrix.GetLength(0) && col - 1 >= 0 && col - 1 < matrix.GetLength(1))//3
                            {
                                char currentSymbol = matrix[row + 2, col - 1];
                                if (currentSymbol == 'K')
                                {
                                   
                                    counterBadHorse++;

                                   // PrintMatrix(matrix);


                                }
                            }
                            if (row - 2 >= 0 && row - 2 < matrix.GetLength(0) && col - 1 >= 0 && col - 1 < matrix.GetLength(1))//4
                            {
                                char currentSymbol = matrix[row - 2, col - 1];
                                if (currentSymbol == 'K')
                                {
                                    
                                    counterBadHorse++;

                                   // PrintMatrix(matrix);
                                }
                            }
                            if (row - 2 >= 0 && row - 2 < matrix.GetLength(0) && col + 1 >= 0 && col + 1 < matrix.GetLength(1))//5
                            {
                                char currentSymbol = matrix[row - 2, col + 1];
                                if (currentSymbol == 'K')
                                {
                                    
                                    counterBadHorse++;
                                   // PrintMatrix(matrix);

                                }
                            }
                            if (row + 2 >= 0 && row + 2 < matrix.GetLength(0) && col + 1 >= 0 && col + 1 < matrix.GetLength(1))//6
                            {
                                char currentSymbol = matrix[row + 2, col + 1];
                                if (currentSymbol == 'K')
                                {
                                   
                                    counterBadHorse++;
                                   // PrintMatrix(matrix);

                                }
                            }
                            if (row + 1 >= 0 && row + 1 < matrix.GetLength(0) && col + 2 >= 0 && col + 2 < matrix.GetLength(1))//7
                            {
                                char currentSymbol = matrix[row + 1, col + 2];
                                if (currentSymbol == 'K')
                                {
                                   
                                    counterBadHorse++;
                                   // PrintMatrix(matrix);

                                }
                            }
                            if (row - 1 >= 0 && row - 1 < matrix.GetLength(0) && col + 2 >= 0 && col + 2 < matrix.GetLength(1))//8
                            {
                                char currentSymbol = matrix[row - 1, col + 2];
                                if (currentSymbol == 'K')
                                {
                                   
                                    counterBadHorse++;
                                   // PrintMatrix(matrix);

                                }
                            }
                            if (counterBadHorse > maxKnightInDanger)
                            {
                                maxKnightInDanger = counterBadHorse;
                                dangerousKnightRow = row;
                                dangerousKnightCol = col;
                            }
                            counterBadHorse = 0;
                        }
                    }
                }

                if (maxKnightInDanger != 0)
                {
                    matrix[dangerousKnightRow, dangerousKnightCol] = '0';
                    count++;
                    maxKnightInDanger = 0;
                }
                else
                {
                    Console.WriteLine(count);
                    return;
                }

            }

            Console.WriteLine(counterBadHorse);

            //int counterBadK = 0;
            //foreach (var item in matrix)
            //{
            //    if (item=='X')
            //    {
            //        counterBadK++;
            //    }
            //}
            //Console.WriteLine(counterBadK);


        }


        static void PrintMatrix(char[,] matrix)
        {
            Console.WriteLine();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
