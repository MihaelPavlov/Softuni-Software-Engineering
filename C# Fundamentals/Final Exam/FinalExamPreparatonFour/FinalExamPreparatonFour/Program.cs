using System;
using System.Text;
using System.Linq;

namespace FinalExamPreparatonFour
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Sign up")
            {
                string[] cmdArgs = command.Split(" ");
                string cmd = cmdArgs[0];


                if (cmd == "Case")
                {
                    if (cmdArgs[1] == "lower")
                    {
                        input = input.ToLower();
                        Console.WriteLine(input);
                    }
                    else if (cmdArgs[1] == "upper")
                    {
                        input = input.ToUpper();
                        Console.WriteLine(input);
                    }
                }
                else if (cmd == "Reverse")
                {
                    
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    

                    if (startIndex < input.Length && endIndex <= input.Length)
                    {
                        if (startIndex == 0)
                        {
                            startIndex = 1;
                        }
                        string newSt = input.Substring(startIndex, endIndex);
                        char[] change = newSt.ToCharArray();
                        Array.Reverse(change,startIndex-1, endIndex );
                        Console.WriteLine(string.Join("",change));
                                    
                    }
                }
                else if (cmd=="Cut")
                {
                    string substring = cmdArgs[1];
                    if (input.Contains(substring))
                    {

                        int startIndex = input.IndexOf(substring[0]);
                        int lenght = input.IndexOf(substring[substring.Length-1]);
                        input=input.Remove(startIndex,(lenght - startIndex)+1);

                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine($"The word {input} doesn't contain {substring}.");
                    }
                }
                else if (cmd=="Replace")
                {
                    char symbol = char.Parse(cmdArgs[1]);
                    input = input.Replace(symbol, '*');
                    Console.WriteLine(input);
                }
                else if (cmd=="Check")
                {
                    char symbol = char.Parse(cmdArgs[1]);

                    if (input.Contains(symbol))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {symbol}.");
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}
