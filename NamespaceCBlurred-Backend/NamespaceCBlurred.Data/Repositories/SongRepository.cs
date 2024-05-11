using Microsoft.EntityFrameworkCore;
using NamespaceCBlurred.Data.Models;
using NamespaceCBlurred.Data.Repositories.Interfaces;

namespace NamespaceCBlurred.Data.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly NamespaceCBlurredContext context;

        public SongRepository(NamespaceCBlurredContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> AddSong(Song song)
        {
            await context.Songs.AddAsync(song);
            await context.SaveChangesAsync();

            return song.Id;
        }

        public async Task<bool> DeleteSong(int songId)
        {
            var songToRemove = await context.Songs.FirstOrDefaultAsync(song => song.Id == songId);
            if (songToRemove == null)
            {
                return false;
            }

            context.Songs.Remove(songToRemove);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Song>> GetAllSongs()
        {
            return await context.Songs.ToListAsync();
        }

        public async Task<Song?> GetSongById(int songId)
        {
            return await context.Songs.FirstOrDefaultAsync(song => song.Id == songId);
        }

        public async Task<bool> UpdateSong(int songId, Song song)
        {
            var songToUpdate = await context.Songs.FirstOrDefaultAsync(song => song.Id == songId);
            if (songToUpdate == null)
            {
                return false;
            }

            song.Id = songId;

            context.Songs.Entry(songToUpdate).CurrentValues.SetValues(song);
            await context.SaveChangesAsync();

            return true;
        }
    }
}

