using AutoMapper;
using NamespaceCBlurred.Business.Models;
using NamespaceCBlurred.Business.Services.Interfaces;
using NamespaceCBlurred.Data.Models;
using NamespaceCBlurred.Data.Repositories.Interfaces;

namespace NamespaceCBlurred.Business.Services
{
    public class SoundService : ISoundService
    {
        private readonly ISoundRepository soundRepository;
        private readonly IMapper mapper;

        public SoundService(ISoundRepository soundRepository, IMapper mapper)
        {
            this.soundRepository = soundRepository ?? throw new ArgumentNullException(nameof(soundRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Sound> AddSound(SoundForAddUpdateModel soundModel)
        {
            var sound = mapper.Map<Sound>(soundModel);

            int id = await soundRepository.AddSound(sound);
            sound.Id = id;

            return sound;
        }

        public async Task<bool> DeleteSound(int soundId)
        {
            return await soundRepository.DeleteSound(soundId);
        }

        public async Task<IEnumerable<Sound>> GetAllSounds()
        {
            return await soundRepository.GetAllSounds();
        }

        public async Task<Sound?> GetSoundById(int soundId)
        {
            return await soundRepository.GetSoundById(soundId);
        }

        public async Task<bool> UpdateSound(int soundId, SoundForAddUpdateModel soundModel)
        {
            return await soundRepository.UpdateSound(soundId, mapper.Map<Sound>(soundModel));
        }
    }
}
