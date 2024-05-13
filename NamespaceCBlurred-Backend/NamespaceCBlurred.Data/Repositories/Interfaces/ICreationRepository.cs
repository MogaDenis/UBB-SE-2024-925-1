using NamespaceCBlurred.Data.Models;

namespace NamespaceCBlurred.Data.Repositories.Interfaces
{
    public interface ICreationRepository
    {
        void AddSoundToCreation(Sound sound);
        bool DeleteSoundFromCreation(int soundId);
        IEnumerable<Sound> GetAllSoundsOfCreation();
    }
}
