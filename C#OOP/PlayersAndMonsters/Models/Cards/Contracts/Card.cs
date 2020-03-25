﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards.Contracts
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoint;

        public Card(string name , int damagePoints,  int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }
        
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Card's name cannot be null or an empty string." );
                }
                this.name = value;
            }
        }

        public int DamagePoints
        {
            get
            {
                return this.damagePoints;
            }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Card's damage points cannot be less than zero.");
                }
                this.damagePoints = value;
            }
        }
       
        public int HealthPoints
        {
            get
            {
                return this.healthPoint;
            }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Card's HP cannot be less than zero.");
                }
                this.healthPoint = value;
            }
        }
    }
}
