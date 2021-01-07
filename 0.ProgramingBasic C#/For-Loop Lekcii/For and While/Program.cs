using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_Loop_Lekcii
{
    class Program
    {
        static void Main(string[] args)
        {
            //s while loop
            string command = Console.ReadLine();
            int countOfSymbols = 0;
            int counterOfNames = 0; //a ne ot edno zashtot while shte prochete i stop kato ime.

            while (command!="stop")
            {
                countOfSymbols += command.Length;
                command = Console.ReadLine();
                counterOfNames++;

            }
            Console.WriteLine(countOfSymbols/counterOfNames );





            //s for loop
            for (int i = 0; ; i++)
            {
                if (command != "Stop")
                {
                    countOfSymbols += command.Length;
                    command = Console.ReadLine();
                    counterOfNames++;
                }
                else
                {
                    break;
                }
                Console.WriteLine(countOfSymbols / counterOfNames);

            }
        }
    }
}
