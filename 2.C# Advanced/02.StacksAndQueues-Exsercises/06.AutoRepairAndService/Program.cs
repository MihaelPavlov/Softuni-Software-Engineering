using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.AutoRepairAndService
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carModels = Console.ReadLine().Split(" ");

            string command = Console.ReadLine();
            Queue<string> servedCars = new Queue<string>(carModels);
            Queue<string> doneCars = new Queue<string>();
            while (command!="End")
            {
                string[] cmdArgs = command.Split("-");
                string cmd = cmdArgs[0];

                if (cmd == "Service")
                {
                    string servedCar = servedCars.Dequeue();
                    doneCars.Enqueue(servedCar);
                    Console.WriteLine($"Vehicle {servedCar} got served");
                }
                else if (cmd == "CarInfo")
                {
                    string modelName = cmdArgs[1];

                    if (servedCars.Contains(modelName))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else if(doneCars.Contains(modelName))
                    {
                        Console.WriteLine("Served");
                    }
                }
                else if (cmd == "History")
                {
                    
                    Console.WriteLine($"Vehicles for serivice: {string.Join(", ", servedCars)}");
                    Console.WriteLine($"Served vehicles: {string.Join(", ", doneCars.Reverse())}");
                }




                command = Console.ReadLine();

                
            }

        }
    }
}
