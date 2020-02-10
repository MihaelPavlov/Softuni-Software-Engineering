using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
   public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }



        public  void Drive( int distance)
        {
            if (this.FuelAmount>=(distance *this.FuelConsumptionPerKilometer))
            {
                 this.FuelAmount -= (this.FuelConsumptionPerKilometer * distance);
                this.TravelledDistance += distance;

            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }


        }

    }
}
