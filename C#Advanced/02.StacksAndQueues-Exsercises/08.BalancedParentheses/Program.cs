using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {



            string input = Console.ReadLine();

            var stack = new Stack<char>();

            int count = 0;
            bool isMatchingPair = true;

            if (input.Length%2!=0)
            {
                Console.WriteLine("NO");
                return; 

            }
            while (stack.Any())
            {
                var currentBracket2 = input[i];
                if (currentBracket2 == '(' || currentBracket2 == '{' || currentBracket2 == '[')
                {
                    stack.Push(input[i]);
                }
                else if (currentBracket2 == ')' || currentBracket2 == '}' || currentBracket2 == ']')
                {
                    var currentBracket = stack.Pop();

                    if (currentBracket == '(' && currentBracket2 == ')')
                    {
                        isMatchingPair = true;



                    }
                    else if (currentBracket == '{' && currentBracket2 == '}')
                    {
                        isMatchingPair = true;


                    }
                    else if (currentBracket == '[' && currentBracket2 == ']')
                    {
                        isMatchingPair = true;


                    }
                    else
                    {
                        isMatchingPair = false;


                        break;


                    }
                    count++;


                }
            }
                
            


            if (isMatchingPair == true)
            {
                Console.WriteLine("YES");

            }
            else if (isMatchingPair==false)
            {
                Console.WriteLine("NO");
            }

        }
    }
}