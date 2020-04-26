using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var phonesNumberList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var sitesList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var smartPhone = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            for (int i = 0; i < phonesNumberList.Length; i++)
            {
                var currNumber = phonesNumberList[i];
                if (ValidatePhoneNumber(currNumber))
                {
                    if (currNumber.Length == 10)
                    {
                        smartPhone.Calling(currNumber);
                    }
                    else
                    {
                        stationaryPhone.Calling(currNumber);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            for (int i = 0; i < sitesList.Length; i++)
            {
                var currWebAddress = sitesList[i];
                if (ValidateWebsiteAddress(currWebAddress))
                {
                    smartPhone.Browsing(currWebAddress);
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }

        }
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                var currentChar = phoneNumber[i];

                if (char.IsLetter(currentChar))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool ValidateWebsiteAddress(string webAddress)
        {
            for (int i = 0; i < webAddress.Length; i++)
            {
                var currChar = webAddress[i];
                if (char.IsDigit(currChar))
                {
                    return false;
                }
            }
            return true;
        }


    }


}
    

