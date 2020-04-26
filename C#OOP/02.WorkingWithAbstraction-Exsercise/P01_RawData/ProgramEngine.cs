using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace P01_RawData
{
   public class ProgramEngine
    {
        public void Run()
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            List<Tires> tires = new List<Tires>();
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];

                
                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);

                Engine engine = CreateEngine(engineSpeed,enginePower);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];
                Cargo cargo = CreateCargo(cargoWeight, cargoType);

                CreateTires(parameters, tires);

                
            
                cars.Add(new Car(model, engine, cargo,tires));
            }

            string command = Console.ReadLine();
            Output(command,cars);
        }

        public Engine CreateEngine(int engineSpeed, int enginePower)
        {
            var engine = new Engine(engineSpeed, enginePower);
            return engine;
        }

        public Cargo CreateCargo(int cargoWeight , string cargoType)
        {
            var cargo = new Cargo(cargoWeight, cargoType);
            return cargo;
        }
        public List<Tires> CreateTires(string[] parameters , List<Tires> tires)
        {
            for (int j = 5; j <= 12; j += 2)
            {
                double tirePressure = double.Parse(parameters[j]);
                int tireAge = int.Parse(parameters[j + 1]);
                var tire = new Tires(tirePressure, tireAge);
                tires.Add(tire);
            }

            return tires;
        }
       public void Output(string command ,List<Car> cars)
        {
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.TireAge < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

    }
}
