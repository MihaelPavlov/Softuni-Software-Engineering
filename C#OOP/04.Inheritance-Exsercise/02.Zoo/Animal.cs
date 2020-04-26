using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
  public  class Animal : IEnumerable
    {
        private List<Animal> data;
        public Animal(string name)
        {
            this.Name = name;
            this.data = new List<Animal>();
        }
        public string Name { get; set; }

        public object Current => throw new NotImplementedException();

        public void Add(Animal animal)
        {
            this.data.Add(animal);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in this.data)
            {
                yield return item;
            }
        }

        public override string ToString()
        {
          return $"Name -> { this.Name}";
        }
    }
}
