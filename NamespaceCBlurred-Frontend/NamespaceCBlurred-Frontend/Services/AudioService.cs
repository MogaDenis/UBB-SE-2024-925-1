using NamespaceCBlurred_Frontend.Model;
using NamespaceCBlurred_Frontend.Models;
using Plugin.Maui.Audio;

namespace NamespaceCBlurred_Frontend.Services
{
    public class AudioService
    {
        public IAudioManager AppAudioManager { get; }
        public List<IAudioPlayer> AppAudioPlayers { get; set; } = new List<IAudioPlayer>();

        public AudioService()
        {
            AppAudioManager = AudioManager.Current;
        }

        public void StopAllSounds()
        {
            foreach (IAudioPlayer player in AppAudioPlayers)
            {
                player.Stop();
            }

            AppAudioPlayers = new List<IAudioPlayer>();
        }

        public void PlayIndividualSound(Sound sound)
        {
            StopAllSounds();

            Stream track = FileSystem.OpenAppPackageFileAsync(sound.SoundFilePath).Result;
            IAudioPlayer player = AppAudioManager.CreatePlayer(track);

            player.Play();
            AppAudioPlayers.Add(player);
        }

        public void PlaySounds(IEnumerable<Sound> sounds)
        {
            StopAllSounds();

            foreach (Sound sound in sounds)
            {
                Stream track = FileSystem.OpenAppPackageFileAsync(sound.SoundFilePath).Result;
                IAudioPlayer player = AppAudioManager.CreatePlayer(track);

                player.Play();
                AppAudioPlayers.Add(player);
            }
        }

        public void PlaySong(Song song)
        {
            StopAllSounds();

            Stream track = FileSystem.OpenAppPackageFileAsync(song.UrlSong).Result;
            IAudioPlayer player = AppAudioManager.CreatePlayer(track);

            player.Play();
            AppAudioPlayers.Add(player);
        }
    }
}
