using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Own_Bussiness
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int allSize = width * lenght * height;
            bool hasEnoughFreeSpace = true;
            string command = "";


            while ((command=Console.ReadLine())!="Done")
            {
                int computer = int.Parse(command);
                allSize -= computer;

                if (allSize < 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(allSize)} Cubic meters more.");
                    hasEnoughFreeSpace = false;
                    break;
                }


            }
            if (hasEnoughFreeSpace)
            {
                Console.WriteLine($"{allSize} Cubic meters left."); 
            }


        }
    }
}
