using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Core.Factories.Contracts
{
   public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player = null;
            if (type == null)
            {
                throw new ArgumentException("Player of this type does not exists!");
            }
            if (type == "Beginner")
            {
                player = new Beginner(new CardRepository(), username);
            }
            else if (type == "Advanced")
            {
                player = new Advanced(new CardRepository(), username);
            }
            return player;
        }
    }
}
