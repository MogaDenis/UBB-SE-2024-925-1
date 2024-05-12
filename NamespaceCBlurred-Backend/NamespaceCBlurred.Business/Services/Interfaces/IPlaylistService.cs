using NamespaceCBlurred.Business.Models;
using NamespaceCBlurred.Data.Models;

namespace NamespaceCBlurred.Business.Services.Interfaces
{
    public interface IPlaylistService
    {
        Task<Playlist?> GetPlaylistById(int playlistId);
        Task<IEnumerable<Playlist>> GetAllPlaylists();
        Task<IEnumerable<Playlist>> GetAllPlaylistsOfUser(int userId);
        Task<Playlist> AddPlaylist(PlaylistForAddUpdateModel playlistModel);
        Task<bool> DeletePlaylist(int playlistId);
        Task<bool> UpdatePlaylist(int playlistId, PlaylistForAddUpdateModel playlistModel);
    }
}
