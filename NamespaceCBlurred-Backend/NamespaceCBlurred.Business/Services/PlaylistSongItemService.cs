using System.ComponentModel.DataAnnotations;
using NamespaceCBlurred.Business.Services.Interfaces;
using NamespaceCBlurred.Data.Models;
using NamespaceCBlurred.Data.Repositories.Interfaces;

namespace NamespaceCBlurred.Business.Services
{
    public class PlaylistSongItemService : IPlaylistSongItemService
    {
        private readonly IPlaylistSongItemRepository playlistSongItemRepository;
        private readonly IPlaylistService playlistService;
        private readonly ISongService songService;

        public PlaylistSongItemService(
            IPlaylistSongItemRepository playlistSongItemRepository,
            IPlaylistService playlistService,
            ISongService songService)
        {
            this.playlistSongItemRepository = playlistSongItemRepository
                ?? throw new ArgumentNullException(nameof(playlistSongItemRepository));

            this.playlistService = playlistService ?? throw new ArgumentNullException(nameof(playlistService));
            this.songService = songService ?? throw new ArgumentNullException(nameof(songService));
        }

        private async Task ValidateSongId(int songId)
        {
            if (songId < 0)
            {
                throw new ValidationException("Invalid song id provided.");
            }

            if (await songService.GetSongById(songId) == null)
            {
                throw new ValidationException("The given song does not exist.");
            }
        }

        private async Task ValidatePlaylistId(int playlistId)
        {
            if (playlistId < 0)
            {
                throw new ValidationException("Invalid playlist id provided.");
            }

            if (await playlistService.GetPlaylistById(playlistId) == null)
            {
                throw new ArgumentException("The given playlist does not exist!");
            }
        }

        public async Task AddSongToPlaylist(int songId, int playlistId)
        {
            await ValidateSongId(songId);
            await ValidatePlaylistId(playlistId);

            await playlistSongItemRepository.AddSongToPlaylist(songId, playlistId);
        }

        public async Task<bool> DeleteSongFromPlaylist(int songId, int playlistId)
        {
            await ValidateSongId(songId);
            await ValidatePlaylistId(playlistId);

            return await playlistSongItemRepository.DeleteSongFromPlaylist(songId, playlistId);
        }

        public async Task<IEnumerable<Playlist>> GetPlaylistsBySongId(int songId)
        {
            await ValidateSongId(songId);

            return await playlistSongItemRepository.GetPlaylistsBySongId(songId);
        }

        public async Task<IEnumerable<Song>> GetSongsByPlaylistId(int playlistId)
        {
            await ValidatePlaylistId(playlistId);

            return await playlistSongItemRepository.GetSongsByPlaylistId(playlistId);
        }
    }
}
