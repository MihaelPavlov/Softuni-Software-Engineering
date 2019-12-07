using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Упражнения__29._05
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstMatch = Console.ReadLine();
            string secondMatch = Console.ReadLine();
            string thirdMatch = Console.ReadLine();

            int firstResultLenght = firstMatch.Length;
            int secondResultLenght = secondMatch.Length;
            int thirdResultLenght = thirdMatch.Length;

            int counterWins = 0;
            int counterLoss = 0;
            int counterDraws = 0;

            if (firstMatch[0] > firstMatch[2])
            {
                counterWins++;
            }
            else if (firstMatch[0] < firstMatch[2])
            {
                counterLoss++;
            }
            else if (firstMatch[0] == firstMatch[2])
            {
                counterDraws++;
            }

            if (secondMatch[0] > secondMatch[2])
            {
                counterWins++;
            }
            else if (secondMatch[0] < secondMatch[2])
            {
                counterLoss++;
            }
            else if (secondMatch[0] == secondMatch[2])
            {
                counterDraws++;
            }

            if (thirdMatch[0] > thirdMatch[2])   fmm  
            {
                counterWins++;
            }
            else if (thirdMatch[0] < thirdMatch[2])
            {
                counterLoss++;
            }
            else if (thirdMatch[0] == thirdMatch[2])
            {
                counterDraws++;
            }

            Console.WriteLine($"Team won {counterWins} games.");
            Console.WriteLine($"Team lost {counterLoss} games.");
            Console.WriteLine($"Drawn games: {counterDraws}");


        }
    }
}
