using System;

namespace _07.Turple
{
   public class StartUp
    {
        static void Main(string[] args)
        {

            string[] inputPersonInfo = Console.ReadLine().Split();
            string[] inputPersonBeer = Console.ReadLine().Split();
            string[] inputnumberInfo = Console.ReadLine().Split();

            string fullname = inputPersonInfo[0] + " " + inputPersonInfo[1];
            string address = inputPersonInfo[2];
            string town;
           
            if (inputPersonInfo.Length == 5)
            {
                town = inputPersonInfo[3] + " " + inputPersonInfo[4];
                
            }
            else
            {
                town = inputPersonInfo[3];

            }

            string name = inputPersonBeer[0];
            int litters = int.Parse(inputPersonBeer[1]);
            string drunkOrNot = inputPersonBeer[2];
            bool isDrunk = false;
            if (drunkOrNot == "drunk")
            {
                isDrunk = true;

            }
            
            string myInt = inputnumberInfo[0];
            double myDouble = double.Parse(inputnumberInfo[1]);
            string bankName = inputnumberInfo[2];


         var personInfo = new Threeuple<string, string,string>(fullname,address,town);
         var personBeer = new Threeuple<string, int,bool>(name,litters,isDrunk);
         var numberInfo = new Threeuple<string, double , string>(myInt,myDouble,bankName);
            Console.WriteLine(personInfo);
            Console.WriteLine(personBeer);
            Console.WriteLine(numberInfo);





        }
    }
}
