using System;
using System.Linq;
using System.Collections.Generic;


namespace _10._RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = dimension[0];
            int cols = dimension[1];
            // char[,] matrix = ReadCharMatrix(rows, cols);

            char[,] matrix = new char[rows, cols];



            int playerRow = 0; // safe the real position of the player
            int playerCol = 0;

            //ReadMatrix
            for (int row = 0; row < rows; row++)
            {
                char[] rowValue = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValue[col];

                    if (matrix[row, col] == 'P')
                    {//get player position
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();

            bool isWon = false;
            //when we play we are not dead and notwin
            bool isDead = false;

            foreach (var direction in directions)
            {
                int playerNewRow = playerRow;
                int playerNewCol = playerCol;
                
                switch (direction)
                {//only Get the next move of the player
                    //is still not moved
                    case 'U':
                        playerNewRow--;
                        break;
                    case 'D':
                        playerNewRow++;
                        break;
                    case 'L':
                        playerNewCol--;
                        break;
                    case 'R':
                        playerNewCol++;
                        break;

                }


                 isWon = IsWon(matrix, playerNewRow, playerNewCol);

                if (!isWon)//if im not win 
                {// check is im dead            // check with the new player cordination is he dead
                     isDead = IsSymbol(matrix, 'B', playerNewRow, playerNewCol);
                    if (!isDead) //if im not dead Move the Player
                    { // put 'P' on the new position of the player
                        matrix[playerNewRow, playerNewCol] = 'P';
                    }

                    matrix[playerRow, playerCol] = '.';// make '.' the last position of the player
                    //if im not dead set the playerRow and playerCol
                    //to playerNewRow and PlayerNewCol
                    playerRow = playerNewRow;
                    playerCol = playerNewCol;

                }
                else
                {
                    matrix[playerRow, playerCol] = '.';
                }
                //safe the cordinates of all rabits
                List<int> bunniesCordinates = new List<int>();

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            bunniesCordinates.Add(row);
                            bunniesCordinates.Add(col);

                        }
                    }
                }

                //get the rabit cordinate two by two ; row and col
                for (int i = 0; i < bunniesCordinates.Count; i += 2)
                {
                    int bunnyRow = bunniesCordinates[i];
                    int bunnyCol = bunniesCordinates[i + 1];

                    SpreadBunny(matrix, bunnyRow, bunnyCol);
                }


                 isDead = IsSymbol(matrix, 'B', playerRow, playerCol);


                if (isWon || isDead)
                {
                    break;
                }
                

            }
            PrintMatrix(matrix);
            if (isWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else if (isDead)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
          
        }

         static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static void SpreadBunny(char[,] matrix, int bunnyRow, int bunnyCol)
        {


            if (bunnyRow - 1 >= 0)
            {
                matrix[bunnyRow - 1, bunnyCol] = 'B';
            }
            if (bunnyRow + 1 < matrix.GetLength(0))
            {
                matrix[bunnyRow + 1, bunnyCol] = 'B';
            }
            if (bunnyCol - 1 >= 0)
            {
                matrix[bunnyRow, bunnyCol - 1] = 'B';
            }
            if (bunnyCol + 1 < matrix.GetLength(1))
            {
                matrix[bunnyRow , bunnyCol+1] = 'B';
            }
        }

        private static bool IsSymbol(char[,] matrix, char symbol, int row, int col)
        {
            bool isSymbol = false;

            if (matrix[row, col] == symbol)
            {
                isSymbol = true;
            }
            return isSymbol;
        }

        private static bool IsWon(char[,] matrix, int row, int col)
        {
            bool isWon = true;
            //if the cell is still in the matrix we are not won
            
            if (row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1))
            {
                isWon = false; ;
            }
            //if we are out of the matrix we won
            return isWon;
        }

        static char[,] ReadCharMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            return matrix;
        }

        static bool IsValidCell(string[,] matrix, int row, int col)
        {
            bool isValid = false;

            if (row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1))
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
