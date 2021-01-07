using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public class Robots : ID
    {
        public Robots(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get; set; }
        public string Id { get; set; }
        public string Birthday { get; set; }
    }
}
