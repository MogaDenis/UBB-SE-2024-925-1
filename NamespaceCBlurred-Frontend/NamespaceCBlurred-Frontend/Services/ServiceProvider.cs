using NamespaceCBlurred_Frontend.Models;
using IServiceProvider = NamespaceCBlurred_Frontend.Services.Interfaces.IServiceProvider;

namespace NamespaceCBlurred_Frontend.Services
{
    public class ServiceProvider : IServiceProvider
    {
        public SongService SongService { get; }
        public PlaylistService PlaylistService { get; }
        public SoundService SoundService { get; }
        public CreationService CreationService { get; }

        public AudioService AudioService { get; }

        public SoundType SelectedSoundType { get; set; }
        public int SelectedPlaylistId { get; set; } = -1;

        private readonly string apiBaseUrl = "https://localhost:7155/api/";
        private static readonly ServiceProvider Instance = new ();

        private ServiceProvider()
        {
            SoundService = new (apiBaseUrl);
            SongService = new (apiBaseUrl);
            CreationService = new (apiBaseUrl);
            PlaylistService = new (apiBaseUrl);
            AudioService = new ();
        }

        public static IServiceProvider GetInstance()
        {
            return Instance;
        }

        public SongService GetSongService()
        {
            return SongService;
        }

        public PlaylistService GetPlaylistService()
        {
            return PlaylistService;
        }

        public SoundService GetSoundService()
        {
            return SoundService;
        }

        public CreationService GetCreationService()
        {
            return CreationService;
        }

        public AudioService GetAudioService()
        {
            return AudioService;
        }

        public SoundType GetSelectedSoundType()
        {
            return SelectedSoundType;
        }

        public int GetSelectedPlaylistId()
        {
            return SelectedPlaylistId;
        }

        public void SetSelectedSoundType(SoundType soundType)
        {
            this.SelectedSoundType = soundType;
        }

        public void SetSelectedPlaylistId(int playlistId)
        {
            this.SelectedPlaylistId = playlistId;
        }
    }
}
