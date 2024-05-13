using NamespaceCBlurred.Business.Models;
using NamespaceCBlurred.Data.Models;

namespace NamespaceCBlurred.Business.Services.Interfaces
{
    public interface ISoundService
    {
        Task<Sound?> GetSoundById(int soundId);
        Task<IEnumerable<Sound>> GetAllSounds();
        Task<IEnumerable<Sound>> FilterSoundsByType(SoundType type);
        Task<Sound> AddSound(SoundForAddUpdateModel soundModel);
        Task<bool> DeleteSound(int soundId);
        Task<bool> UpdateSound(int soundId, SoundForAddUpdateModel soundModel);
    }
}
