using NamespaceCBlurred.Data.Models;

namespace NamespaceCBlurred.Data.Repositories.Interfaces
{
    public interface ICreationRepository
    {
        void AddSoundToCreation(Sound sound);
        bool DeleteSoundFromCreation(int soundId);
        IEnumerable<Sound> GetAllSoundsOfCreation();
        bool CreationContainsSound(int soundId);
        Task SaveCreation(string title);
        Task LoadCreation(int creationId);
        Task<IEnumerable<Creation>> GetAllCreations();
    }
}
