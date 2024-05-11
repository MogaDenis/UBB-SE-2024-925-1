using NamespaceCBlurred.Business.Models;
using NamespaceCBlurred.Data.Models;

namespace NamespaceCBlurred.Business.Services.Interfaces
{
    public interface ISongService
    {
        Task<Song?> GetSongById(int songId);
        Task<IEnumerable<Song>> GetAllSongs();
        Task<Song> AddSong(SongForAddUpdateModel songModel);
        Task<bool> DeleteSong(int songId);
        Task<bool> UpdateSong(int songId, SongForAddUpdateModel songModel);
    }
}
