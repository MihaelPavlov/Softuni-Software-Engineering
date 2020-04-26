using _01.Vihicles.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vihicles.Models
{
    public class Bus : Vehicle
    {
        private const double additionConsumptionPerKm=1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double AdditionalConsumption =>additionConsumptionPerKm ;


       
        public override string Drive(double distance)
        {
            
            
            return base.Drive(distance);
        }

        public string DriveEmpty(double distance)
        {

            double neededFuel = (this.FuelConsumption) * distance;

            if (neededFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }
        
        
      
        
    }
}
