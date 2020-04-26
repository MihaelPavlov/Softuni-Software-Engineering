﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Repositories.Contracts
{
  public  class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();


       

        public void Add(IGun model)
        {
            if (!this.models.Contains(model))
            {
                this.models.Add(model);
            }
        }

        public IGun Find(string name)
        {
            IGun gun = this.models.FirstOrDefault(x => x.Name == name);
            return gun;
        }

        public bool Remove(IGun model)
        {
            return this.models.Remove(model);
        }
    }
}
