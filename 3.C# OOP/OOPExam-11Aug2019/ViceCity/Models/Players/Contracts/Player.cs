using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Exceptions;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players.Contracts
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        private IRepository<IGun> gunRepository;
        public Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.gunRepository = new GunRepository();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidName);
                }
                this.name = value;
            }
        }

        public bool IsAlive => this.LifePoints > 0;

        public IRepository<IGun> GunRepository => this.gunRepository;

        public int LifePoints
        {
            get
            {
                return this.lifePoints;

            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidLifePoints);
                }
                this.lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {//maybe lifepoint with small l
            this.LifePoints -= points;

            if (this.LifePoints < 0)
            {
                this.LifePoints = 0;
            }
        }
    }
}
