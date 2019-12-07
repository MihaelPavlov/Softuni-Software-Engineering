using System;
using System.Numerics;

namespace _10.Poke_Mon_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            //запасваме си оригиналната стойност - 50 % от нея ;
            double tempPower = power * 0.5;
            
            int count = 0;


            while (power>=distance)
            {
                count++;
                power -= distance;

                if (power==tempPower && exhaustionFactor!=0)
                {
                    power /= exhaustionFactor;
                }
            }

            Console.WriteLine(power);//принтираме колко POWER ни е останал
            Console.WriteLine(count);
        }
    }
}
