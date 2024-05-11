namespace NamespaceCBlurred.Data.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Artist { get; set; } = string.Empty;

        public int Likes { get; set; }

        public int TimePlayed { get; set; }

        public string UrlSong { get; set; } = string.Empty;

        public string UrlImage { get; set; } = string.Empty;

        public Song()
        {
        }

        public Song(int id, string name, string artist, string urlSong, string urlImage = "")
        {
            Id = id;
            Name = name;
            Artist = artist;
            Likes = 0;
            TimePlayed = 0;
            UrlSong = urlSong;
            UrlImage = urlImage;
        }
    }
}
