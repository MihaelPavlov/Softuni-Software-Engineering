using MXGP.Core.Contracts;
using MXGP.IO.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
       
        private readonly ChampionshipController controller;
        public Engine()
        {
           
            this.controller = new ChampionshipController();

        }
        public void Run()
        {

            while (true)
            {
                var input = Console.ReadLine().Split();
                string command = input[0];
                if (command == "End")
                {
                    break;
                }
                try
                {
                if (command == "CreateRider")
                {
                    string name = input[1];
                    Console.WriteLine(this.controller.CreateRider(name)) ;
                }
                else if (command == "CreateMotorcycle")
                {
                    string type = input[1];
                    string model = input[2];
                    int horsePower = int.Parse(input[3]);
                    Console.WriteLine(this.controller.CreateMotorcycle(type, model, horsePower));
                }
                else if (command == "AddMotorcycleToRider")
                {
                    string riderName = input[1];
                    string motorcycle = input[2];
                    Console.WriteLine(this.controller.AddMotorcycleToRider(riderName, motorcycle));
                }
                else if (command == "AddRiderToRace")
                {
                    string raceName = input[1];
                    string riderName = input[2];
                    Console.WriteLine(this.controller.AddRiderToRace(raceName, riderName)) ;
                }
                else if (command == "CreateRace")
                {
                    string name = input[1];
                    int laps = int.Parse(input[2]);
                    Console.WriteLine(this.controller.CreateRace(name, laps)) ;
                }
                else if (command == "StartRace")
                {
                    string raceName = input[1];
                    Console.WriteLine(this.controller.StartRace(raceName));
                }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                

            }
        }
    }
}
