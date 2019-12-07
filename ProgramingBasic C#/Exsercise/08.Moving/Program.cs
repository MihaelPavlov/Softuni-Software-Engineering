using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeSpace = width * lenght * height;
            int boxesVolume = 0; ;

            string command;
            
            while (freeSpace> boxesVolume)
            {
                command = Console.ReadLine();
                if (command == "Done")
                {
                    break;
                }
                else
                {
                    boxesVolume += int.Parse(command);
                    
                }
                
            }
            if (boxesVolume > freeSpace)
            {
                Console.WriteLine($"No more free space! You need {boxesVolume - freeSpace} Cubic meters more");
            }
            else
            {
                Console.WriteLine($"{freeSpace-boxesVolume}Cubic meters left");
            }
            
        }
    }
}
