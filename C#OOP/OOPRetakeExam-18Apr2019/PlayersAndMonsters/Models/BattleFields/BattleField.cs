using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.BattleFields.Contracts
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer.GetType().Name == "Beginner")
            {
                attackPlayer.Health += 40;
                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            if (enemyPlayer.GetType().Name == "Beginner")
            {
                enemyPlayer.Health += 40;
                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            attackPlayer.Health += attackPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();

            while (true)
            {
                var attackerAttackPoints = attackPlayer.CardRepository.Cards.Select(c => c.DamagePoints).Sum();

                enemyPlayer.TakeDamage(attackerAttackPoints);
                if (enemyPlayer.IsDead)
                {
                    break;
                }

                var enemyAttackPoints = enemyPlayer.CardRepository.Cards.Select(c => c.DamagePoints).Sum();


                attackPlayer.TakeDamage(enemyAttackPoints);
                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}
