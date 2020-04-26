using System;
using System.Collections.Generic;

namespace Animals
{
  public  class StartUp
    {
        static void Main(string[] args)
        {



            List<Animals> animals = new List<Animals>();
            while (true)
            {
              var  command = Console.ReadLine();
                if (command == "Beast!")
                {
                    break;
                }
                var secondCommand = Console.ReadLine().Split();

                string name = secondCommand[0];
                int age = int.Parse(secondCommand[1]);
                string gender = secondCommand[2];

                if (command=="Cat")
                {
                    var cat = new Cat(name, age, gender);
                    if (cat.Name != null)
                    {
                    animals.Add(cat);
                       
                    }
                }
                else if (command == "Dog")
                {
                    var dog = new Dog(name, age, gender);
                    if (dog.Name != null)
                    {
                    animals.Add(dog);
                    }

                }
                else if (command == "Frog")
                {
                    var frog = new Frog(name, age, gender);
                    if (frog.Name != null)
                    {
                        animals.Add(frog);
                    }
                   

                }


            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal.Name+" "+animal.Age+ " " + animal.Gender);
                animal.ProduceSound();
            }
        }
    }
}
