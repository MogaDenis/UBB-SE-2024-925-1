using NamespaceCBlurred.Data.Models;

namespace NamespaceCBlurred.Data.Repositories.Interfaces
{
    public interface ISoundRepository
    {
        Task<Sound?> GetSoundById(int soundId);
        Task<IEnumerable<Sound>> GetAllSounds();
        Task<int> AddSound(Sound sound);
        Task<bool> DeleteSound(int soundId);
        Task<bool> UpdateSound(int soundId, Sound sound);   
    }
}
