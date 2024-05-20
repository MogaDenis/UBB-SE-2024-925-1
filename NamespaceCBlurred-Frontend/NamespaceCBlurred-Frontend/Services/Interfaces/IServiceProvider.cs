using NamespaceCBlurred_Frontend.Models;

namespace NamespaceCBlurred_Frontend.Services.Interfaces
{
    public interface IServiceProvider
    {
        SongService GetSongService();
        PlaylistService GetPlaylistService();
        SoundService GetSoundService();
        CreationService GetCreationService();
        AudioService GetAudioService();
        SoundType GetSelectedSoundType();
        void SetSelectedSoundType(SoundType soundType);
        int GetSelectedPlaylistId();
        void SetSelectedPlaylistId(int playlistId);
    }
}
