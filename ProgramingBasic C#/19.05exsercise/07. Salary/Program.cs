using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            // bool isFired=false;

            for (int count = 1; count <= tabs; count++)
            {
                string website = Console.ReadLine();

                if (website == "Facebook")
                {
                    salary = salary - 150;
                }
                else if (website == "Instagram")
                {
                    salary = salary - 100;
                }
                else if (website == "Reddit")
                {
                    salary = salary - 50;
                }
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    //isFired = true;
                    break;

                }
            }
            if (salary > 0)//(IsFired ==false) vtori variant
            {
                Console.WriteLine(salary);
                
            }

        }
    }
}
