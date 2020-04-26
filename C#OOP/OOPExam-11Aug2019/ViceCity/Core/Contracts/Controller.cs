using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core.Contracts
{
    public class Controller : IController
    {
        private readonly MainPlayer mainPlayer;
        private readonly ICollection<IPlayer> civilPlayers;
        private readonly ICollection<IGun> guns;
        private readonly INeighbourhood gank;
        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.guns = new List<IGun>();
            this.gank = new GangNeighbourhood();
        }
        public string AddGun(string type, string name)
        {
            
            IGun gun = null;
            if (type == "Pistol")
            {
                gun = new Pistol(name);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name);
            }
            else
            {
                return "Invalid gun type!";
            }
            this.guns.Add(gun);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            string message = string.Empty;
            if (this.guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            IGun gun = this.guns.FirstOrDefault();
            IPlayer civilPlayer = this.civilPlayers.FirstOrDefault(x => x.Name == name);

            if (name == "Vercetti")
            {
                this.mainPlayer.GunRepository.Add(gun);

                message = $"Successfully added {name} to the Main Player: Tommy Vercetti";

 
            }
            else if (civilPlayer != null)
            {
                civilPlayer.GunRepository.Add(gun);
                message = $"Successfully added {gun.Name} to the Civil Player: {civilPlayer.Name}";
            }
            else
            {
                return "Civil player with that name doesn't exists!";
            }
            this.guns.Remove(gun);
            return message;
        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);
            this.civilPlayers.Add(player);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            int mainPlayerLifePoint = this.mainPlayer.LifePoints;
            int totalSumLifePoints = this.civilPlayers.Sum(p => p.LifePoints);
            this.gank.Action(this.mainPlayer, this.civilPlayers);
            int maintPlayerAfterLifePoint = this.mainPlayer.LifePoints;
            int aliveCivilPlayerCount = this.civilPlayers.Count(p => p.IsAlive);
            int totalSumAfteFight = this.civilPlayers.Sum(p => p.LifePoints);

            string message = string.Empty;

            
            if (mainPlayerLifePoint == maintPlayerAfterLifePoint && totalSumLifePoints == aliveCivilPlayerCount)
            {
                message = "Everything is okay!";
            }
            else
            {
                message = "A fight happened:" + Environment.NewLine;
                message += $"Tommy live points: {this.mainPlayer.LifePoints}!" + Environment.NewLine;
                message += $"Tommy has killed: {this.civilPlayers.Count - aliveCivilPlayerCount} players!"
                    + Environment.NewLine;
                message += $"Left Civil Players: {aliveCivilPlayerCount}!";
            }
            return message;

        }
    }
}
