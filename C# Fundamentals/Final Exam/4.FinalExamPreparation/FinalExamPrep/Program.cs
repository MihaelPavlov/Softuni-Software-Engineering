using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;


namespace FinalExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            //^n:(?<name>[^; ]+);t:(?<kind>[^; ]+);c--(?<country>[A-Za-z ]+)$
            //^n:(?<name>[^;]+);t:(?<kind>[^;]+);c--(?<country>[A-Za-z\s]+)$
            int n = int.Parse(Console.ReadLine());
            string patterName = @"^n:(?<name>[^;]+);t:(?<kind>[^;]+);c--(?<country>[A-Za-z\s]+)$";
            Regex animalName = new Regex(patterName);
            int totalWeight = 0;


            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                StringBuilder nameSt = new StringBuilder();
                StringBuilder kindSt = new StringBuilder();
                Match match = animalName.Match(input);
                var name = animalName.Match(input).Groups["name"].Value;
                if (match.Success)
                {
                    for (int j = 0; j < name.Length; j++)
                    {
                        char letter = name[j];

                        if (char.IsLetter(letter) || letter==' ')
                        {
                            nameSt.Append(letter);
                        }
                        else if (char.IsDigit(letter))
                        {
                            totalWeight += int.Parse(letter.ToString());
                        }
                    }
                    var kind = animalName.Match(input).Groups["kind"].Value;
                    for (int b = 0; b < kind.Length; b++)
                    {
                        char letter = kind[b];
                        if (char.IsLetter(letter) || letter == ' ')
                        {
                            kindSt.Append(letter);
                        }
                        else if (char.IsDigit(letter))
                        {
                            totalWeight += int.Parse(letter.ToString());
                        }
                    }
                    var country = animalName.Match(input).Groups["country"].Value;

                    Console.WriteLine($"{nameSt} is a {kindSt} from {country}");
                }
               
            }
            Console.WriteLine($"Total weight of animals: {totalWeight}KG");
           
        }
    }
}
