using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Car
    {


        public Car(string model, Engine engine, Cargo cargo,ICollection<Tires> tires )
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public ICollection<Tires> Tires { get; set; }

    }
}
