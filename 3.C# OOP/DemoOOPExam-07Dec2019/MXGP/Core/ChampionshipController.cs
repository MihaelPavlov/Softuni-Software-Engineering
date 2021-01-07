using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MXGP.Utilities.Messages;
using MXGP.Models.Races.Contracts;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private MotorcycleRepository motors;
        private RaceRepository races;
        private RiderRepository riders;
        public ChampionshipController()
        {
            this.motors = new MotorcycleRepository();
            this.races = new RaceRepository();
            this.riders = new RiderRepository();
        }
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IMotorcycle motor = this.motors.GetByName(motorcycleModel);
            IRider rider = this.riders.GetByName(riderName);
            if (rider==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            if (motor==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motor);
            return $"Rider {riderName} received motorcycle {motorcycleModel}";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRace race = this.races.GetByName(raceName);
            IRider rider = this.riders.GetByName(riderName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (rider== null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);
            return $"Rider {rider.Name} added in {race.Name} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle isExist = this.motors.GetByName(model);
            if (isExist != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }
            IMotorcycle motorcycle = null;
            StringBuilder message = new StringBuilder();
            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
                message.AppendLine($"SpeedMotorcycle {model} is created.");
            }
            else if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
                message.AppendLine($"PowerMotorcycle {model} is created.");
            }
            this.motors.Add(motorcycle);
            return message.ToString().TrimEnd();
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = this.races.GetByName(name);
            if (race!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }
            IRace raceToCreate = new Race(name, laps);
            this.races.Add(raceToCreate);
            return $"Race {raceToCreate.Name} is created.";
        }

        public string CreateRider(string riderName)
        {
            IRider riderExist = this.riders.GetByName(riderName);
            if (riderExist != null)
            {
                return $"Rider {riderName} is already created.";
            }
            IRider rider = new Rider(riderName);
            this.riders.Add(rider);
            return $"Rider {rider.Name} is created.";
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.GetByName(raceName);
            if (race==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            
            List<IRider> ridersToRace = this.riders.GetAll().ToList();

            if (ridersToRace.Count<3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, race.Name, 3));
            }

            List<IRider> theFastestRiders = ridersToRace.OrderByDescending(p => p.Motorcycle.CalculateRacePoints(race.Laps)).ToList();
            int countRiders = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var rider in theFastestRiders)
            {
                countRiders++;
                if (countRiders==1)
                {
                    rider.WinRace();
                    sb.AppendLine($"Rider {rider.Name} wins {race.Name} race.");
                }
                else if (countRiders==2)
                {
                   
                    sb.AppendLine($"Rider {rider.Name} is second in {race.Name} race.");
                }
                else if (countRiders==3)
                {
                    sb.AppendLine($"Rider {rider.Name} is third in {race.Name} race.");
                }
            }
     
            this.races.Remove(race);
            return sb.ToString().TrimEnd();
           
        }
    }
}
