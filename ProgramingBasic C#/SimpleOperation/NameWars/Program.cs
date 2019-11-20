using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameWars
{
    class Program
    {
        static void Main(string[] args)
        {
            int magicnum = int.Parse(Console.ReadLine());

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            for (int f = 1; f <= 9; f++)
                            {
                                for (int g = 1; g <= 9; g++)
                                {
                                    int product = a * b * c * d * f * g;
                                    if (product == magicnum)
                                    {
                                        Console.Write($"{a}{b}{c}{d}{f}{g} ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
          
        }
    }
}
