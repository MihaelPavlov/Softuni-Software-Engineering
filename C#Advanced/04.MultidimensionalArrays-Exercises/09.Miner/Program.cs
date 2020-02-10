using System;
using System.Linq;
using System.Collections.Generic;


namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split();
            string[,] matrix = new string[n, n];
            ReadMatrix(matrix, n, n);
            //   PrintMatrix(matrix);
           
            int playerRow = -1;
            int playerCol = -1;
            int countCoals = 0;
            int[] cordinates = new int[2];
            int allCoals = 0;
            int countDirections = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].Equals("s"))
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    if (matrix[row,col].Equals("c"))
                    {
                        allCoals++;
                    }
                }
            }

            while (true)
            {
                if (directions.Length == countDirections)
                {
                    break;
                }
                
                foreach (var direction in directions)
                {
                    int playerNewRow = playerRow;
                    int playerNewCol = playerCol;
                    switch (direction)
                    {
                        
                        case "up":
                            playerNewRow--;
                            countDirections++;
                            break;
                        case "down":
                            playerNewRow++;
                            countDirections++;
                            break;
                        case "right":
                            playerNewCol++;
                            countDirections++;
                            break;
                        case "left":
                            playerNewCol--;
                            countDirections++;
                            break;

                    }
                    if (countCoals==allCoals)
                    {
                        for (int i = 0; i < cordinates.Length; i += 2)
                        {
                            cordinates[i] = playerRow;
                            cordinates[i + 1] = playerCol;
                        }
                        Console.WriteLine($"You collected all coals!({string.Join(", ", cordinates)})");
                        return;
                    }

                    if (IsValidIndex(matrix, playerNewRow, playerNewCol))
                    {
                        if (matrix[playerNewRow, playerNewCol] == "*")
                        {
                            matrix[playerRow, playerCol] = "*";
                            matrix[playerNewRow, playerNewCol] = "s";

                            // safe the new cordinates of the player
                            playerRow = playerNewRow;
                            playerCol = playerNewCol;
                            
                            PrintMatrix(matrix);

                        }
                        else if (matrix[playerNewRow,playerNewCol] == "c")
                        {
                            matrix[playerRow, playerCol] = "*";
                            matrix[playerNewRow, playerNewCol] = "s";
                            countCoals++;

                            playerRow = playerNewRow;
                            playerCol = playerNewCol;
                            PrintMatrix(matrix);
                        }
                        else if (matrix[playerNewRow,playerNewCol] == "e")
                        {
                            matrix[playerRow, playerCol] = "*";
                            matrix[playerNewRow, playerNewCol] = "s";
                            playerRow = playerNewRow;
                            playerCol = playerNewCol;
                            for (int i = 0; i < cordinates.Length; i+=2)
                            {
                                cordinates[i] = playerRow;
                                cordinates[i + 1] = playerCol;
                            }
                            Console.WriteLine($"Game over! ({string.Join(", ",cordinates)})" );
                            return;
                        }
                        //TODO if (matrix[playerNewRow, playerNewCol] == "c")
                        //TODO if (matrix[playerNewRow, playerNewCol] == "e")

                    }



                }
            }
            if (countCoals == allCoals)
            {
                for (int i = 0; i < cordinates.Length; i += 2)
                {
                    cordinates[i] = playerRow;
                    cordinates[i + 1] = playerCol;
                }
                Console.WriteLine($"You collected all coals! ({string.Join(", ", cordinates)})");
                return;
            }
            if (countCoals != allCoals)
            {
                for (int i = 0; i < cordinates.Length; i += 2)
                {
                    cordinates[i] = playerRow;
                    cordinates[i + 1] = playerCol;
                }
                Console.WriteLine($"{allCoals-countCoals} coals left. ({string.Join(", ", cordinates)})");
                return;
            }

        }

        static bool IsValidIndex(string[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        static void PrintMatrix(string[,] matrix)
        {
            Console.WriteLine();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static void ReadMatrix(string[,] matrix, int rows, int cols)
        {


            for (int row = 0; row < rows; row++)
            {
                string[] currentChar = Console.ReadLine().Split();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentChar[col];
                }
            }

        }
    }
}
