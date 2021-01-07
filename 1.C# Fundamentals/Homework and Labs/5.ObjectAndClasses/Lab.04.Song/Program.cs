using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab._04.Song
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> playList = new List<Song>();


            for (int i = 0; i < numberOfSongs; i++)
            {
                List<string> readSongs = Console.ReadLine().Split("_").ToList();

                string typeList = readSongs[0]; 
                string name = readSongs[1];
                string time = readSongs[2];          

                Song song = new Song();

                song.TypeList = typeList;
                song.Name = name;
                song.Time = time;

                playList.Add(song);
                

            }
            string typeOftheEnd = Console.ReadLine();
            if (typeOftheEnd == "all")
            {
                foreach (var item in playList)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else 
            {
                foreach (var item in playList)
                {
                    if (item.TypeList == typeOftheEnd)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
            }

        }
    }
    class Song
    {
        public string TypeList { get; set; } // property
        public string Name { get; set; }
        public string Time { get; set; }

        public override string ToString() // metod 
        {
            return $"{TypeList}{Name}{Time}";
        }
    }
}
