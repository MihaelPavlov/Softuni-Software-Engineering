using MXGP.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories.Contracts
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly IList<IRace> models;
        public RaceRepository()
        {
            this.models = new List<IRace>();
        }
        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
           return this.models.ToList();
        }

        public IRace GetByName(string name)
        {
            IRace race = this.models.FirstOrDefault(r => r.Name == name);
            return race;
        }

        public bool Remove(IRace model)
        {
            return this.models.Remove(model);
        }
    }
}
