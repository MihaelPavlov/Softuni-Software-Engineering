using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var childrens = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
         
            Queue<string> allChild = new Queue<string>(childrens);

            int potato = 1;
            while (allChild.Count > 1)
            {
                var currentChild = allChild.Dequeue();

                if (potato % n != 0)
                {
                    allChild.Enqueue(currentChild);
                   
                    
                    
                }
                else
                {
                    Console.WriteLine($"Removed {currentChild}");
                }
                potato++;
            }
            Console.WriteLine($"Last is {allChild.Dequeue()}");

        }
    }
}
