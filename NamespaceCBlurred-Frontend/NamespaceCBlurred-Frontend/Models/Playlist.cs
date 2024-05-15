namespace NamespaceCBlurred_Frontend.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsPrivate { get; set; }
        public string ImagePath { get; set; } = string.Empty;
    }
}
