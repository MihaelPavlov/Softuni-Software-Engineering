using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
   public class Tires
    {
        private readonly ICollection<Tires> data;
        public Tires(double tirePressure , int tireAge)
        {
            this.TirePressure = tirePressure;
            this.TireAge = tireAge;
            this.data = new List<Tires>();
        }
        public double TirePressure { get; set; }
        public int TireAge { get; set; }
    }
}
