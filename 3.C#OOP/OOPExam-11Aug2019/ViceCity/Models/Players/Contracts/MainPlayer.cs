using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players.Contracts
{
    public class MainPlayer : Player
    {
        private const int lifePoint = 100;
        private const string mainName = "Tommy Vercetti";
        public MainPlayer()
            : base(mainName, lifePoint)
        {
        }
    }
}
