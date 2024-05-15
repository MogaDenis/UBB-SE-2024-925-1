using NamespaceCBlurred_Frontend.Model;
using NamespaceCBlurred_Frontend.Services;

namespace NamespaceCBlurred_Frontend.NamespaceGPT
{
	public partial class PlaySongsPage : ContentPage
	{
		private readonly SongService songService;
		private readonly PlaylistService playlistService;
		private readonly AudioService audioService;
		private readonly int selectedPlaylistId = -1;

		public PlaySongsPage()
		{
			InitializeComponent();

			songService = Service.GetInstance().SongService;
			playlistService = Service.GetInstance().PlaylistService;
			audioService = Service.GetInstance().AudioService;
			selectedPlaylistId = Service.GetInstance().SelectedPlaylistId;
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
			await Shell.Current.GoToAsync("RoutingPage");
		}
	}
}