using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Repositories.Contracts
{
   public class CardRepository : ICardRepository
    {
        private List<ICard> cards;
        public CardRepository()
        {
            this.cards = new List<ICard>();
        }
        public int Count { get; set; }

        public IReadOnlyCollection<ICard> Cards => this.cards;

        public void Add(ICard card)
        {
            if (card == null )
            {
                throw new ArgumentException("Card cannot be null!");
            }
            ICard equalsCards = this.cards.FirstOrDefault(p => p.Name == card.Name);
            if(equalsCards!=null)
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            this.Count++;
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
            this.Count--;
            return this.cards.Remove(card);
        }
    }
}
