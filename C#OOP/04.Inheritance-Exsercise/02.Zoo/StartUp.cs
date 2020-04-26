using System;

namespace Zoo
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var animals = new Animal("Reptiles");

            var reptile = new Reptile("Reptilee");
            var lizard = new Lizard("Lizarddd");
            var bear = new Bear("bearrrr");
            animals.Add(reptile);
            animals.Add(lizard);
            animals.Add(bear);

            foreach (var item in animals)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
