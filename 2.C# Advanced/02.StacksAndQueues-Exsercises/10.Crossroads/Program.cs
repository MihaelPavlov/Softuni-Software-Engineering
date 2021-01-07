using System;
using System.Linq;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

           
            var queue = new Queue<string>();
            int countPassedSafly = 0;

            int secondLeft = 0;
            int greenLightSet = 0;

            string input;
            while ((input = Console.ReadLine())!= "END")
            {
                greenLightSet = greenLight;
                if (input == "green")
                {
                    bool isGreen = false;

                    while (input == "green")
                    {
                        if (greenLightSet!=0)
                        {
                            string car = queue.Dequeue();
                            if (car.Length <= greenLight)
                            {
                                secondLeft = greenLight - car.Length;
                                countPassedSafly++;
                                //Console.WriteLine("pass"); 
                                greenLightSet = secondLeft;
                                isGreen = true;
                                

                            }
                            if (secondLeft != 0 && queue.Count != 0)
                            {
                                string nextCar = queue.Dequeue();
                                if (nextCar.Length <= (secondLeft + freeWindow))
                                {
                                    countPassedSafly++;
                                   // Console.WriteLine("pass");
                                    greenLightSet = nextCar.Length - (secondLeft + freeWindow);
                                }
                                if (greenLightSet<=0)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{nextCar} was hit at {nextCar[secondLeft+freeWindow]}.");
                                    return;
                                }
                            }
                            if (isGreen==true)
                            {
                                break;
                            }
                        }
                       

                    }
                   
                }
                else
                {
                    queue.Enqueue(input);
                }


             
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{countPassedSafly} total cars passed the crossroads.");
        }
    }
}
