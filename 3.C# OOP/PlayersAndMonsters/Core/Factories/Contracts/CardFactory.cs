using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Core.Factories.Contracts
{
  public  class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            ICard card = null;
            if (type == "Magic")//maybe MagicCard
            {
                card = new MagicCard(name);
            }
            else if (type == "Trap") //Maybe TrapCard
            {
                card = new TrapCard(name);
            }
            return card;
        }
    }
}
