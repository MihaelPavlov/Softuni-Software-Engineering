using System;

namespace _05.DateModefier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            var dateMode = new DateModifier();
            dateMode.DatesDifference(date1, date2);


            
        }
    }
}
