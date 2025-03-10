﻿using System.Text;
using NamespaceCBlurred_Frontend.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace NamespaceCBlurred_Frontend.Services
{
    public class CreationService
    {
        private readonly string apiBaseUrl;
        private readonly HttpClient httpClient;

        public CreationService(string apiBaseUrl)
        {
            this.apiBaseUrl = apiBaseUrl;
            this.httpClient = new HttpClient();
        }

        public async Task<IEnumerable<Sound>> GetAllSoundsOfCreation()
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiBaseUrl + "Creation");
            if (!response.IsSuccessStatusCode)
            {
                return new List<Sound>();
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            var sounds = JsonConvert.DeserializeObject<List<Sound>>(responseBody);
            if (sounds == null)
            {
                return new List<Sound>();
            }

            return sounds;
        }

        public async Task<IEnumerable<Creation>> GetAllCreations()
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiBaseUrl + "Creation/allCreations");
            if (!response.IsSuccessStatusCode)
            {
                return new List<Creation>();
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            var creations = JsonConvert.DeserializeObject<List<Creation>>(responseBody);
            if (creations == null)
            {
                return new List<Creation>();
            }

            return creations;
        }

        public async Task AddSoundToCreation(Sound sound)
        {
            var soundJson = JsonSerializer.Serialize(sound);
            var content = new StringContent(soundJson, Encoding.UTF8, "application/json");

            await httpClient.PostAsync(apiBaseUrl + "Creation", content);
        }

        public async Task DeleteSoundFromCreation(int soundId)
        {
            await httpClient.DeleteAsync(apiBaseUrl + "Creation/" + soundId);
        }

        public async Task SaveCreation(string title)
        {
            await httpClient.PostAsync(apiBaseUrl + "Creation/" + title, null);
        }

        public async Task LoadCreation(int creationId)
        {
            await httpClient.GetAsync(apiBaseUrl + "Creation/" + creationId);
        }
    }
}
