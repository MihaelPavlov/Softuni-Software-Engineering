using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animals
    {
        public Cat(string name, int age, string gender) 
            : base(name, age, gender)
        {
            try
            {
                if (age < 0)
                {
                    throw new Exception("Invalid input");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow meow");
        }
        
    }
}
