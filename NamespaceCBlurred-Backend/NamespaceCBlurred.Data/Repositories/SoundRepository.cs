using Microsoft.EntityFrameworkCore;
using NamespaceCBlurred.Data.Models;
using NamespaceCBlurred.Data.Repositories.Interfaces;

namespace NamespaceCBlurred.Data.Repositories
{
    public class SoundRepository : ISoundRepository
    {
        private readonly NamespaceCBlurredContext context;

        public SoundRepository(NamespaceCBlurredContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> AddSound(Sound sound)
        {
            await context.Sounds.AddAsync(sound);
            await context.SaveChangesAsync();

            return sound.Id;
        }

        public async Task<bool> DeleteSound(int soundId)
        {
            var soundToRemove = await context.Sounds.FirstOrDefaultAsync(sound => sound.Id == soundId);
            if (soundToRemove == null)
            {
                return false;
            }

            context.Sounds.Remove(soundToRemove);
            return true;
        }

        public async Task<IEnumerable<Sound>> GetAllSounds()
        {
            return await context.Sounds.ToListAsync();
        }

        public async Task<Sound?> GetSoundById(int soundId)
        {
            return await context.Sounds.FirstOrDefaultAsync(sound => sound.Id == soundId);
        }

        public async Task<bool> UpdateSound(int soundId, Sound sound)
        {
            var soundToUpdate = await context.Sounds.FirstOrDefaultAsync(sound => sound.Id == soundId);
            if (soundToUpdate == null)
            {
                return false;
            }

            sound.Id = soundId;

            context.Sounds.Entry(soundToUpdate).CurrentValues.SetValues(sound);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
