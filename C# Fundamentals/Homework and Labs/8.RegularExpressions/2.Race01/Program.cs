using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace _2.Race01
{
    class Program
    {
        static void Main(string[] args)
        {
            //nomer na fakturata 401581216
            //nomer na faktura 40051056
            //7603104024 egn


            string regexName = @"[A-Za-z]";
            string regexNumber = @"[0-9]";

            Dictionary<string, int> nameAndPoint = new Dictionary<string, int>();
           

            string firstInput = Console.ReadLine();
            string[] commandArgs = firstInput.Split(", ");

            for (int i = 0; i < commandArgs.Length; i++)
            {
                nameAndPoint.Add(commandArgs[i], 0);
            }

            string secondInput = Console.ReadLine();
            while (secondInput != "end of race")
            {
                int totalNumber = 0;
                MatchCollection charCollection = Regex.Matches(secondInput, regexName);
                MatchCollection numberCollection = Regex.Matches(secondInput, regexNumber);


                foreach (Match oneNumber in numberCollection)
                {
                    int number = int.Parse(oneNumber.Value);
                    totalNumber += number;
                }
                string allName = string.Join("", charCollection);
                if (nameAndPoint.ContainsKey(allName))
                {
                    nameAndPoint[allName] += totalNumber;
                }

                secondInput = Console.ReadLine();
                
                
            }
            int numberCount = 1;

            foreach (var item in nameAndPoint.OrderByDescending(x => x.Value))
            {
                for (int i = numberCount; i <= 3; i++)
                {
                    if (numberCount ==1)
                    {
                        Console.WriteLine($"{1}st place: {item.Key}");
                    }
                    else if (numberCount==2)
                    {
                        Console.WriteLine($"{2}nd place: {item.Key}");

                    }
                    else if (numberCount==3)
                    {
                        Console.WriteLine($"{3}rd place: {item.Key}");

                    }

                    numberCount++;
                    break;
                }
                
            }

            

        }
    }
}
