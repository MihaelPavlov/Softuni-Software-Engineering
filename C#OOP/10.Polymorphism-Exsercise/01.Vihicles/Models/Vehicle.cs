using _01.Vihicles.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vihicles.Models
{
   public abstract class Vehicle
    {
        private double fuelQuantity ;
        public Vehicle(double fuelQuantity , double fuelConsumption ,double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }
        protected virtual double AdditionalConsumption { get; }
        public virtual string Drive( double distance)
        {
            double neededFuel = (FuelConsumption + this.AdditionalConsumption) * distance;

            if (neededFuel<=this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }
        public virtual void Refuel( double litters)
        {
            double litterToAdd = litters + this.FuelQuantity;
            if (litters<=0)
            {
                throw new InvalidFuelException();
            }
            if (litterToAdd >this.TankCapacity)
            {
                throw new InvalidFuelException($"Cannot fit {litters} fuel in the tank");
            }
          
            this.FuelQuantity += litters;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
