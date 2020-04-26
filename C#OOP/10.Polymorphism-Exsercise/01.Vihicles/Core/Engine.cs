using _01.Vihicles.Enums;
using _01.Vihicles.Exceptions;
using _01.Vihicles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vihicles.Core
{
    public class Engine
    {

        public void Run()
        {
            var input = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            double tankCapacity = double.Parse(input[3]);
            var car = new Car(fuelQuantity, fuelConsumption, tankCapacity);

            input = Console.ReadLine().Split();

            fuelQuantity = double.Parse(input[1]);
            fuelConsumption = double.Parse(input[2]);
            tankCapacity = double.Parse(input[3]);

            var truck = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            input = Console.ReadLine().Split();
            fuelQuantity = double.Parse(input[1]);
            fuelConsumption = double.Parse(input[2]);
            tankCapacity = double.Parse(input[3]);
            var bus = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var inputDown = Console.ReadLine().Split();
                try
                {

                    if (inputDown[1] == nameof(Car))
                    {
                        ExcecuteCommand(car, inputDown[0], double.Parse(inputDown[2]));
                    }
                    else if (inputDown[1] == nameof(Truck))
                    {
                        ExcecuteCommand(truck, inputDown[0], double.Parse(inputDown[2]));
                    }
                    else if (inputDown[1] == nameof(Bus))
                    {
                        if (inputDown[0] == "Drive")
                        {                        
                                Console.WriteLine(bus.Drive(double.Parse(inputDown[2])));
 
                        }
                        else if (inputDown[0] == "Refuel")
                        {
                            ExcecuteCommand(bus, inputDown[0], double.Parse(inputDown[2]));
                        }
                        else if (inputDown[0]=="DriveEmpty")
                        {
                            Console.WriteLine(bus.DriveEmpty(double.Parse(inputDown[2])));
                        }
                    }
                }
                catch (InvalidFuelException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }

        private static void ExcecuteCommand(Vehicle vehicle, string command, double value)
        {
            if (command == "Refuel")
            {
                vehicle.Refuel(value);
            }
            else if (command == "Drive")
            {
                Console.WriteLine(vehicle.Drive(value));

            }
           

        }
    }
}
