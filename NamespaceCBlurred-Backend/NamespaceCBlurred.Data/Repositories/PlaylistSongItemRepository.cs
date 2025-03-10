﻿using Microsoft.EntityFrameworkCore;
using NamespaceCBlurred.Data.Models;
using NamespaceCBlurred.Data.Repositories.Interfaces;

namespace NamespaceCBlurred.Data.Repositories
{
    public class PlaylistSongItemRepository : IPlaylistSongItemRepository
    {
        private readonly NamespaceCBlurredContext context;

        public PlaylistSongItemRepository(NamespaceCBlurredContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddSongToPlaylist(int songId, int playlistId)
        {
            PlaylistSongItem playlistSongItem = new ()
            {
                SongId = songId,
                PlaylistId = playlistId
            };

            await context.PlaylistSongItems.AddAsync(playlistSongItem);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteSongFromPlaylist(int songId, int playlistId)
        {
            var playlistSongItemToDelete = await context.PlaylistSongItems
                .FirstOrDefaultAsync(playlistSongItem => playlistSongItem.SongId == songId && playlistSongItem.PlaylistId == playlistId);

            if (playlistSongItemToDelete == null)
            {
                return false;
            }

            context.PlaylistSongItems.Remove(playlistSongItemToDelete);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Playlist>> GetPlaylistsBySongId(int songId)
        {
            return await context.PlaylistSongItems
                .Where(playlistSongItem => playlistSongItem.SongId == songId)
                .Select(playlistSongItem => playlistSongItem.Playlist)
                .ToListAsync();
        }

        public async Task<IEnumerable<Song>> GetSongsByPlaylistId(int playlistId)
        {
            return await context.PlaylistSongItems
                .Where(playlistSongItem => playlistSongItem.PlaylistId == playlistId)
                .Select(playlistSongItem => playlistSongItem.Song)
                .ToListAsync();
        }
    }
}
