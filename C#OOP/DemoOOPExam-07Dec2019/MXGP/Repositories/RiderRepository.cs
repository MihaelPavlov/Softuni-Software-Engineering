using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories.Contracts
{
    public class RiderRepository : IRepository<IRider>
    {
        private readonly IList<IRider> models;
        public RiderRepository()
        {
            this.models = new List<IRider>();
        }
        public void Add(IRider model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.models.ToList() ;
        }

        public IRider GetByName(string name)
        {
            IRider rider = this.models.FirstOrDefault(r => r.Name == name);
            return rider;
        }

        public bool Remove(IRider model)
        {
            return this.models.Remove(model);
        }
    }
}
