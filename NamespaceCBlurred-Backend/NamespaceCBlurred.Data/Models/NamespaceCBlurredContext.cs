using Microsoft.EntityFrameworkCore;

namespace NamespaceCBlurred.Data.Models
{
    public class NamespaceCBlurredContext : DbContext
    {
        public NamespaceCBlurredContext() { }

        public NamespaceCBlurredContext(DbContextOptions<NamespaceCBlurredContext> options)
            : base(options) { }

        public virtual DbSet<Playlist> Playlists { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Sound> Sounds { get; set; }

        public virtual DbSet<Song> Songs { get; set; }
    }
}
