using NamespaceCBlurred.Data.Models;

namespace NamespaceCBlurred.Data.Repositories.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<Playlist?> GetPlaylistById(int playlistId);
        Task<IEnumerable<Playlist>> GetAllPlaylists();
        Task<IEnumerable<Playlist>> GetAllPlaylistsOfUser(int userId);
        Task<int> AddPlaylist(Playlist song);
        Task<bool> DeletePlaylist(int songId);
        Task<bool> UpdatePlaylist(int songId, Playlist song);
    }
}
