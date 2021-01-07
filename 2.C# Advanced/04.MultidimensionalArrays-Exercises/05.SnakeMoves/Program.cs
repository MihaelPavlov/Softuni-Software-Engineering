using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = nums[0];
            int col = nums[1];
            char[,] matrix = new char[row, col];
            string snake = Console.ReadLine();
            int counter = 0;
            var myQue = new Queue<char>();


            int capacity = row * col;

            for (int i = 0; i < snake.Length; i++)
            {
                myQue.Enqueue(snake[i]);
                counter++;
                if (counter == capacity)
                {
                    break;
                }
                if (i == snake.Length - 1)
                {
                    i = -1;
                }
            }

            for (int i = 0; i < row; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < col; j++)
                    {
                        matrix[i, j] = myQue.Dequeue();
                    }
                }
                else if (i % 2 != 0)
                {
                    for (int secCol = col - 1 ; secCol > -1; secCol--)
                    {
                        matrix[i, secCol] = myQue.Dequeue();
                    }
                }
            }

            for (int row1 = 0; row1 < matrix.GetLength(0); row1++)
            {
                for (int col1 = 0; col1 < matrix.GetLength(1); col1++)
                {
                    Console.Write("{0}", matrix[row1, col1]);
                }

                Console.WriteLine();

            }
        }
    }
}
