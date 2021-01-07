using System;

namespace _01._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] phares = { "Excellent product.",  "Such a great product.",
                "I always use that product.",
                "Best product of its category.", "Exceptional product.",
                "I can’t live without this product." };
            string[] events = { "Now I feel good.", "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.", "I feel great!"};
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] towns = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random number = new Random();//така си извикваме рандом класа //
            for (int i = 0; i < n; i++)
            {
                // от тези променливи взимаме само индекса на ,phares,events,authors and towns
                int pharesIndex = number.Next(0,phares.Length);// от 0-ят индекс до дължината на стринга
                int eventsIndex = number.Next(0, events.Length);// слагаме нулата за да може да вземем и нулевия индекс
                int authorsIndex = number.Next(0, authors.Length);// но попринцип може и без нулата
                int townsIndex = number.Next(0, towns.Length);
                Console.WriteLine($"{phares[pharesIndex]}. {events[eventsIndex]}. {authors[authorsIndex]} - { towns[townsIndex]} ");
               
            }
        }
    }
}
