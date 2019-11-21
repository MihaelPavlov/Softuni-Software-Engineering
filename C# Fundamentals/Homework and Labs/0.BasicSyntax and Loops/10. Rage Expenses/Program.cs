using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            // има слушалки , мишка , клавиатура, и монитор
            //всяка втора загубена игра пешо чупи едни слушалки 
            //всяка трета загубена игра чупи мишка
            //когато пешо счупи и мишката и слушалките в същата загубена игра , също таака си чупи и клавиатурата
            //на  всеки втори път когато си чупи клавиатурата си чупи и монитора
            //имаме колко игри е загубил и цената на нещата.


            int lostGame = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice= double.Parse(Console.ReadLine());

            double money = 0;

            for (int i = 1; i <= lostGame; i++)
            {
                if (i % 12 == 0 )
                {
                    money += displayPrice;
                }
                if (i % 6 == 0)
                { 
                    money += keyboardPrice;
                }
                if (i % 2 ==0)
                {
                    money += headsetPrice;
                }
                if (i % 3 ==0)
                {
                    money += mousePrice;
                }
            }
            Console.WriteLine($"Rage expenses: {money:f2} lv.");

        }
    }
}
