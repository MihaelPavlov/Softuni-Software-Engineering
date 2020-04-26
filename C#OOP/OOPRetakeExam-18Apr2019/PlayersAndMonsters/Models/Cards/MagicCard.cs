using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards.Contracts
{
    public class MagicCard : Card
    {
        private const int damage = 5;
        private const int health = 80;
        public MagicCard(string name) 
            : base(name, damage, health)
        {
        }
    }
}
