using NamespaceCBlurred_Frontend.Models;
using Plugin.Maui.Audio;

namespace NamespaceCBlurred_Frontend.Services
{
    public class Service
    {
        public SoundService SoundService { get; }
        public CreationService CreationService { get; }

        public AudioService AudioService { get; }

        public SoundType SelectedSoundType { get; set; }

        private readonly string apiBaseUrl = "https://localhost:7155/api/";
        private static readonly Service Instance = new ();

        private Service()
        {
            SoundService = new (apiBaseUrl);
            CreationService = new (apiBaseUrl);
            AudioService = new ();
        }

        public static Service GetInstance()
        {
            return Instance;
        }
    }
}
