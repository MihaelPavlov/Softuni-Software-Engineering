using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {

            //изчислява обема , количеството на ендо буре
            //принтираме колко бурета ще имаме
            //всеки 3 реда ще съдържат инфо за буретата
            //1модела на бурето 2.радиуса на бурето 3. тежестана бурето  
            //пресята се по формула пи * радиуса на 2 *тежеста
            //на краяя трябва да се принтира най- голямото буре 

            int n = int.Parse(Console.ReadLine());

            string biggestKegModel = "";
            double biggestKegVolume = 0;
            float pi = (float)Math.PI;

            for (int i = 1; i <= n; i++)   
            {
                string currentModel = Console.ReadLine();
                float kegradius = float.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());
                double currenVolume = (double)pi * kegradius * kegradius * kegHeight;

                if (currenVolume>biggestKegVolume)
                {
                    biggestKegVolume = currenVolume;
                    biggestKegModel = currentModel;
                }
             
            }
            


            Console.WriteLine(biggestKegModel);

        }

    }
}
