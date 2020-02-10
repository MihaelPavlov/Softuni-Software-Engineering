using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
   public class Cargo
    {
        /*"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType}
         * {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure}
         * {tire3Age} {tire4Pressure} {tire4Age}"*/
        private int cargoWeight;
        private string cargoType;

        public int CargoWeight
        {
            get
            {
                return this.cargoWeight;
            }
            set
            {
                this.cargoWeight = value;
            }
        }

        public string CargoType
        {
            get
            {
                return this.cargoType;
            }
            set
            {
                this.cargoType = value;
            }
        }
    }
}
