using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
   public class Box
    {
        private double length;
        private double width;
        private double height;


        public Box(double length , double width , double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length 
        {
            get
            {
                return this.length;
            }
           private set
            {
                try
                {
                    if (value <= 0)
                    {

                        throw new ArgumentException("Length cannot be zero or negative.");
                    }
                    this.length = value;// MAYBE
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
          private  set
            {
                try
                {
                    if (value <= 0)
                    {

                        throw new ArgumentException("Width cannot be zero or negative.");
                    }
                    this.width = value;// MAYBE
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
          private  set
            {
                try
                {
                    if (value <= 0)
                    {

                        throw new ArgumentException("Height cannot be zero or negative.");
                    }
                    this.height = value;// MAYBE
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public  double Volume()
        {
            double sum = this.Length * this.Width * this.Height;
            return sum;
        }
        public double LateralSurfaceArea()
        {
            double sum = (2 * (this.Length * this.Height)) + (2 * (this.Width * this.Height));
            return sum;
        }
        public double SurfaceArea()
        {
            double sum = (2 * (this.Length * this.Width)) + (2 * (this.Length * this.Height)) + (2 * (this.Width * this.Height));
            return sum;
        }


    }
}
