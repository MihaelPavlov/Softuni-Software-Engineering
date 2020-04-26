using System;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------Enter first Number");
            int first = int.Parse(Console.ReadLine());
            Console.WriteLine("------Enter second Number");
            int second = int.Parse(Console.ReadLine());

            try
            {
                if (first != second)
                {
                    Console.WriteLine("Successfully");

                }
                else
                {
                    throw new InvalidOperationException("They are not Equal");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
        

            }
        }
    }
}
