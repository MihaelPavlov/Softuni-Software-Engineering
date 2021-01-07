using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronautRepository;
        private PlanetRepository planetRepository;
        private IMission mission;
        private int countOfExplorePlanet;
        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            Astronaut astronaut = null;


            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            this.astronautRepository.Add(astronaut);
            return $"Successfully added {type}: {astronautName}";

        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            this.planetRepository.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = this.planetRepository.FindByName(planetName);
            List<IAstronaut> astronautsForMisiion = this.astronautRepository.Models.Where(a => a.Oxygen >= 60).ToList();
            if (astronautsForMisiion.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            this.mission.Explore(planet, astronautsForMisiion);
            this.countOfExplorePlanet++;
            return $"Planet: {planetName} was explored! Exploration finished with {astronautsForMisiion.Count(a=>!a.CanBreath)} dead astronauts!";
        }

        public string Report()
        {
            string sb = string.Empty;

            sb += $"{countOfExplorePlanet} planets were explored!" + Environment.NewLine;
                sb+=("Astronauts info:") + Environment.NewLine;
            foreach (var astronaut in astronautRepository.Models)
            {
                sb += $"Name: {astronaut.Name}" + Environment.NewLine;
                    sb +=$"Oxygen: {astronaut.Oxygen}" + Environment.NewLine;
                if (astronaut.Bag.Items.Count> 0 )
                {
                    sb+=($"Bag items: {string.Join(", " , astronaut.Bag.Items)}");
                }
                else if(astronaut.Bag.Items.Count==0)
                {
                    sb+=($"Bag items: none") ;
                }
                sb += Environment.NewLine;
                    
            }
           return sb.TrimEnd(); 
            
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronautRepository.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronautRepository.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
