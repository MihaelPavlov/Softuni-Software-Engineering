using _03.Inheritance_Lab.Animals;
using System;

namespace _03.Inheritance_Lab
{
   public class StartUp
    {
        static void Main(string[] args)
        {

            Dog dog = new Dog();
            Console.WriteLine("dog");
            dog.Eat();
            dog.Bark();
            Cat cat = new Cat();
            Console.WriteLine("cat");
            cat.Eat();
            cat.Meow();
        }
    }
}
