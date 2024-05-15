using NamespaceCBlurred_Frontend.Models;
using Plugin.Maui.Audio;

namespace NamespaceCBlurred_Frontend.Services
{
    public class Service
    {
        public SongService SongService { get; }
        public PlaylistService PlaylistService { get; }
        public SoundService SoundService { get; }
        public CreationService CreationService { get; }

        public AudioService AudioService { get; }

        public SoundType SelectedSoundType { get; set; }
        public int SelectedPlaylistId { get; set; } = -1;

        private readonly string apiBaseUrl = "https://localhost:7155/api/";
        private static readonly Service Instance = new ();

        private Service()
        {
            SoundService = new (apiBaseUrl);
            SongService = new (apiBaseUrl);
            CreationService = new (apiBaseUrl);
            PlaylistService = new (apiBaseUrl);
            AudioService = new ();
        }

        public static Service GetInstance()
        {
            return Instance;
        }
    }
}
