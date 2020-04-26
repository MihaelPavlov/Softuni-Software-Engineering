using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
                var people = new List<Person>();
                var product = new List<Product>();
            try
            {
                var peopleArgs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                var productArgs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                AddPeople(peopleArgs, people);
                AddProduct(productArgs, product);

                var command = string.Empty;
                while((command = Console.ReadLine())!= "END")
                {
                    var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string name = cmdArgs[0];
                    string productName = cmdArgs[1];

                    try
                    {
                        Person thePerson = people.First(x => x.Name == name);
                        Product theProduct = product.First(x => x.Name == productName);
                        thePerson.BuyProduct(theProduct);
                        Console.WriteLine($"{thePerson.Name} bought {theProduct.Name}"); 



                   }
                    catch (ArgumentException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }


            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
               
                return;
                
            }
                foreach (var item in people)
                {

                    if (item.Bag.Count == 0)
                    {
                        Console.WriteLine($"{item.Name} - Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} - {(string.Join(", ", item.Bag.Select(x => x.Name)))}");//shit of piece :D

                    }


                }

        }

        private static void AddProduct(string[] productAndCost, List<Product> product)
        {
            for (int j = 0; j < productAndCost.Length; j++)
            {
                string[] secondCmdArgs = productAndCost[j].Split("=", StringSplitOptions.RemoveEmptyEntries);

                string nameProduct = secondCmdArgs[0];
                double cost = double.Parse(secondCmdArgs[1]);

                Product producToBuy = new Product(nameProduct, cost);
                product.Add(producToBuy);

            }
        }

        private static void AddPeople(string[] peopleArgs, List<Person> people)
        {
            for (int i = 0; i < peopleArgs.Length; i++)
            {
                string[] cmdArgs = peopleArgs[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArgs[0];
                double money = double.Parse(cmdArgs[1]);
                Person person = new Person(name, money);
                people.Add(person);
            }
        }
    }
}
