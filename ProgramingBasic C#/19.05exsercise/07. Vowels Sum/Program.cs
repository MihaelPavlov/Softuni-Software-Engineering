using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            
            while(name != "Танчето" || name !="Христо")
            {
                string name2 = Console.ReadLine();
                if (name2 == "Христо")
                {
                    Console.WriteLine("Love");
                }
                else if(name2 != "Танчето")
                {
                    Console.Beep();
                    Console.WriteLine("BadBoy");
                }

            } 
        }
    }
}
