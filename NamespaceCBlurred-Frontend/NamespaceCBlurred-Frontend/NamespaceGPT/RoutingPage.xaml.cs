using IServiceProvider = NamespaceCBlurred_Frontend.Services.Interfaces.IServiceProvider;

namespace NamespaceCBlurred_Frontend.NamespaceGPT
{
	public partial class RoutingPage : ContentPage
	{
		private readonly IServiceProvider service;

		public RoutingPage(IServiceProvider service)
		{
			this.service = service ?? throw new ArgumentNullException(nameof(service));

			InitializeComponent();
		}

		private async void GoToCreateSong(object sender, EventArgs e)
		{
			MainPage mainPage = new (service);
			await Shell.Current.Navigation.PushAsync(mainPage);
		}

		private async void GoToPlaySongs(object sender, EventArgs e)
		{
			service.SetSelectedPlaylistId(-1); // Show all songs

			PlaySongsPage playSongsPage = new (service);
            await Shell.Current.Navigation.PushAsync(playSongsPage);
        }

		private async void GoToPlaylists(object sender, EventArgs e)
		{
			PlaylistsPage playlistsPage = new (service);
            await Shell.Current.Navigation.PushAsync(playlistsPage);
        }
	}
}