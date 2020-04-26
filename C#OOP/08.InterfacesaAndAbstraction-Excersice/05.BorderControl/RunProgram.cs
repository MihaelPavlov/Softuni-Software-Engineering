using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public static class RunProgram
    {
        static private List<ID> all;
        public static void Run()
        {
            all = new List<ID>();
            var input = Console.ReadLine().Split(" ");
            while (input[0] != "End")
            {

                string name = input[0];
                if (input.Length == 3)
                {
                    if (name == "Robot")
                    {
                        string name1 = input[1];
                        string id = input[2];
                        Robots robot = new Robots(name1, id);
                        all.Add(robot);

                        
                    }
                    else if (name == "Pet")
                    {
                        string name1 = input[1];
                        string id = input[2];
                        Pet pet = new Pet(name1, id);
                        all.Add(pet);
                    }
                }
                else if (input.Length == 5)
                {
                    string name1 = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string birth = input[4];

                    Citizens citizens = new Citizens(name1, age, id, birth);

                    all.Add(citizens);


                }




                input = Console.ReadLine().Split(" ");
            }

        }
        public static void Output()
        {
            int lastNumber = int.Parse(Console.ReadLine());
        
            foreach (var creature in all)
            {
                int lenght = lastNumber.ToString().Length;
                if (creature.Birthday != null)
                {
                    var lastLenght = creature.Birthday.Substring((creature.Birthday.Length - 1) - lenght + 1, lenght);

                    if (int.Parse(lastLenght) == lastNumber)
                    {
                        Console.WriteLine(creature.Birthday);
                     
                    }
                }

            }
           
        }
    }
}
