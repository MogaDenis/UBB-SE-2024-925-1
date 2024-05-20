using NamespaceCBlurred_Frontend.Model;
using NamespaceCBlurred_Frontend.Services;
using IServiceProvider = NamespaceCBlurred_Frontend.Services.Interfaces.IServiceProvider;

namespace NamespaceCBlurred_Frontend.NamespaceGPT
{
	public partial class PlaySongsPage : ContentPage
	{
		private readonly IServiceProvider service;
		private readonly SongService songService;
		private readonly PlaylistService playlistService;
		private readonly AudioService audioService;
		private readonly int selectedPlaylistId = -1;

		public PlaySongsPage(IServiceProvider service)
		{
			InitializeComponent();

			this.service = service ?? throw new ArgumentNullException(nameof(service));

			songService = this.service.GetSongService();
			playlistService = this.service.GetPlaylistService();
			audioService = this.service.GetAudioService();
			selectedPlaylistId = this.service.GetSelectedPlaylistId();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			if (selectedPlaylistId == -1)
			{
				SongsListView.ItemsSource = await songService.GetAllSongs();
			}
			else
			{
				SongsListView.ItemsSource = await playlistService.GetAllSongsOfPlaylist(selectedPlaylistId);
			}
		}

		private async void OnPlayClicked(object sender, EventArgs e)
		{
			int id = (int)((Button)sender).CommandParameter;
			Song? song = await songService.GetSongById(id);

			if (song == null)
			{
				return;
			}

			audioService.PlaySong(song);
		}

		private void OnStopClicked(object sender, EventArgs e)
		{
			audioService.StopAllSounds();
		}

		private async void GoFromSongsToRoutingPage(object sender, EventArgs e)
		{
			audioService.StopAllSounds();

            RoutingPage routingPage = new (service);
            await Shell.Current.Navigation.PushAsync(routingPage);
        }
	}
}