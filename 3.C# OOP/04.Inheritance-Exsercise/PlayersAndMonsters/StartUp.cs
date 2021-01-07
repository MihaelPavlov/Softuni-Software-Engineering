using System;

namespace PlayersAndMonsters
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var hero = new Hero("Misho", 20);
            var elf = new Elf("ElfskiRok", 5);
            var wizard = new Wizard("wizsda", 10);
            var knight = new Knight("Knights", 15);


            Console.WriteLine(hero);
            Console.WriteLine(elf);
            Console.WriteLine(wizard);
            Console.WriteLine(knight);
              
        }
    }
}
