using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> bag;
        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;


            }
        }
        public double Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;


            }
        }
        public IReadOnlyCollection<Product> Bag
        {
            get
            {
                return this.bag;

            }

        }





        public void Add(Product product)
        {
            this.bag.Add(product);
        }

        public void BuyProduct(Product product)
        {
            if (this.Money< product.Cost)
            {
                           
                throw new ArgumentException($"{this.Name} can't afford {product.Name}") ;
            }
            this.Money -= product.Cost;
            this.bag.Add(product);
        }


    }
}
