using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlayersAndMonsters.Models.BattleFields.Contracts;

namespace PlayersAndMonsters.Core.Contracts
{
   public class ManagerController : IManagerController
    {
        private readonly IPlayerRepository players;
        private readonly ICardRepository cards;

        public ManagerController()
        {
            this.players = new PlayerRepository();
            this.cards = new CardRepository();
        }
        public string AddCard(string type, string name)
        {
            ICard card = null;
            
            if (type == "Magic")//maybe MagicCard
            {
                card = new MagicCard(name);
            }
            else if (type=="Trap") //Maybe TrapCard
            {
                card = new TrapCard(name);
            }
            this.cards.Add(card);
            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = null;
            if (type == "Beginner")
            {
                player = new Beginner(new CardRepository(),username);
            }
            else if (type=="Advanced")
            {
                player = new Advanced(new CardRepository(), username);
            }
            this.players.Add(player);
            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer playerToAddACard = this.players.Find(username);
            ICard cardToAdd = this.cards.Find(cardName);
            playerToAddACard.CardRepository.Add(cardToAdd);
            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.players.Find(attackUser);
            IPlayer enemy = this.players.Find(enemyUser);
            BattleField field = new BattleField();
            field.Fight(attacker,enemy);
            return $"Attack user health {attacker.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var player in this.players.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} – Cards {player.CardRepository.Count}");
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }
                sb.AppendLine("###");

            }
           return sb.ToString().TrimEnd();
        }
    }
}
