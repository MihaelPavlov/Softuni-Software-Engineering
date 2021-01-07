using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            //bullet can unlock a lock 

            // with a size equal to or larger than the size of bullet

            int priceOnebullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> bulletStack = new Stack<int>(bullets);
            Queue<int> locksQueue = new Queue<int>(locks);


            int countOFTheBarrelBullets = 0;// if  sizeOfGunBarrel == count ("Reloading")
            //if bullets == 0 dont print reloading;

            int moneyPaidForBullets = 0;
            while (bulletStack.Any() &&  locksQueue.Any())
            {
                countOFTheBarrelBullets++;//countthe bullets

                int shootBullet = bulletStack.Pop();
                moneyPaidForBullets += priceOnebullet;
                int shootLock = locksQueue.Peek();

                if (shootBullet<=shootLock)
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (countOFTheBarrelBullets == sizeOfGunBarrel && bulletStack.Count!=0)
                {
                    Console.WriteLine("Reloading!");
                    countOFTheBarrelBullets = 0;
                }

            }


            if (bulletStack.Count==0 && locksQueue.Count!=0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${valueOfIntelligence-moneyPaidForBullets}");
            }
            


        }
    }
}
