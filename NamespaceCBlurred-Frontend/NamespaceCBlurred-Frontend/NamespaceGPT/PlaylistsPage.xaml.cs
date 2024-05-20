using NamespaceCBlurred_Frontend.Services;
using IServiceProvider = NamespaceCBlurred_Frontend.Services.Interfaces.IServiceProvider;

namespace NamespaceCBlurred_Frontend.NamespaceGPT
{
	public partial class PlaylistsPage : ContentPage
	{
		private readonly IServiceProvider service;
		private readonly PlaylistService playlistService;

		public PlaylistsPage(IServiceProvider service)
		{
			InitializeComponent();

			this.service = service ?? throw new ArgumentNullException(nameof(service));

			playlistService = this.service.GetPlaylistService();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			PlaylistsListView.ItemsSource = await playlistService.GetAllPlaylists();
		}

		private async void GoFromPlaylistsToRoutingPage(object sender, EventArgs e)
		{
			RoutingPage routingPage = new (service);
			await Shell.Current.Navigation.PushAsync(routingPage);
		}

		private async void OnSeePlaylistSongsClicked(object sender, EventArgs e)
		{
			service.SetSelectedPlaylistId((int)((Button)sender).CommandParameter);

            PlaySongsPage playSongsPage = new (service);
            await Shell.Current.Navigation.PushAsync(playSongsPage);
        }
	}
}