using Microsoft.EntityFrameworkCore;
using NamespaceCBlurred.Data.Models;
using NamespaceCBlurred.Data.Repositories.Interfaces;

namespace NamespaceCBlurred.Data.Repositories
{
    public class SoundRepository : ISoundRepository
    {
        private readonly NamespaceCBlurredContext _context;

        public SoundRepository(NamespaceCBlurredContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> AddSound(Sound sound)
        {
            await _context.Sounds.AddAsync(sound);
            await _context.SaveChangesAsync();

            return sound.Id;
        }

        public async Task<bool> DeleteSound(int soundId)
        {
            var soundToRemove = await _context.Sounds.FirstOrDefaultAsync(sound => sound.Id == soundId);
            if (soundToRemove == null) 
            {
                return false;
            }

            _context.Sounds.Remove(soundToRemove);
            return true;
        }

        public async Task<IEnumerable<Sound>> GetAllSounds()
        {
            return await _context.Sounds.ToListAsync();
        }

        public async Task<Sound?> GetSoundById(int soundId)
        {
            return await _context.Sounds.FirstOrDefaultAsync(sound => sound.Id == soundId);
        }

        public async Task<bool> UpdateSound(int soundId, Sound sound)
        {
            var soundToUpdate = await _context.Sounds.FirstOrDefaultAsync(sound => sound.Id == soundId);
            if (soundToUpdate == null)
            {
                return false;
            }

            sound.Id = soundId;

            _context.Sounds.Entry(soundToUpdate).CurrentValues.SetValues(sound);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
