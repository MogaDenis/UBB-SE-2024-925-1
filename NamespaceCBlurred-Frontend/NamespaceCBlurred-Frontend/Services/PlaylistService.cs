using NamespaceCBlurred_Frontend.Model;
using NamespaceCBlurred_Frontend.Models;
using Newtonsoft.Json;

namespace NamespaceCBlurred_Frontend.Services
{
    public class PlaylistService
    {
        private readonly HttpClient httpClient;
        private readonly string apiBaseUrl;

        public PlaylistService(string apiBaseUrl)
        {
            httpClient = new HttpClient();
            this.apiBaseUrl = apiBaseUrl;
        }

        public async Task<IEnumerable<Playlist>> GetAllPlaylists()
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiBaseUrl + "Playlists");
            if (!response.IsSuccessStatusCode)
            {
                return new List<Playlist>();
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            var playlists = JsonConvert.DeserializeObject<List<Playlist>>(responseBody);
            if (playlists == null)
            {
                return new List<Playlist>();
            }

            return playlists;
        }

        public async Task<IEnumerable<Song>> GetAllSongsOfPlaylist(int playlistId)
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiBaseUrl + "SongsByPlaylist/" + playlistId);
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

        public async Task AddSongToPlaylist(int playlistId, int songId)
        {
            await httpClient.PostAsync(apiBaseUrl + "/" + playlistId + "/" + songId, null);
        }

        public async Task DeleteSongFromPlaylist(int playlistId, int songId)
        {
            await httpClient.DeleteAsync(apiBaseUrl + "/" + playlistId + "/" + songId);
        }
    }
}
