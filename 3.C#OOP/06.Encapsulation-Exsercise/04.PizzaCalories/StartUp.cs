using System;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaName = Console.ReadLine().Split();
                var input = Console.ReadLine().Split();




                string flour = input[1];
                string bakingType = input[2];
                double weight = double.Parse(input[3]);
                var dough = new Dough(flour, bakingType, weight);
                var pizza = new Pizza(pizzaName[1], dough);
                while (true)
                {
                    var command = Console.ReadLine().Split();
                    if (command[0] == "END")
                    {
                        break;
                    }
                    
                    string topingType = command[1];
                    double weightTop = double.Parse(command[2]);
                    var toping = new Topping(topingType, weightTop);
                    pizza.AddToping(toping);

                    
                   


                }

                Console.WriteLine(pizza.ToString());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            


        }
    }
}
