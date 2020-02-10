using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
namespace _05.SpecialCars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tires = new List<Tire[]>();
            var engines = new List<Engine>();
            var cars = new List<Car>();
            
            string input = Console.ReadLine();

            while (input != "No more tires")
            {


                string[] cmdArgs = input.Split();

                var tire = new Tire[4]
                {
                    new Tire(int.Parse(cmdArgs[0]),double.Parse(cmdArgs[1])),
                    new Tire(int.Parse(cmdArgs[2]),double.Parse(cmdArgs[3])),
                    new Tire(int.Parse(cmdArgs[4]),double.Parse(cmdArgs[5])),
                    new Tire(int.Parse(cmdArgs[6]),double.Parse(cmdArgs[7])),
                };
                tires.Add(tire);
         



                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input!= "Engines done")
            {
                string[] cmdArgs = input.Split();
                int hoursePower = int.Parse(cmdArgs[0]);
                double cubicCapacity = double.Parse(cmdArgs[1]);

                var engine = new Engine(hoursePower,cubicCapacity);

                engines.Add(engine);

                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input!="Show special")
            {
                string[] cmdArgs = input.Split();

                string currMake = cmdArgs[0];
                string currModel = cmdArgs[1];
                int currYear = int.Parse(cmdArgs[2]);
                double currFuelQuantity = double.Parse(cmdArgs[3]);
                double currFuelConsumption = double.Parse(cmdArgs[4]);
                int engineIndex = int.Parse(cmdArgs[5]);
                int tiresIndex = int.Parse(cmdArgs[6]);
                var car = new Car(currMake, currModel, currYear, currFuelQuantity, currFuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);
           

                input = Console.ReadLine();
            }

            foreach (var currenCar in cars)
            {

                bool specialYear = false;
                bool specialEngine = false;
                bool pressure = false;


                double specialTireSum = 0;

                if (currenCar.Year >= 2017)
                {
                    specialYear = true;
                }
                if (currenCar.Engine.HorsePower > 330)
                {
                    specialEngine = true;
                }
                foreach (var currTire in currenCar.Tires)
                {
                    double value = currTire.Pressure;
                    specialTireSum += value;
                }
                if (specialTireSum>=9 && specialTireSum<=10)
                {
                    pressure = true;
                }
                if (specialYear && specialEngine && pressure)
                {
                    currenCar.Drive(20);
                    Console.WriteLine($"Make: {currenCar.Make}\nModel: {currenCar.Model}\nYear: {currenCar.Year}\nHorsePowers: {currenCar.Engine.HorsePower}\nFuelQuantity: {currenCar.FuelQuantity}");
                }
            }

        }
    }
}
