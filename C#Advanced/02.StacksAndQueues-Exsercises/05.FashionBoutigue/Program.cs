using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutigue
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int capacityOFaRack = int.Parse(Console.ReadLine());
            Stack<int> rack = new Stack<int>(clothes);

            int total = 0;
            int rackCount = 1;
            int chekcIF = 0;

            while (rack.Any())
            {
                int currentClothe=rack.Pop();
                if (total >= capacityOFaRack)
                {
                    rackCount++;
                    total = 0;
                    total += currentClothe;
                }
                else
                {
                    chekcIF = total + currentClothe;
                    if (chekcIF>capacityOFaRack)
                    {
                        rackCount++;
                        total = 0;
                    }
                    else if (chekcIF==capacityOFaRack)
                    {
                        total += currentClothe;
                    }
                    total += currentClothe;

                }
               

            }
            Console.WriteLine(rackCount);

        }
    }
}
