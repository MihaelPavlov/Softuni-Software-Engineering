﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05.SpecialCars
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
        public int HorsePower { get; }

        public double CubicCapacity { get; }

    }
}
