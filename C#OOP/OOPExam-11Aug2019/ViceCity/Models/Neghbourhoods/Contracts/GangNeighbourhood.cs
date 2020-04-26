using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using System.Linq;

namespace ViceCity.Models.Neghbourhoods.Contracts
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {

            foreach (var currentGun in mainPlayer.GunRepository.Models)
            {
                foreach (var currentCivilPlayer in civilPlayers)
                {
                    while (currentGun.CanFire || currentCivilPlayer.IsAlive)
                    {
                        currentCivilPlayer.TakeLifePoints(currentGun.Fire());

                    }
                    if (!currentGun.CanFire)
                    {
                        break;
                    }
                }
            }
            foreach (var currentCivilPlayer in civilPlayers)
            {
                if (!currentCivilPlayer.IsAlive)
                {
                    continue;
                }
                foreach (var currentGun in currentCivilPlayer.GunRepository.Models)
                {
                    while (currentGun.CanFire && mainPlayer.IsAlive)
                    {
                        mainPlayer.TakeLifePoints(currentGun.Fire());

                    }
                    if (!mainPlayer.IsAlive)
                    {
                        break;
                    }
                }
                if (!mainPlayer.IsAlive)
                {
                    break;
                }
            }
        }



    }
}
