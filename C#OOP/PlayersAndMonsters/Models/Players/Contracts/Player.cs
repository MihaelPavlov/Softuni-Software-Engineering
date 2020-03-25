﻿using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players.Contracts
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private ICardRepository cards;

        public Player(ICardRepository cardRepository , string username, int health)
        {
            this.cards = cardRepository;
            this.Username = username;
            this.Health = health;

        }
        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");
                }
                this.username = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero.") ;
                }
                this.health = value;
            }
        }


        public bool IsDead => this.Health <= 0;
        public ICardRepository CardRepository => cards;

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints<0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.") ;
            }
            if (this.Health-damagePoints<0)
            {
                this.Health = 0;
                return;
            }
            this.Health -= damagePoints;
        }
    }
}
