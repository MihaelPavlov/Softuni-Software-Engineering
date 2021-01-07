using System;
using System.Collections.Generic;

namespace _09.Polymorphism_Lab
{
    public class Animal
    {
        public virtual void PrintToConsole()
        {
            Console.WriteLine($"{GetType().Name} -> Im a Animal");
        }
    }
    public class Mammal : Animal
    {
        public override void PrintToConsole()
        {
            Console.WriteLine($"{GetType().Name} -> Im a Mammal");

        }
    }
    public class Person : Mammal
    {
        public int Salary  => 1000;
        public override void PrintToConsole()
        {
            Console.WriteLine($"{GetType().Name} -> Im a Person with {this.Salary} salary");

        }
    }
   

  public  class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Animal>();
            list.Add(new Animal());
            list.Add(new Mammal());
            list.Add(new Person());

            foreach (var item in list)
            {
                Console.WriteLine(new string('-',20) );
                item.PrintToConsole();

            }
        }
    }
}
