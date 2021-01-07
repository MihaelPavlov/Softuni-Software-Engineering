using System;
using System.Collections.Generic;
using System.Linq;


namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> list = new HashSet<string>();

            while (input!= "END")
            {
                string[] cmd = input.Split(", ");
                string command = cmd[0];
                string number = cmd[1];

                if (command=="IN")
                {
                    list.Add(number);
                }
                else if (command=="OUT")
                {
                    list.Remove(number);
                }






                input = Console.ReadLine();

            }
            if (list.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var cars in list)
                {
                    Console.WriteLine(cars);
                }
            }
        }
    }
}
