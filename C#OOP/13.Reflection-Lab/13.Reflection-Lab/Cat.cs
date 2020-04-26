using System;
using System.Collections.Generic;
using System.Text;

namespace _13.Reflection_Lab
{
  public  class Cat:IAnimal
    {
        public Cat(string name , int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsSleeping { get; set; }
    }
}
