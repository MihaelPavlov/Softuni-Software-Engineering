using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Repositories.Contracts
{
   public class PlayerRepository : IPlayerRepository
    {
        private  List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public int Count { get; set; }

        public IReadOnlyCollection<IPlayer> Players => this.players;

        public void Add(IPlayer player)
        {
            IPlayer equalsNames = this.players.FirstOrDefault(p => p.Username == player.Username);
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            else if (equalsNames!=null)
            {
                throw new ArgumentException($"Player {player.Username} already exists!") ;
            }
            this.players.Add(player);
            this.Count++;
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
            this.Count--;
            return this.players.Remove(player);

        }
    }
}
