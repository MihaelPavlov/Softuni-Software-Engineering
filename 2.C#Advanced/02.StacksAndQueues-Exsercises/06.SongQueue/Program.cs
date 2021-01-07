using System;
using System.Linq;
using System.Collections.Generic;


namespace _06.SongQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            //if song contains in queue dont add it
            var inputSong = Console.ReadLine().Split(", ");
           
            var listWithSong = new Queue<string>(inputSong);

            var songToPlay = Console.ReadLine();
            while (listWithSong.Any())
            {
              
                string[] cmdArgs = songToPlay.Split();
                string command = cmdArgs[0];
                if (listWithSong.Count==0)
                {
                    Console.WriteLine($"No more songs!");
                    break;
                }
                if (command == "Play")
                {
                    listWithSong.Dequeue();
                }
                else if (command=="Add")
                {
                    string cmd = songToPlay.Substring(4,(songToPlay.Length)-4);
                    string addSong = cmd;
                    if (listWithSong.Contains(addSong))
                    {
                        Console.WriteLine($"{addSong} is already contained!");
                     
                    }
                    else
                    {
                        listWithSong.Enqueue(addSong);
                    }
                    
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", listWithSong));
                }
               



                songToPlay = Console.ReadLine();
            }
            if (listWithSong.Count == 0)
            {
                Console.WriteLine($"No more songs!");
                
            }
        }
    }
}
