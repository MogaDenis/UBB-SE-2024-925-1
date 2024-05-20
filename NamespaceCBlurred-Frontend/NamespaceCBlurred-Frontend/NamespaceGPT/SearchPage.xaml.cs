using NamespaceCBlurred_Frontend.Models;
using NamespaceCBlurred_Frontend.Services;
using IServiceProvider = NamespaceCBlurred_Frontend.Services.Interfaces.IServiceProvider;

namespace NamespaceCBlurred_Frontend.NamespaceGPT
{
    public partial class SearchPage : ContentPage
    {
        private readonly IServiceProvider service;
        private readonly SoundService soundService;
        private readonly CreationService creationService;
        private readonly AudioService audioService;

        private readonly SoundType selectedSoundType;

        public SearchPage(IServiceProvider service)
        {
            InitializeComponent();

            this.service = service ?? throw new ArgumentNullException(nameof(service));

            soundService = this.service.GetSoundService();
            creationService = this.service.GetCreationService();
            audioService = this.service.GetAudioService();

            selectedSoundType = this.service.GetSelectedSoundType();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            SoundsListView.ItemsSource = await soundService.FilterSoundsByType(selectedSoundType);
        }

        public async void OnSoundTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is not Sound sound)
            {
                return;
            }

            await creationService.AddSoundToCreation(sound);

            audioService.StopAllSounds();

            MainPage mainPage = new (service);
            await Shell.Current.Navigation.PushAsync(mainPage);
        }

        public async void OnPlayClicked(object sender, EventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            Sound? sound = await soundService.GetSoundById(id);
            if (sound == null)
            {
                return;
            }

            audioService.PlayIndividualSound(sound);
        }

        public async void GoFromSearchToMainPage(object sender, EventArgs e)
        {
            audioService.StopAllSounds();

            MainPage mainPage = new (service);
            await Shell.Current.Navigation.PushAsync(mainPage);
        }

        private async void OnSearchButtonPressed(object sender, EventArgs e)
        {
            string searchQuery = SearchBar.Text;
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                SoundsListView.ItemsSource = await soundService.FilterSoundsByType(selectedSoundType);
            }
            else
            {
                SoundsListView.ItemsSource = (await soundService.FilterSoundsByType(selectedSoundType))
                   .Where(x => x.Name.Contains(searchQuery, StringComparison.CurrentCultureIgnoreCase));
            }
        }
    }
}