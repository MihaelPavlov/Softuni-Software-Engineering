using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players.Contracts
{
   public class CivilPlayer : Player
    {
        private const int lifePoint = 50;
        public CivilPlayer(string name)
            : base(name, lifePoint)
        {
        }
    }
}
