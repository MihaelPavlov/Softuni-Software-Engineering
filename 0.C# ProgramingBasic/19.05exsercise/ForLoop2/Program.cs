using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLoop2
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

           Console.WriteLine(word.Length);//otpechatvane broq bukvi
           Console.WriteLine(word[0]);//otpechatvane na purva bukva
           Console.WriteLine(word[word.Length-1]);// otpechatvane na pozledna bukva
            

            for (int position = 0; position <=word.Length-1; position++)
            {
                Console.WriteLine($"Number is: {position}");// izliza cifrata na bukvata
            }
        }
    }
}
