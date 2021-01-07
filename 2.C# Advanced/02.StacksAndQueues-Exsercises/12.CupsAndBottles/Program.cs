using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] filledBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupCapacity);
            Stack<int> bottles = new Stack<int>(filledBottles);

            int wastedWater = 0;
            int bottleFilled = 0;// maybe 0 

            while ( cups.Any())
            {

                int pickBottle = bottles.Pop();
                int pickCup = cups.Dequeue();
                if (pickCup > pickBottle && bottles.Count == 0)
                {
                    int lastCondition = Math.Abs(pickBottle - pickCup);
                    wastedWater += lastCondition;
                    cups.Enqueue(pickCup);
                    break;
                }
                int condition = Math.Abs(pickBottle - pickCup);

                if (pickCup > pickBottle)
                {

                    while (bottles.Any())
                    {
                        int secondBottle = bottles.Pop();
                        int secondCondition = Math.Abs(pickBottle - condition);
                        if (secondCondition >= 0)
                        {
                            wastedWater += secondCondition;
                            bottleFilled++;
                            break;
                        }
                    }
                }
                else if (pickBottle >= pickCup)
                {
                    wastedWater += condition;
                    bottleFilled++;
                }




            }

            if (cups.Count==0)
            {
                Console.WriteLine($"Bottles: {bottleFilled}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            
            

        }
    }
}
