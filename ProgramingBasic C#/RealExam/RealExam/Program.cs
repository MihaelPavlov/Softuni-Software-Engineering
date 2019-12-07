using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealExam
{
    class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int tickets = int.Parse(Console.ReadLine());
            double priceForTicket = double.Parse(Console.ReadLine());
            int percentForCinema = int.Parse(Console.ReadLine());

            double priceForBilet = tickets * priceForTicket;
            double allMoneyForFilm = days * priceForBilet;
            double CinemaMoney = allMoneyForFilm * percentForCinema / 100;
            double ciname = allMoneyForFilm - CinemaMoney;

            Console.WriteLine($"The profit from the movie {filmName} is {ciname:F2} lv.");



        }
    }
}
