using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace five
{
    class Program
    {
        static void Main(string[] args)
        {
            int passengers = int.Parse(Console.ReadLine());
            int stops = int.Parse(Console.ReadLine());

            int passengerCountDown = 0;
            int passengerCountUp = 0;
            int leavePassengers = 0;

            for (int onIn = 1; onIn <= stops; onIn++)
            {
                int passengerGoDown = int.Parse(Console.ReadLine());
                int passengerGoUp = int.Parse(Console.ReadLine());
                //first stop 
                passengerCountDown += passengerGoDown;
                passengerCountUp += passengerGoUp;
                
                

                if (onIn %2 !=0)
                {
                    leavePassengers += 2;
                }
                else if (onIn %2 == 0)
                {
                    leavePassengers -= 2;
                }
            }
            Console.WriteLine($"The final number of passengers is : {(passengers - (passengerCountDown - passengerCountUp)+leavePassengers)}");





        }
    }
}
