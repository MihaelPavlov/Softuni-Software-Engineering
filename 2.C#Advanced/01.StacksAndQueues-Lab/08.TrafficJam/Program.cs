using System;
using System.Collections.Generic;
using System.Linq;


namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string input = Console.ReadLine();
            int count = 0;
            while (input!="end")
            {
                if (input == "green")
                {
                    if (cars.Count<n)
                    {
                        n = cars.Count;
                    }
                    for (int i = 0; i < n; i++)
                    {
                        var lastCar =cars.Dequeue();

                        Console.WriteLine($"{lastCar} passed!");
                        count++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
                input = Console.ReadLine();
            
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
