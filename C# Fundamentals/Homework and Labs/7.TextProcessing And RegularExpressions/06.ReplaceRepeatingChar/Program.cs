using System;
using System.Text;

namespace _06.ReplaceRepeatingChar
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split();
            StringBuilder sb = new StringBuilder();
            


            foreach (var symbol in text)
            {
                for (int i = 0; i < symbol.Length; i++)
                {
                    char newSymbol = symbol[i];
                    int getLengt = symbol.Length;
                    
                    if (i<=getLengt-2)
                    {
                        char nextSymbol = symbol[i + 1];
                        if (newSymbol != nextSymbol)
                        {
                            sb.Append(newSymbol);
                        }
                    }
                    else
                    {
                        sb.Append(newSymbol);
                    }
                   
                  
                    
                    
                }
               

            }
            Console.WriteLine(sb);
        }
    }
}
