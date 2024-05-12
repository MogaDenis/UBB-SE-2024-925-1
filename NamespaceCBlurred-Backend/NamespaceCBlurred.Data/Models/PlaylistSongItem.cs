using System.ComponentModel.DataAnnotations.Schema;

namespace NamespaceCBlurred.Data.Models
{
    public class PlaylistSongItem
    {
        public int Id { get; set; }

        [ForeignKey("Song")]
        public int SongId { get; set; }
        public Song Song { get; set; } = null!;

        [ForeignKey("Playlist")]
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; } = null!;
    }
}
