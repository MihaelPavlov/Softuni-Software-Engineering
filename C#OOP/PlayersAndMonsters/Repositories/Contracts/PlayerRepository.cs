using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Repositories.Contracts
{
   public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public int Count => this.Players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players;

        public void Add(IPlayer player)
        {
            bool equalsNames = this.players.Any(p => p.Username == player.Username);
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            else if (equalsNames)
            {
                throw new ArgumentException($"Player {player.Username} already exists!") ;
            }
            this.players.Add(player);
          
        }

        public IPlayer Find(string username)
        {
            IPlayer returnPlayer = this.players.FirstOrDefault(p => p.Username == username);
            return returnPlayer;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
           
            return this.players.Remove(player);

        }
    }
}
