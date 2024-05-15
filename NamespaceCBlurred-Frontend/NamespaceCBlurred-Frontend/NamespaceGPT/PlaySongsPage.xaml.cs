using NamespaceCBlurred_Frontend.Model;
using NamespaceCBlurred_Frontend.Services;

namespace NamespaceCBlurred_Frontend.NamespaceGPT;

public partial class PlaySongsPage : ContentPage
{
	private readonly SongService songService;
	private readonly AudioService audioService;

	public PlaySongsPage()
	{
		InitializeComponent();

		songService = Service.GetInstance().SongService;
		audioService = Service.GetInstance().AudioService;
    }

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		SongsListView.ItemsSource = await songService.GetAllSongs();
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