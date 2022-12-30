namespace MusicHub
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            using (context)
            {
                //Problem 2.
                Console.WriteLine(ExportAlbumsInfo(context, 9));

                //Problem 3.
                //Console.WriteLine(ExportSongsAboveDuration(context, 120));
            }
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId.Value == producerId)
                .Include(a => a.Songs)
                .ThenInclude(s => s.Writer)
                .Include(a => a.Producer)
                .ToArray()
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        s.Price,
                        WriterName = s.Writer.Name
                    }).ToArray(),
                    TotalPrice = a.Songs.Sum(s => s.Price)
                })
                .ToArray();

            var output = new StringBuilder();

            foreach (var album in albums.OrderByDescending(a => a.TotalPrice))
            {
                output
                    .AppendLine($"-AlbumName: {album.Name}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");

                int songNumber = 1;

                foreach (var song in album.Songs.OrderByDescending(s => s.SongName).ThenBy(s => s.WriterName))
                {
                    output
                        .AppendLine($"---#{songNumber++}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price:F2}")
                        .AppendLine($"---Writer: {song.WriterName}");
                }

                output.AppendLine($"-AlbumPrice: {album.TotalPrice:F2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            TimeSpan timeSpanDuration = TimeSpan.FromSeconds(duration);

            var songs = context.Songs
                .Where(s => s.Duration > timeSpanDuration)
                .Select(s => new
                {
                    SongName = s.Name,
                    WriterName = s.Writer.Name,
                    Performer = s.SongPerformers
                        .Select(p => $"{p.Performer.FirstName} {p.Performer.LastName}")
                        .FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = $"{s.Duration:c}"
                })
                .ToArray();

            var output = new StringBuilder();
            int songNumber = 1;

            foreach (var song in songs.OrderBy(s => s.SongName).ThenBy(s => s.WriterName).ThenBy(s => s.Performer))
            {
                output
                .AppendLine($"-Song #{songNumber++}")
                .AppendLine($"---SongName: {song.SongName}")
                .AppendLine($"---Writer: {song.WriterName}")
                .AppendLine($"---Performer: {song.Performer}")
                .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                .AppendLine($"---Duration: {song.Duration}");
            }

            return output.ToString().Trim();
        }
    }
}
