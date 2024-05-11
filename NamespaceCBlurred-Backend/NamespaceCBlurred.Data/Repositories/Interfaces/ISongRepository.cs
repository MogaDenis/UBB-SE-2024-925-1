using NamespaceCBlurred.Data.Models;

namespace NamespaceCBlurred.Data.Repositories.Interfaces
{
    public interface ISongRepository
    {
        Task<Song?> GetSongById(int songId);
        Task<IEnumerable<Song>> GetAllSongs();
        Task<int> AddSong(Song song);
        Task<bool> DeleteSong(int songId);
        Task<bool> UpdateSong(int songId, Song song);
    }
}
