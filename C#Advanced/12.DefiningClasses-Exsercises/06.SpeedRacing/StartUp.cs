using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var cars = new HashSet<Car>()
                
                ;
            for (int i = 0; i < n; i++)
            {
                string[] firstInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
               
                string model = firstInput[0];
                double fuelAmount = double.Parse(firstInput[1]);
                double fuelPerKilometer = double.Parse(firstInput[2]);

                cars.Add(new Car
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumptionPerKilometer = fuelPerKilometer,
                    TravelledDistance = 0

                }) ;
              

            }


            string input = Console.ReadLine();

            while (input!="End")
            {
                string[] cmdArgs = input.Split();
                string carModel = cmdArgs[1];
                int amountOfKM = int.Parse(cmdArgs[2]);

                if (cmdArgs[0]== "Drive")
                {
                    foreach (var car in cars)
                    { // как програмата разбира на кой car.model  искам да взема стойностите
                        if (car.Model == carModel)
                        {
                            car.Drive(amountOfKM);
                            
                        }
                    }
                    
                }

               

                input = Console.ReadLine();
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }


    }
}
