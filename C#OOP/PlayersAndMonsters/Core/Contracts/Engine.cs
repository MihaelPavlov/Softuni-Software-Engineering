using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Contracts
{
    public class Engine : IEngine
    {

        private IReader reader;
        private IWriter writer;
        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
        }
        public void Run()
        {
            var input = Console.ReadLine().Split();
            var manager = new ManagerController();

            while (input[0] != "Exit")
            {
                try
                {

                    string command = input[0];
                    if (command == "AddPlayer")
                    {
                        string playerType = input[1];
                        string playerUsername = input[2];
                        Console.WriteLine(manager.AddPlayer(playerType, playerUsername));
                    }
                    else if (command == "AddCard")
                    {
                        string cardType = input[1];
                        string cardUsername = input[2];
                        Console.WriteLine(manager.AddCard(cardType, cardUsername));
                    }
                    else if (command == "AddPlayerCard")
                    {
                        string username = input[1];
                        string cardUsername = input[2];
                        Console.WriteLine(manager.AddPlayerCard(username, cardUsername));
                    }
                    else if (command == "Fight")
                    {
                        string attacker = input[1];
                        string enemy = input[2];
                        Console.WriteLine(manager.Fight(attacker, enemy));
                    }
                    else if (command == "Report")
                    {
                        Console.WriteLine(manager.Report());
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                input = Console.ReadLine().Split();
            }
        }
    }
}
