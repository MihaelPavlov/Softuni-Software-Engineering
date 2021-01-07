using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles.Contracts
{
    public class PowerMotorcycle : Motorcycle
    {
        private int horsePower;
        private const double cubicCentimeter = 450;

        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, cubicCentimeter)
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
                if (value < 70 || value > 100)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                this.horsePower = value;
            }
        }

    }
}
