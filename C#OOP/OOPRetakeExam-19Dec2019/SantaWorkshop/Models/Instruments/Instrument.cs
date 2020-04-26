﻿using SantaWorkshop.Models.Instruments.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Instruments
{
  public  class Instrument : IInstrument
    {
        private const int decreasePower = 10;
        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }
        public int Power
        {
            get
            {
                return this.power;
            }
          private  set
            {
                if (value<0)
                {
                    value = 0;
                }
                this.power = value;
            }
        }

        public bool IsBroken() => this.Power <= 0;
       

        public void Use()
        {
            this.Power -= decreasePower;
            if (this.Power <0)
            {
                this.Power = 0;
            }
        }
    }
}
