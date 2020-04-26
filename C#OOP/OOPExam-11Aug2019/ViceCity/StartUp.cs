using ViceCity.Core;
using ViceCity.Core.Contracts;
using System;
using ViceCity.Models.Players.Contracts;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using System.Collections.Generic;

namespace ViceCity
{
    public class StartUp
    {
        
        IEngine engine;
        static void Main(string[] args)
        {
            //List<IPlayer> civilPlayer = new List<IPlayer>();
            //var civilOne = new CivilPlayer("CivilOne");
            //var civilTwo = new CivilPlayer("CivilTwo");
            //var civilThree = new CivilPlayer("CivilThree");
            //civilPlayer.Add(civilOne);
            //civilPlayer.Add(civilTwo);
            //civilPlayer.Add(civilThree);
            //var player = new MainPlayer();
            //var gun = new Pistol("Pistol");
            //var gun1 = new Pistol("PistolTwo");
            //player.GunRepository.Add(gun);
            //player.GunRepository.Add(gun1);
            //var gank = new GangNeighbourhood();

           // gank.Action(player,civilPlayer);
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
