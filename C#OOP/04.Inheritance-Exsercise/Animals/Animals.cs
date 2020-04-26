using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
   public class Animals 
    {
        public Animals(string name , int age , string gender)
        {
            try
            {
                if (age <0)
                {
                    throw new Exception("Invalid input");
                }
                else
                {
                    this.Name = name;
                    this.Age = age;
                    this.Gender = gender;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public virtual void ProduceSound()
        {

        }
    }
}
