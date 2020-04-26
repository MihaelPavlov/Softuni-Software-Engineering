using _04.WildFarm.Contracts;
using _04.WildFarm.Exceptions;
using _04.WildFarm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Core
{
    public class Engine : IEngine
    {
        ICollection<IAnimal> animals;
        ICollection<Food> foods;
        public void Run()
        {
            animals = new List<IAnimal>();
            foods = new HashSet<Food>();
            var input = Console.ReadLine().Split(" " ,StringSplitOptions.RemoveEmptyEntries);
            var inputFood = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            IAnimal animal = null;
            while (input[0] != "End")
            {
                string type = input[0];

                if (input.Length == 5)
                {
                    string name = input[1];
                    double weight = double.Parse(input[2]);
                    string livingRegion = input[3];
                    string breed = input[4];
                    animal = CreateAnimalFelines(type, name, weight, livingRegion, breed);
                    animals.Add(animal);
                }
                else if (input.Length == 4)
                {

                    if (type == "Owl" || type == "Hen")
                    {
                        string name = input[1];
                        double weight = double.Parse(input[2]);
                        double wingSize = double.Parse(input[3]);
                        animal = CreateAnimalBirds(type, name, weight, wingSize);
                        animals.Add(animal);
                    }
                    else if (type == "Mouse" || type == "Dog")
                    {
                        string name = input[1];
                        double weight = double.Parse(input[2]);
                        string livingRegion = input[3];
                        animal = CreateAnimalMammal(type, name, weight, livingRegion);
                        animals.Add(animal);
                    }
                }
                //foodStart
                string food = inputFood[0];
                int quantity = int.Parse(inputFood[1]);

                Console.WriteLine(animal.ProduceSoundForFood());
                try
                {

                   animal.AnimalEat(food, quantity);
                }
                catch (InvalidTypeOfFood ex)
                {

                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "End")
                {
                    break;
                }
                inputFood = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var ani in animals)
            {
                Console.WriteLine(ani.ToString());
            }

        }


        public static Food CreateFood(string typeFood, int quantity)
        {
            Food food = null;
            if (typeFood == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (typeFood == "Fruit")
            {
                food = new Fruit(quantity);

            }
            else if (typeFood == "Meat")
            {
                food = new Meat(quantity);

            }
            else if (typeFood == "Seeds")
            {
                food = new Seeds(quantity);

            }
            return food;
        }
        public static IAnimal CreateAnimalFelines(string type, string name,
              double weight, string livingRegion, string breed)
        {
            IAnimal animal = null;
            if (type == "Cat")
            {
                animal = new Cat(name, weight, 0, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, 0, livingRegion, breed);

            }



            return animal;
        }
        public static IAnimal CreateAnimalMammal(string type, string name, double weight,
             string livingRegion)
        {
            IAnimal animal = null;
            if (type == "Dog")
            {
                animal = new Dog(name, weight, 0, livingRegion);

            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, 0, livingRegion);
            }
            return animal;
        }

        public static IAnimal CreateAnimalBirds(string type, string name, double weight,
           double wingSize)
        {
            IAnimal animal = null;
            if (type == "Owl")
            {
                animal = new Owl(name, weight, 0, wingSize);

            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, 0, wingSize);

            }
            return animal;
        }
    }
}
