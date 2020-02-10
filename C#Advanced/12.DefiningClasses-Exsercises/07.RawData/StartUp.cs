using System;
using System.Collections.Generic;
using System.Linq;


namespace _07.RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var cars = new HashSet<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);


                var engine = new Engine()
                {
                    EngineSpeed = engineSpeed,
                    EnginePower = enginePower,
                };
                var cargo = new Cargo()
                {
                    CargoWeight = cargoWeight,
                    CargoType = cargoType
                };

                var tires = new Tire[]
                {
                    new Tire(tire1Pressure, tire1Age),
                    new Tire(tire2Pressure, tire2Age),
                    new Tire(tire3Pressure, tire3Age),
                    new Tire(tire4Pressure, tire4Age),

                };

                var car = new Car(model, engine, cargo, tires);
                cars.Add(car);
              
            }

            string fragileIinputOrFlamableInput = Console.ReadLine();


            var carReturn = cars.Where(c => c.Cargo.CargoType == fragileIinputOrFlamableInput).ToList() ;
            foreach (var car in carReturn)
            {
                if (car.Cargo.CargoType =="flamable")
                {
                    var carFlamamble = car.Engine.EnginePower > 250;
                   
                    if (carFlamamble)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
                else if (car.Cargo.CargoType == "fragile")
                {
                    bool isTiresOk = false;

                    foreach (var tire in car.Tires)
                    {
                        if (tire.Pressure<=1)
                        {
                            isTiresOk = true;
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                    if (isTiresOk)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
               
            }
        }
    }
}
