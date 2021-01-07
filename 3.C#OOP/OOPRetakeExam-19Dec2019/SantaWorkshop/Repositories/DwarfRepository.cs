using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using SantaWorkshop.Models.Dwarfs.Contracts;
using System.Linq;

namespace SantaWorkshop.Repositories
{
   public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly List<IDwarf> models;
        public DwarfRepository()
        {
            this.models = new List<IDwarf>();
        }
        public IReadOnlyCollection<IDwarf> Models => this.models.AsReadOnly();

        public void Add(IDwarf model)
        {
            this.models.Add(model);
        }

        public IDwarf FindByName(string name)
        {
            IDwarf dwarfToReturn = this.models.First(d => d.Name == name);
            return dwarfToReturn;
        }

        public bool Remove(IDwarf model)
        {
            return this.models.Remove(model);
        }
    }
}
