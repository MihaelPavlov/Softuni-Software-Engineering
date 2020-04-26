using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns.Contracts
{
    public class Pistol : Gun
    {
        private const int BulletPerBarrel = 10;
        private const int TotalBullet = 100;
        public Pistol(string name)
            : base(name, BulletPerBarrel, TotalBullet)
        {

        }

        protected override int gunBulletShot => 1;

    
    }
}
