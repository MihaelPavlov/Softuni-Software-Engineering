using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
           
            foreach (var astronaut in astronauts)
            {
                while (astronaut.CanBreath)
                {
                    foreach (var item in planet.Items)
                    {
                        astronaut.Breath();
                        astronaut.Bag.Items.Add(item);
                        planet.Items.Remove(item);
                        break;
                    }
                    if (planet.Items.Count==0)
                    {
                        break;
                    }
                }
                if (planet.Items.Count == 0)
                {
                    break;
                }
            }

         
            

        }

    }
}

