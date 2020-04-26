using System;
using System.Collections.Generic;
using System.Linq;


namespace _03.Ferrari
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            ICar car = new Ferrari();
            car.Driver = name;

           
            Console.Write($"{car.Model}/{car.UseBrakes()}/{car.PushTheGasPedal()}/{car.Driver}");
            
        }
    }
}
