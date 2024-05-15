using NamespaceCBlurred_Frontend.Services;

namespace NamespaceCBlurred_Frontend.NamespaceGPT;

public partial class PlaylistsPage : ContentPage
{
	private readonly PlaylistService playlistService;
	public PlaylistsPage()
	{
		InitializeComponent();

		playlistService = Service.GetInstance().PlaylistService;
	}

	protected override async void OnAppearing()
	{
        base.OnAppearing();
        PlaylistsListView.ItemsSource = await playlistService.GetAllPlaylists();
    }

	private async void GoFromPlaylistsToRoutingPage(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("RoutingPage");
    }

	private async void OnSeePlaylistSongsClicked(object sender, EventArgs e)
	{
		Service.GetInstance().SelectedPlaylistId = (int)((Button)sender).CommandParameter;

        await Shell.Current.GoToAsync("PlaySongs");
    }
}