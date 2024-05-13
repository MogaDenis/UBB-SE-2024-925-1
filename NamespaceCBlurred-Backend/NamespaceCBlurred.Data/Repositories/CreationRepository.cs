using NamespaceCBlurred.Data.Models;
using NamespaceCBlurred.Data.Repositories.Interfaces;

namespace NamespaceCBlurred.Data.Repositories
{
    public class CreationRepository : ICreationRepository
    {
        private readonly List<Sound> sounds;

        public CreationRepository()
        {
            sounds = new List<Sound>();
        }

        public void AddSoundToCreation(Sound sound)
        {
            sounds.Add(sound);
        }

        public IEnumerable<Sound> GetAllSoundsOfCreation()
        {
            return sounds;
        }

        public bool DeleteSoundFromCreation(int soundId)
        {
            var soundToRemove = sounds.FirstOrDefault(sound => sound.Id == soundId);
            if (soundToRemove == null)
            {
                return false;
            }

            sounds.Remove(soundToRemove);

            return true;
        }

        public bool CreationContainsSound(int soundId)
        {
            var sound = sounds.FirstOrDefault(sound => sound.Id == soundId);
            if (sound == null)
            {
                return false;
            }

            return true;
        }
    }
}
