using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int theNumberOfSnowBall = int.Parse(Console.ReadLine());
            Decimal valueSnowBalls = 0;
            decimal maxValue = int.MinValue;
            decimal snowballSnow = 0;
            double snoballTime = 0;
            double snowballQuality = 0;

            
                    

            for (int i = 0; i < theNumberOfSnowBall; i++)
            {
                 snowballSnow = decimal.Parse(Console.ReadLine());
                 snoballTime = decimal.Parse(Console.ReadLine());
                 snowballQuality = double.Parse(Console.ReadLine());

                valueSnowBalls =Math.Pow((snowballSnow / snoballTime)*snowballQuality);

                if (maxValue<valueSnowBalls)
                {
                    maxValue = valueSnowBalls;
                }


            }

            Console.WriteLine($"{snowballSnow} : {snoballTime} = {valueSnowBalls} ({snowballQuality})");
          
        }
    }
}
