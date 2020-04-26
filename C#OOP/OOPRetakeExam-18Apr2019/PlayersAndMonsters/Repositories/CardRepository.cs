using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Repositories.Contracts
{
   public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;
        public CardRepository()
        {
            this.cards = new List<ICard>();
        }
        public int Count => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null )
            {
                throw new ArgumentException("Card cannot be null!");
            }
            bool equalsCards = this.cards.Any(p => p.Name == card.Name);
            if(equalsCards)
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            ICard returnCard = this.cards.FirstOrDefault(p => p.Name == name);
            return returnCard;
        }

        public bool Remove(ICard card)
        {
            if (card== null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            return this.cards.Remove(card);
        }
    }
}
