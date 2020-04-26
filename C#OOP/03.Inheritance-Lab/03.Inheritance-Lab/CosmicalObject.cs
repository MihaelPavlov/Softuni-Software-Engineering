using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Inheritance_Lab
{

    public class Galaxy
    {
        public Galaxy()
        {
            this.CosmicalObjects = new List<CosmicalObject>();
        }
        public List<CosmicalObject> CosmicalObjects { get; set; }
        
    }
   public class CosmicalObject
    {

        public CosmicalObject(int speed)
        {

            Console.WriteLine("CosmicalObject");
            this.Speed = speed;
        }
        public int Speed { get; set; }
        public int Move()
        {
            return this.Speed * 10;
        }
    }
    public class Star : CosmicalObject
    {
        public Star(int speed) : base(speed)
        {
            Console.WriteLine("star");
            this.Move();
        }
    }
    public class Planet : CosmicalObject 
    {
        public Planet() : base(500)
        {
            Console.WriteLine("Planet");
            this.Move();
        }
    }
    public class Earth : Planet
    {
        public Earth()
        {
            Console.WriteLine("Earth");
            this.Move();
            
        }
    }
    public class Mars :Planet
    {
        public Mars()
        {
            Console.WriteLine("Mars");
            this.Move();

        }
    }
    public class Sun : Star 
    {
        public Sun(int speed) : base(speed)
        {
            Console.WriteLine("Sun");
        }
        public int NumberOfPlanets { get; } = 8;// set the default value to 8
    }


}
