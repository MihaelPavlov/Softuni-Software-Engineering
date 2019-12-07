using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;



namespace _02.SongEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string patterArtist = @"^[A-Z][a-z\s']+$";
            string patterSong = @"^[A-Z\s]+$";

            
            while (input != "end")
            {
                string[] cmdArgs = input.Split(":");
                string artist = cmdArgs[0];
                string song = cmdArgs[1];

                
                Regex artistRegex = new Regex(patterArtist);
                Regex songRegex = new Regex(patterSong);

                if (artistRegex.IsMatch(artist) && songRegex.IsMatch(song))
                {
                    StringBuilder crypt = new StringBuilder();
                    int lenght = artist.Length;
                    int ecrypLetter = 0;
                    for (int i = 0; i < artist.Length; i++)
                    {
                        if (char.IsUpper(artist[i]) && artist[i]+lenght>90)
                        {
                            ecrypLetter = artist[i] + lenght - 26;
                            crypt.Append((char)(ecrypLetter));
                        }
                        else if (char.IsLower(artist[i]) && artist[i]+lenght>122)
                        {
                            ecrypLetter = artist[i] + lenght - 26;
                            crypt.Append((char)(ecrypLetter));
                        }
                        else if (artist[i]==' ')
                        {
                            crypt.Append(' ');
                        }
                        else if (artist[i] =='\\')
                        {
                            crypt.Append('\\');
                        }                       
                        else
                        {
                            ecrypLetter = (artist[i] + lenght);
                            crypt.Append((char)(ecrypLetter));
                        }
                       



                    }
                    crypt.Append('@');

                    ecrypLetter = 0;
                    for (int b = 0; b < song.Length; b++)
                    {
                        if (song[b] + lenght > 90)
                        {
                            ecrypLetter = song[b] + lenght - 26;
                            crypt.Append((char)(ecrypLetter));
                        }
                        else if (song[b] == ' ')
                        {
                            crypt.Append(' ');
                        }
                        else if (song[b] == '\\')
                        {
                            crypt.Append('\\');
                        }
                        ecrypLetter = (song[b] + lenght);
                        crypt.Append((char)(ecrypLetter));

                    }
                    ecrypLetter = 0;
                    Console.WriteLine($"Successful encryption: {crypt}");
                }
                else
                {
                    Console.WriteLine("Invalid input!" );
                }
                input = Console.ReadLine();




            }
        }
    }
}
