using _03.Raiding.Exceptions;
using _03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Raiding.Core
{
    public class Engine : IEngine
    {
        private ICollection<BaseHero> raid;
        public void Run()
        {
            raid = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            while (n !=count)
            {
                string name = Console.ReadLine();
                string hero = Console.ReadLine();

                try
                {

                raid.Add(CreateHero(hero, name));
                    count++;
                }
                catch (InvalidHeroException ex)
                {

                    Console.WriteLine(ex.Message);           
                }

            }
            

            int healtOfTheBoss = int.Parse(Console.ReadLine());
            int sumOfAllHeroes = raid.Sum(h => h.Power);

            Console.WriteLine(PrintHero(raid)); 
            Console.WriteLine(StatementInTheGame(Calculation(healtOfTheBoss, sumOfAllHeroes)));

        }


        public static string PrintHero(ICollection<BaseHero> baseHeroes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in baseHeroes)
            {
                sb.AppendLine(hero.CastAbility());
            }
            return sb.ToString().TrimEnd();
            
        }
      
        public static bool Calculation(int healtBoss , int allCharPower)
        {

            if (allCharPower>=healtBoss)
            {
                return true;
            }
            return false;
        }
        public static string StatementInTheGame(bool winOrLose)
        {
            if (winOrLose)
            {
                return "Victory!";
            }
            return "Defeat...";
        }
        public static BaseHero CreateHero(string hero , string name)
        {
            BaseHero baseHero ;
            if (hero=="Druid")
            {
                baseHero = new Druid(name);
                
            }
            else if (hero == "Paladin")
            {
                baseHero = new Paladin(name);

            }
            else if (hero=="Rogue")
            {
                baseHero = new Rogue(name);

            }
            else if (hero=="Warrior")
            {
                baseHero = new Warrior(name);

            }
            else
            {
                throw new InvalidHeroException();
            }
            return baseHero;
        }
    }
}
