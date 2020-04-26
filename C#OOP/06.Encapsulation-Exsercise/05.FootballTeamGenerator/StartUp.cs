using System;
using System.Collections.Generic;
using System.Linq;
namespace _05.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var teamInput = Console.ReadLine().Split(";");
            Team teamOne = new Team(teamInput[1]);
            var input = Console.ReadLine().Split(";");
            while (input[0]!="END")
            {
                    string command = input[0];
                        string team = input[1];

                try
                {
                    if (command == "END")
                    {
                        break;
                    }

                    if (command == "Add")
                    {
                        string playerName = input[2];

                        int endurance = int.Parse(input[3]);
                        int sprint = int.Parse(input[4]);
                        int dribble = int.Parse(input[5]);
                        int passing = int.Parse(input[6]);
                        int shooting = int.Parse(input[7]);
                        var addStats = new Stats(endurance, sprint, dribble, passing, shooting);
                        if (addStats.Endurance != 0 && addStats.Sprint != 0 && addStats.Dribble != 0 && addStats.Passing != 0 && addStats.Shooting != 0)
                        {
                            var addPlayer = new Player(playerName, addStats);
                            teamOne.AddPlayer(teamOne, addPlayer);

                        }
                    }
                    else if (command == "Remove")
                    {
                        string team1 = input[1];
                        string playerName1 = input[2];
                        teamOne.RemovePlayer(playerName1, team1);
                    }
                    else if (command == "Rating")
                    {
                        string teamName = input[1];
                        var stastTeam = teamOne.Rating(teamOne);
                        Console.WriteLine($"{teamName} - {stastTeam}");

                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                    input = Console.ReadLine().Split(";");
               
            }
        }
    }
}
