using System.ComponentModel.DataAnnotations.Schema;

namespace NamespaceCBlurred.Data.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        // public User User { get; set; } = null!;

        public string Name { get; set; } = string.Empty;
        public bool IsPrivate { get; set; }
        public string ImagePath { get; set; } = string.Empty;
    }
}
