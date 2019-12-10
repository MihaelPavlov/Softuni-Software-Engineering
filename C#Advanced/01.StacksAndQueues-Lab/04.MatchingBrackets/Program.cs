using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            

            for (int i = 0; i < input.Length; i++)
            {
                
              
                if (input[i] =='(')
                {
                    stack.Push(i);
                  
                }
                else if (input[i] == ')')
                {
                    var openBracketIndex = stack.Pop();
                    Console.WriteLine(input.Substring(openBracketIndex,i-openBracketIndex+1));
                }
            }

        }
    }
}
