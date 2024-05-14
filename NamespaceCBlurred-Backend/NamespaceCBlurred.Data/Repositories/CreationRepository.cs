using NamespaceCBlurred.Data.Models;
using NamespaceCBlurred.Data.Repositories.Interfaces;

namespace NamespaceCBlurred.Data.Repositories
{
    public class CreationRepository : ICreationRepository
    {
        private readonly NamespaceCBlurredContext context;
        private readonly List<Sound> sounds;

        public CreationRepository(NamespaceCBlurredContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
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

        public async Task SaveCreation(string title)
        {
            Creation newCreation = new ()
            {
                Title = title,
            };

            await context.Creations.AddAsync(newCreation);
            await context.SaveChangesAsync();

            int creationId = newCreation.Id;

            List<CreationSoundItem> soundItems = new List<CreationSoundItem>();

            foreach (Sound sound in sounds)
            {
                CreationSoundItem newItem = new ()
                {
                    CreationId = creationId,
                    SoundId = sound.Id,
                };

                soundItems.Add(newItem);
            }

            await context.CreationSoundItems.AddRangeAsync(soundItems);
            await context.SaveChangesAsync();
        }
    }
}
