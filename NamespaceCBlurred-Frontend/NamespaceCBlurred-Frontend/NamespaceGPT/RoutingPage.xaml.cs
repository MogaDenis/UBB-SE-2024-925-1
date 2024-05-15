namespace NamespaceCBlurred_Frontend.NamespaceGPT;

public partial class RoutingPage : ContentPage
{
	public RoutingPage()
	{
		InitializeComponent();
	}

	private async void GoToCreateSong(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("Main");
    }

	private async void GoToPlaySongs(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("PlaySongs");
	}

	private async void GoToPlaylists(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("Playlists");
    }
}