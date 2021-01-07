using System;
using System.Collections.Generic;
using System.Linq;


namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> playerOne = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> playerTwo = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int allSumOne = 0;
            int allSumTwo = 0;



            while (playerOne.Count!=0 &&playerTwo.Count!=0)
            {
                int card1 = playerOne[0];
                int card2 = playerTwo[0];

                if (card1>card2)
                {
                    RemoveCard(playerOne, playerTwo);

                    playerOne.Add(card1);
                    playerOne.Add(card2);

                }
                else if (card1<card2)
                {
                    RemoveCard(playerOne, playerTwo);

                    playerTwo.Add(card2);
                    playerTwo.Add(card1);

                }
                else
                {
                    RemoveCard(playerOne, playerTwo);
                }
            }
            if (playerOne.Sum()>playerTwo.Sum())
            {
                Console.WriteLine($"First player wins! Sum: {playerOne.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {playerTwo.Sum()}");
            }


        }
        static void RemoveCard(List<int> playerOne,List<int> playerTwo )    
        {
            playerOne.RemoveAt(0);
            playerTwo.RemoveAt(0);
        }


    }
}
