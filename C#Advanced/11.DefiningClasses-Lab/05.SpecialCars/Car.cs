using System;
using System.Collections.Generic;
using System.Text;

namespace _05.SpecialCars
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car()
         : this("VW", "Gold", 2025, 200, 10)
        {

        }
        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
       : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;

        }
        public Car(string make,
            string model,
            int year,
            double fuelQuantity,
            double fuelConsumption,
            Engine engine,
            Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            set
            {
                this.make = value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;
            }
        }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                this.fuelQuantity = value;
            }
        }
        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            set
            {
                this.fuelConsumption = value;
            }
        }

        public Engine Engine { get; }

        public Tire[] Tires
        {
            get
            {
                return this.tires;

            }
            set
            {
                this.tires = value;
            }
        }


        public void Drive(double distance)
        {
            double consumption = this.FuelConsumption *distance /100;


            if (consumption <= this.FuelQuantity)
            {
                this.FuelQuantity -= distance/100 * this.FuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enoug fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:f2}L\nEngine:\n  HorsePower:{this.Engine.HorsePower}\n   CubicCapacity{this.Engine.CubicCapacity} \nTires: {this.Tires.Length}";
        }
    }
}
