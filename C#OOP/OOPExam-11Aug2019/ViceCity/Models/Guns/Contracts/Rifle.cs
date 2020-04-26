using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns.Contracts
{
  public  class Rifle : Gun
    {
        private const int BulletPerBarrel = 50;
        private const int totalBullet = 500;
        public Rifle(string name)
            : base(name, BulletPerBarrel, totalBullet)
        {
        }
        protected override int gunBulletShot => 5;
      
    }
}
