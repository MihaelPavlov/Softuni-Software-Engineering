using System;
using System.Collections.Generic;
using System.Linq;

namespace Giftbox_Coverage_Giftbox
{
    class Program
    {
        static void Main(string[] args)
        {
            double sizeOfASize = double.Parse(Console.ReadLine());
            double numberOfSheetsOfPaper = int.Parse(Console.ReadLine());
            double areaSingleSheet = double.Parse(Console.ReadLine());

            double areaOfGiftBox = sizeOfASize * sizeOfASize * 6;

            double thirdS = Math.Floor(numberOfSheetsOfPaper / 3);


            double sheetsArea = (numberOfSheetsOfPaper * areaSingleSheet) - (thirdS * areaSingleSheet * 0.75);

            double percentage = (sheetsArea / areaOfGiftBox) * 100;
            Console.WriteLine($"You can cover {percentage:F2}% of the box.");

        }   
    }
}
    

