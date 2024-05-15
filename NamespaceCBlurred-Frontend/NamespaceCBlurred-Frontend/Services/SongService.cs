using NamespaceCBlurred_Frontend.Model;
using Newtonsoft.Json;

namespace NamespaceCBlurred_Frontend.Services
{
    public class SongService
    {
        private readonly HttpClient httpClient;
        private readonly string apiBaseUrl;

        public SongService(string apiBaseUrl)
        {
            httpClient = new HttpClient();
            this.apiBaseUrl = apiBaseUrl;
        }

        public async Task<IEnumerable<Song>> GetAllSongs()
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiBaseUrl + "Songs");
            if (!response.IsSuccessStatusCode)
            {
                return new List<Song>();
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            var songs = JsonConvert.DeserializeObject<List<Song>>(responseBody);
            if (songs == null)
            {
                return new List<Song>();
            }

            return songs;
        }

        public async Task<Song?> GetSongById(int songId)
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiBaseUrl + "Songs/" + songId);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            var song = JsonConvert.DeserializeObject<Song?>(responseBody);

            return song;
        }
    }
}
