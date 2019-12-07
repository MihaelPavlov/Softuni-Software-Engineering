using System;

namespace _01._Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            //получавама party size and daysof the adventure 
            // всеки ден получавам 50 парички
            // но и карчим по 2 парички за компанион
            /* всеки 3 ти ден харчим по 3 парички за компанион
                 всеки 5 ти ден взимаме 20 парички за компанион
                 но ако имаш и в петия ден 3-ти харчим по 2 за компанион
                 всеки 10 ден 2-ма си тръгват 
                 и всеки 15 ден 5тима нови идват.*/


            int partySizePeople = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int coins = 0;
           


            for (int currentDay = 1; currentDay <= days; currentDay++)
            {                                         
                if (currentDay % 10 == 0)
                {   
                    partySizePeople = partySizePeople - 2;

                }
                if (currentDay % 15 == 0)
                {
                    partySizePeople = partySizePeople + 5;
                    
                  
                }
                coins += 50;
                coins = coins - (partySizePeople * 2);
                if (currentDay % 3 == 0)
                {
                    coins = coins - (partySizePeople * 3);
                }
                if (currentDay % 5 == 0)
                {
                    coins = coins + (partySizePeople * 20);
                    if (currentDay % 3 == 0)
                    {
                        coins = coins - (partySizePeople * 2);
                    }
                }
                


                
                

            }
            
            Console.WriteLine($"{partySizePeople} companions received {coins / partySizePeople} coins each.");
        }
    }
}
