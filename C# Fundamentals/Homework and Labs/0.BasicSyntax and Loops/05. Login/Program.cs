using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string correctPassword = "";

            for (int i  = username.Length-1; i>=0; i--)
            {
                correctPassword += username[i];
            }

            string password = Console.ReadLine();
            int counter = 0;

            while (password!=correctPassword)
            {
                if (counter == 3)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
                password = (Console.ReadLine());
                counter++;
                
                
            }

            if (password==correctPassword)
            {
                Console.WriteLine($"User {username} logged in.");
            }

        }
    }
}
