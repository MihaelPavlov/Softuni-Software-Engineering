using System;
using System.Collections.Generic;
using System.Text;

namespace _05.SpecialCars
{
    public class Tire
    {
        private int year;
        private double pressure;

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
        public int Year { get; }

        public double Pressure
        {
            get
            {
                return this.pressure;
            }
            set
            {
                this.pressure = value;
            }
        }

    }
}
