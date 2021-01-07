using System;

namespace _03.Article2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            //колко грабят 
            //първо получаваме колко продължава грабежа
            //после грабеж за ден 
            //и после очаквания грабеж
            //всеки 3 ти ден имат допълнителен грабеж 50% повече от дневия грабеж
            //всеки 5 ти ден има война губят 30% от всичкия грабеж
            //ако грабежа е равен или по голям на очаквания принтира колко е грабежа
            // а ако е по малко в проценти колко сме заграбили


            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            int dayCount = 0;
            double plunderForAllDays = 0;
            double endPlunder = 0;

            for (int i = 0; i < days; i++)
            {
                dayCount++;
                plunderForAllDays += dailyPlunder;

                if (dayCount % 3 == 0)
                {
                    endPlunder += dailyPlunder * 0.50;
                    plunderForAllDays += endPlunder;
                    endPlunder = 0;
                }
                if (dayCount % 5 == 0)
                {
                    plunderForAllDays = plunderForAllDays - 0.30 * plunderForAllDays;
                }

            }

            if (plunderForAllDays >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {plunderForAllDays:f2} plunder gained.");
            }
            else if (plunderForAllDays < expectedPlunder)
            {
                double percent = (plunderForAllDays / expectedPlunder) * 100;
                Console.WriteLine($"Collected only {percent:F2}% of the plunder.");
            }





        }
    }
}
