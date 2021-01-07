using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double InitialOxygen = 70;
        private const double deacreaseUnitsOxygen = 5;
        public Biologist(string name) 
            : base(name, InitialOxygen)
        {

        }
        public override void Breath()
        {
            this.Oxygen -= deacreaseUnitsOxygen;
            if (this.Oxygen< 0)
            {
                this.Oxygen = 0;
            }
        }
    }
}
