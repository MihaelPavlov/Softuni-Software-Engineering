using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Exceptions;

namespace ViceCity.Models.Guns.Contracts
{
    public abstract class Gun : IGun
    {

        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;
        private int barrelCapacity;
        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
            this.barrelCapacity = bulletsPerBarrel;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.GunInvalidName); ;
                }
                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get
            {
                return this.bulletsPerBarrel;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.GunInvalidBulletsPerBarrel);
                }
                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get
            {
                return this.totalBullets;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.GunInvalidTotalBullets);
                }
                this.totalBullets = value;
            }
        }

        public bool CanFire => this.BulletsPerBarrel > 0 || this.TotalBullets > 0;

        protected virtual int gunBulletShot { get; set; }
        public int Fire()
        {
            if (this.BulletsPerBarrel < this.gunBulletShot)
            {
                Reload();
            }
            int firedBullets = DecreasedBullets();
            return firedBullets;
        }

        private void Reload()
        {

            if (this.TotalBullets >= this.barrelCapacity)
            {
                this.BulletsPerBarrel = this.barrelCapacity;
                this.TotalBullets -= this.BulletsPerBarrel;
            }

        }
        private int DecreasedBullets()
        {
            int firedBullets = 0;

            if (this.BulletsPerBarrel - this.gunBulletShot >= 0)
            {
                this.BulletsPerBarrel -= this.gunBulletShot;
                firedBullets = this.gunBulletShot;
            }
            return firedBullets;
        }

    }
}
