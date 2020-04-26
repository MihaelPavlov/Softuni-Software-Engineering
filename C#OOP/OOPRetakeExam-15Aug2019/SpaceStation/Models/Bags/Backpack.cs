using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private ICollection<string> bag;
        public Backpack()
        {
            this.bag = new List<string>();
        }
        public ICollection<string> Items => this.bag;
    }
}
