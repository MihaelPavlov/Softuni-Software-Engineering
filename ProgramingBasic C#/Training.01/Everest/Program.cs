using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everest
{
    class Program
    {
        static void Main(string[] args)
        {
            int basedCamp = 5364;
            int days = 0;

            while (days!=6)
            {
                string tekst = Console.ReadLine();

                if (tekst == "END")
                {
                    Console.WriteLine("Failed!");
                    Console.WriteLine(basedCamp);
                    return;
                }
                int climb = int.Parse(Console.ReadLine());
               
                basedCamp += climb;  

                if( tekst == "Yes")
                {
                    days++;
                }
                if (days == 5)
                {
                    basedCamp = basedCamp - climb;
                    Console.WriteLine("Failed!");
                    Console.WriteLine(basedCamp);
                    break;
                }
                if (basedCamp >= 8848)
                {
                    Console.WriteLine($"Goal reached for {days+1} days!");
                    break;   
                }
            
                if (tekst == "END")
                {
                    Console.WriteLine("Failed!");
                    Console.WriteLine(basedCamp);
                    return;
                }
                
               
            }

        }
    }
}
