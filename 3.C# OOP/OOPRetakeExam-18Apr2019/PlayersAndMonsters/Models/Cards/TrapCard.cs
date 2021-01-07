using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards.Contracts
{
  public  class TrapCard : Card
    {
        private const int damage = 120;
        private const int health = 5;
        public TrapCard(string name)
            : base(name, damage, health)
        {
        }
    }
}
