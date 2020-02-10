using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

           
            
            Queue<int[]> difference = new Queue<int[]>();

           
            for (int i = 0; i < n; i++)
            {
                int[] pumps = Console.ReadLine().Split().Select(int.Parse).ToArray();
                difference.Enqueue(pumps);
            }
            int safePoint = 0;

            while (true)
            {
                int fuelAmount = 0;
         
                bool foundPoint = true;

                for (int i = 0; i < n; i++)
                {
                    int[] currentPump = difference.Dequeue();
                    fuelAmount += currentPump[0];
                    if (fuelAmount < currentPump[1])
                    {
                        foundPoint = false;
                    }
                    fuelAmount -= currentPump[1];
                    difference.Enqueue(currentPump);
                   
                }
                if (foundPoint == true)
                {
                    break;
                }
                safePoint++;
                difference.Enqueue(difference.Dequeue());

            }

            Console.WriteLine(safePoint);
        }
    }
}
