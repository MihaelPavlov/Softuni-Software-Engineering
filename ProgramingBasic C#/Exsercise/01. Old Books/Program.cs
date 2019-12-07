using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            int capasityBookStore = int.Parse(Console.ReadLine());
            int counter = 0;
            bool bookIsFound = false;

            string nextBookName = Console.ReadLine();
            while (counter < capasityBookStore)
            {
                nextBookName = Console.ReadLine();
                if (nextBookName == book)
                {
                    bookIsFound = true;
                    break;
                }
                counter++;
                
                
            }
            if (bookIsFound == false)
            {
                Console.WriteLine("te book is not found");
            }
            else Console.WriteLine("you cheked");
        }
    }
}
