using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
         private   set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }
                this.name = value;


            }
        }
        public IReadOnlyCollection<Player> Players
        {
            get
            {
                return this.players;
            }
           
        }


        public void AddPlayer(Team team, Player player)
        {

            if (this.Name == team.Name)
            {
                this.players.Add(player);
            }
            else
            {
                throw new Exception($"Team{name} does not exist.");
            }

        }
        public void RemovePlayer(string playerName, string teamName)
        {

            bool isRetur = false;
            foreach (var player in players)
            {
                if (player.Name == playerName)
                {
                    this.players.Remove(player);
                    isRetur = true;
                    break;
                }
            }
            if (isRetur == false)
            {


                throw new Exception($"Player {playerName} is not in {teamName} team.");

            }

        }

        public double Rating(Team team)
        {

            if (this.Name == team.name)
            {
                if (this.players.Count!=0)
                {
                double sumRating =Math.Round(this.players.Sum(x => x.Stats.AverageStat()));
                return (int)sumRating;

                }
                return 0;

            }
            else
            {
               
                throw new Exception($"Team{team.name} does not exist.");
            }



        }
    }
}
