using AutoMapper;
using NamespaceCBlurred.Business.Models;
using NamespaceCBlurred.Business.Services.Interfaces;
using NamespaceCBlurred.Data.Models;
using NamespaceCBlurred.Data.Repositories.Interfaces;

namespace NamespaceCBlurred.Business.Services
{
    public class SoundService : ISoundService
    {
        private readonly ISoundRepository _soundRepository;
        private readonly IMapper _mapper;

        public SoundService(ISoundRepository soundRepository, IMapper mapper)
        {
            _soundRepository = soundRepository ?? throw new ArgumentNullException(nameof(soundRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> AddSound(SoundForAddUpdateModel soundModel)
        {
            return await _soundRepository.AddSound(_mapper.Map<Sound>(soundModel));
        }

        public async Task<bool> DeleteSound(int soundId)
        {
            return await _soundRepository.DeleteSound(soundId);
        }

        public Task<IEnumerable<Sound>> GetAllSounds()
        {
            throw new NotImplementedException();
        }

        public Task<Sound?> GetSoundById(int soundId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSound(int soundId, SoundForAddUpdateModel soundModel)
        {
            throw new NotImplementedException();
        }
    }
}
