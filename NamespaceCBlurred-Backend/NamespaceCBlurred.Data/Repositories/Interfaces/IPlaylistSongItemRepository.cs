﻿using NamespaceCBlurred.Data.Models;

namespace NamespaceCBlurred.Data.Repositories.Interfaces
{
    public interface IPlaylistSongItemRepository
    {
        Task AddSongToPlaylist(int songId, int playlistId);
        Task<bool> DeleteSongFromPlaylist(int songId, int playlistId);
        Task<IEnumerable<Song>> GetSongsByPlaylistId(int playlistId);
        Task<IEnumerable<Playlist>> GetPlaylistsBySongId(int songId);
    }
}