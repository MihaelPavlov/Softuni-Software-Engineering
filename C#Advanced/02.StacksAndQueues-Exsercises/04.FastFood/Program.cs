using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int total = 0;
            int biggerOrder = 0;

            Queue<int> order = new Queue<int>(orders);
            for (int i = 0; i < orders.Length; i++)
            {
                int currentOrder = orders[i];
                total += currentOrder;
                if (biggerOrder < currentOrder)
                {
                    biggerOrder = currentOrder;
                }
                if (total >= quantity)
                {
                    break;
                }
                order.Dequeue();




            }
            Console.WriteLine(biggerOrder);
            if (total > quantity)
            {
                Console.WriteLine($"Orders left: {string.Join(" ",order)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
