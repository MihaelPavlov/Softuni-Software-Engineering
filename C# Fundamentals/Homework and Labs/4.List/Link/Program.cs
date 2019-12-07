using System;
using System.Collections.Generic;
using System.Linq;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {


            //list with wagon integers
            //with while loop
            // when we reacive add 

            List<int> wagons = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string line = Console.ReadLine();

            TokensAddAndPassengers(wagons, line, maxCapacity);


            Console.Write(string.Join(" ", wagons));





        }
        static void PassengerAdd(List<int> wagons, int passengers, int maxCapacity)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                int currentWagon = wagons[i]; //тук въртим фор цикъл ,за числата които са от инпута , това е слагаме стойноста ,на i in wagons и присвояваме ,
                //първото число от инпута тук.
                if (currentWagon + passengers <= maxCapacity)
                {
                    wagons[i] += passengers;// тук пак е така че да добавим пътниците в текущия вагон 
                    break;


                }
            }
        }
        static void TokensAddAndPassengers(List<int> wagons, string line, int maxCapacity)
        {
            while (line != "end")
            {
                string[] tokens = line.Split(" ");
                string command = tokens[0];



                if (command == "Add")
                {
                    int passengers = int.Parse(tokens[1]);
                    wagons.Add(passengers);
                }
                else
                {
                    int passengers = int.Parse(tokens[0]);

                    int currentNumber = passengers;
                    PassengerAdd(wagons, passengers, maxCapacity);


                }
                line = Console.ReadLine();

            }
        }


    }
}
