using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using NamespaceCBlurred.Business.Models;
using NamespaceCBlurred.Business.Services.Interfaces;
using NamespaceCBlurred.Data.Models;
using NamespaceCBlurred.Data.Repositories.Interfaces;

namespace NamespaceCBlurred.Business.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository songRepository;
        private readonly IMapper mapper;

        public SongService(ISongRepository songRepository, IMapper mapper)
        {
            this.songRepository = songRepository ?? throw new ArgumentNullException(nameof(songRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private static bool ValidSongModel(SongForAddUpdateModel songModel)
        {
            if (songModel.Name.IsNullOrEmpty() || songModel.Artist.IsNullOrEmpty())
            {
                return false;
            }

            if (songModel.Likes < 0 || songModel.TimePlayed < 0)
            {
                return false;
            }

            if (songModel.UrlSong.IsNullOrEmpty() || songModel.UrlImage.IsNullOrEmpty())
            {
                return false;
            }

            return true;
        }

        public async Task<Song> AddSong(SongForAddUpdateModel songModel)
        {
            if (!ValidSongModel(songModel))
            {
                throw new ValidationException("Invalid song data.");
            }

            var song = mapper.Map<Song>(songModel);

            int id = await songRepository.AddSong(song);
            song.Id = id;

            return song;
        }

        public async Task<bool> DeleteSong(int songId)
        {
            if (songId < 0)
            {
                throw new ValidationException("Invalid song id.");
            }

            return await songRepository.DeleteSong(songId);
        }

        public async Task<IEnumerable<Song>> GetAllSongs()
        {
            return await songRepository.GetAllSongs();
        }

        public async Task<Song?> GetSongById(int songId)
        {
            if (songId < 0)
            {
                throw new ValidationException("Invalid song id.");
            }

            return await songRepository.GetSongById(songId);
        }

        public async Task<bool> UpdateSong(int songId, SongForAddUpdateModel songModel)
        {
            if (songId < 0)
            {
                throw new ValidationException("Invalid song id.");
            }

            if (!ValidSongModel(songModel))
            {
                throw new ValidationException("Invalid song data.");
            }

            return await songRepository.UpdateSong(songId, mapper.Map<Song>(songModel));
        }
    }
}
