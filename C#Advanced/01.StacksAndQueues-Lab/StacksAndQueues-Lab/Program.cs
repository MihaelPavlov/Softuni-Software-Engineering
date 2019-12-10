using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueues_Lab
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            var allChildred = Console.ReadLine().Split();
            Queue<string> children = new Queue<string>(allChildred);

            var number = int.Parse(Console.ReadLine());

            int counter = 1;

            while (children.Count > 1)
            {
                var currentChld = children.Dequeue();

                if (counter % number != 0)
                {
                    children.Enqueue(currentChld);
                }
                else
                {
                    Console.WriteLine($"Removed {currentChld}");
                }
                counter++;
               
            }
            Console.WriteLine($"Last is {children.Dequeue()}");
            

        }
    }
}
