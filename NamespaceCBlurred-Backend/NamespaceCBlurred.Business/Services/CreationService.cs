﻿using NamespaceCBlurred.Business.Services.Interfaces;
using NamespaceCBlurred.Data.Models;
using NamespaceCBlurred.Data.Repositories.Interfaces;

namespace NamespaceCBlurred.Business.Services
{
    public class CreationService : ICreationService
    {
        private readonly ICreationRepository creationRepository;

        public CreationService(ICreationRepository creationRepository)
        {
            this.creationRepository = creationRepository ?? throw new ArgumentNullException(nameof(creationRepository));
        }

        public void AddSoundToCreation(Sound sound)
        {
            if (creationRepository.CreationContainsSound(sound.Id))
            {
                return;
            }

            creationRepository.AddSoundToCreation(sound);
        }

        public IEnumerable<Sound> GetAllSoundsOfCreation()
        {
            return creationRepository.GetAllSoundsOfCreation();
        }

        public bool DeleteSoundFromCreation(int soundId)
        {
            return creationRepository.DeleteSoundFromCreation(soundId);
        }

        public async Task SaveCreation(string title)
        {
            await creationRepository.SaveCreation(title);
        }

        public async Task LoadCreation(int creationId)
        {
            await creationRepository.LoadCreation(creationId);
        }

        public async Task<IEnumerable<Creation>> GetAllCreations()
        {
            return await creationRepository.GetAllCreations();
        }
    }
}
