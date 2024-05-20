using NamespaceCBlurred_Frontend.Models;
using NamespaceCBlurred_Frontend.Services;
using IServiceProvider = NamespaceCBlurred_Frontend.Services.Interfaces.IServiceProvider;

namespace NamespaceCBlurred_Frontend.NamespaceGPT
{
    public partial class MainPage : ContentPage
    {
        private readonly IServiceProvider service;
        private readonly CreationService creationService;
        private readonly AudioService audioService;
        private bool isButtonClicked = false;

        public MainPage(IServiceProvider service)
        {
            InitializeComponent();

            this.service = service ?? throw new ArgumentNullException(nameof(service));

            creationService = this.service.GetCreationService();
            audioService = this.service.GetAudioService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            SoundsListView.ItemsSource = await creationService.GetAllSoundsOfCreation();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (sender is Button { CommandParameter: Sound item })
            {
                await creationService.DeleteSoundFromCreation(item.Id);
                SoundsListView.ItemsSource = await creationService.GetAllSoundsOfCreation();
            }
        }

        private async void GoFromMainToLogInPage(object sender, EventArgs e)
        {
            audioService.StopAllSounds();

            RoutingPage routingPage = new (service);
            await Shell.Current.Navigation.PushAsync(routingPage);
        }

        private async void GoToLoadPage(object sender, EventArgs e)
        {
            audioService.StopAllSounds();

            LoadPage loadPage = new (service);
            await Shell.Current.Navigation.PushAsync(loadPage);
        }

        private void GoToListenTrack(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void GoToSearchTracks(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string category = button.Text.ToUpper();

            bool parsedEnum = Enum.TryParse(category, out SoundType type);
            if (!parsedEnum)
            {
                return;
            }

            service.SetSelectedSoundType(type);

            audioService.StopAllSounds();

            SearchPage searchPage = new (service);
            await Shell.Current.Navigation.PushAsync(searchPage);
        }

        private async void GoFromMainToSavePage(object sender, EventArgs e)
        {
            if ((await creationService.GetAllSoundsOfCreation()).ToList().Count == 0)
            {
                await DisplayAlert("Empty creation!", "Please select at least one track!", "OK");
                return;
            }

            SavePage savePage = new (service);
            await Shell.Current.Navigation.PushAsync(savePage);
        }

        private async void PlayCreation(object sender, EventArgs e)
        {
            var creationSounds = (await creationService.GetAllSoundsOfCreation()).ToList();

            if (!isButtonClicked && creationSounds.Count != 0)
            {
                playButton.BackgroundColor = Color.FromRgb(255, 0, 0);
                isButtonClicked = true;
                audioService.PlaySounds(creationSounds);
            }
            else
            {
                playButton.BackgroundColor = Color.FromRgb(57, 208, 71);
                isButtonClicked = false;
                audioService.StopAllSounds();
            }
        }
    }
}
