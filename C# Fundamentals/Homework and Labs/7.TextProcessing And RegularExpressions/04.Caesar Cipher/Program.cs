using System;
using System.Text;


namespace _04.Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            foreach (var symbol in text)
            {
                char charSymbol = (char)(symbol+3);
                sb.Append(charSymbol);
            }
            Console.WriteLine(sb);
        }
    }
}
