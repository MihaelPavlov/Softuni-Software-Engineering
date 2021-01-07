using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.IO.Contracts;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Contracts
{
    public class Engine : IEngine
    {
        private readonly IManagerController manager;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IPlayerRepository players;
        private readonly ICardRepository cards;
        private readonly IBattleField field;
        private readonly ICardFactory cardFactory;
        private readonly IPlayerFactory playerFactory;
        public Engine()
        {
            this.players = new PlayerRepository();
            this.cards = new CardRepository();
            this.field = new BattleField();
            this.cardFactory = new CardFactory();
            this.playerFactory = new PlayerFactory();
            this.reader = new Reader();
            this.writer = new Writer();
            this.manager = new ManagerController();
        }
        public void Run()
        {


            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    break;
                }
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
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
