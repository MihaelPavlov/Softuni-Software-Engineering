using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam___27_and_28_July_2019
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine($"The architect {name} will need {number*3} hours to complete {number} project/s");
            
        }
    }
}
