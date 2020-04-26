using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles.Contracts
{
    public class SpeedMotorcycle : Motorcycle
    {
        private int horsePower;
        private const double cubicCentimeters = 125;
        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, cubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            protected set
            {
                if (value < 50 || value > 69)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                this.horsePower = value;
            }
        }


    }
}
