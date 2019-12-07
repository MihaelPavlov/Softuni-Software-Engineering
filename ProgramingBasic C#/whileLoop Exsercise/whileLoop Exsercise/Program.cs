using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whileLoop_Exsercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggFirstPLayer = int.Parse(Console.ReadLine());
            int eggSecondPlayer = int.Parse(Console.ReadLine());

            
            string command = string.Empty;

            while (command!= "End of battle")
            {
                command = Console.ReadLine();
                  
                if (command=="one")
                {
                    eggSecondPlayer--;
                }
                else if (command=="two")
                {
                    eggFirstPLayer--;
                }
                if (eggFirstPLayer == 0)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {eggSecondPlayer} eggs left.");
                }
                else if (eggSecondPlayer == 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {eggFirstPLayer} eggs left.");
                }

            }
            Console.WriteLine($"Player one has {eggFirstPLayer} eggs left.");
            Console.WriteLine($"Player two has {eggSecondPlayer} eggs left.");

        }
    }
}
