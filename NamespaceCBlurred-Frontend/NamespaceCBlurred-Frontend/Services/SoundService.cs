using NamespaceCBlurred_Frontend.Models;
using Newtonsoft.Json;

namespace NamespaceCBlurred_Frontend.Services
{
    public class SoundService
    {
        private readonly HttpClient httpClient;
        private readonly string apiBaseUrl;

        public SoundService(string apiBaseUrl)
        {
            httpClient = new HttpClient();
            this.apiBaseUrl = apiBaseUrl;
        }

        public async Task<Sound?> GetSoundById(int soundId)
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiBaseUrl + "Sounds/" + soundId);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            var sound = JsonConvert.DeserializeObject<Sound?>(responseBody);

            return sound;
        }

        public async Task<IEnumerable<Sound>> GetAllSounds()
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiBaseUrl + "Sounds");
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

        public async Task<IEnumerable<Sound>> FilterSoundsByType(SoundType type)
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiBaseUrl + "Sounds/soundType/" + (int)type);
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
    }
}
