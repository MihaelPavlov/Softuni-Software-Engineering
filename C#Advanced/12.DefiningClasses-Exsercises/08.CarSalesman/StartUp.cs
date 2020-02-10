using System;
using System.Collections.Generic;
using System.Linq;


namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Engine> engines = new HashSet<Engine>();
            List<Car> cars = new List<Car>();


            for (int i = 0; i < n; i++)
            {//Engine
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int power = int.Parse(input[1]);

                Engine engine = null;
                if (input.Length == 4)
                {
                    int displacement = int.Parse(input[2]);
                    string efficiency = input[3];
                     engine = new Engine(model, power, displacement, efficiency);
                }
                else if (input.Length == 3)
                {
                    int displacement;
                    bool isDisplacement = int.TryParse(input[2], out displacement);

                    if (isDisplacement )
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, input[2]);
                    }
                }
                else if (input.Length == 2)
                {
                    engine = new Engine(model, power);
                }
                engines.Add(engine);
               
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {//Car
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                Engine engine = engines.First(e => e.Model == input[1]);// model

                Car car = null;

                if (input.Length==4)
                {
                    int weight = int.Parse(input[2]);
                    string color = input[3];
                       car = new Car(model,engine,weight,color);
                }
                else if (input.Length==3)
                {
                    int weight;
                    bool isWeight = int.TryParse(input[2], out weight);
                    if (isWeight)
                    {
                        car = new Car(model,engine,weight);
                    }
                    else
                    {
                        car = new Car(model, engine, input[2]);
                    }
                }
                else if (input.Length==2)
                {
                    car = new Car(model, engine);
                }
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);

                
            }
        }
    }
}
