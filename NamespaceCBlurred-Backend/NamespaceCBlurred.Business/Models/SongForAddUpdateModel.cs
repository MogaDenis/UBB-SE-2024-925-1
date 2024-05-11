namespace NamespaceCBlurred.Business.Models
{
    public class SongForAddUpdateModel
    {
        public string Name { get; set; } = string.Empty;

        public string Artist { get; set; } = string.Empty;

        public int Likes { get; set; }

        public int TimePlayed { get; set; }

        public string UrlSong { get; set; } = string.Empty;

        public string UrlImage { get; set; } = string.Empty;
    }
}
