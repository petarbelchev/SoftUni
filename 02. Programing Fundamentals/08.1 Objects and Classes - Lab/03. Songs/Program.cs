using System;
using System.Collections.Generic;

namespace _03._Songs
{
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numsOfSongs = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int song = 1; song <= numsOfSongs; song++)
            {
                string[] songDetails = Console.ReadLine().Split('_');
                string typeList = songDetails[0];
                string name = songDetails[1];
                string time = songDetails[2];

                Song newSong = new Song()
                {
                    TypeList = typeList,
                    Name = name,
                    Time = time,
                };

                songs.Add(newSong);
            }

            string filter = Console.ReadLine();

            if (filter != "all")
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == filter)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}
