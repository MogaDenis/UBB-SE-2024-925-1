using NamespaceCBlurred.Data.Models;

namespace NamespaceCBlurred.Business.Services.Interfaces
{
    public interface ICreationService
    {
        void AddSoundToCreation(Sound sound);
        bool DeleteSoundFromCreation(int soundId);
        IEnumerable<Sound> GetAllSoundsOfCreation();
        Task SaveCreation(string title);
        Task LoadCreation(int creationId);
        Task<IEnumerable<Creation>> GetAllCreations();
    }
}
