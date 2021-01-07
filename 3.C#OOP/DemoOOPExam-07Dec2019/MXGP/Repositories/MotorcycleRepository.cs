using MXGP.Models.Motorcycles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories.Contracts
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly IList<IMotorcycle> models;
        public MotorcycleRepository()
        {
            this.models = new List<IMotorcycle>();
        }

       

        public void Add(IMotorcycle model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return this.models.ToList();
        }

        public IMotorcycle GetByName(string name)
        {
            IMotorcycle returnMotor = this.models.FirstOrDefault(m => m.Model == name);
            return returnMotor;
        }

        public bool Remove(IMotorcycle model)
        {
           return this.models.Remove(model);
        }
    }
}
