using NamespaceCBlurred_Frontend.Models;
using NamespaceCBlurred_Frontend.Services;

namespace NamespaceCBlurred_Frontend.NamespaceGPT
{
    public partial class SearchPage : ContentPage
    {
        private readonly SoundService soundService;
        private readonly CreationService creationService;
        private readonly AudioService audioService;

        private readonly SoundType selectedSoundType;

        public SearchPage()
        {
            InitializeComponent();

            soundService = Service.GetInstance().SoundService;
            creationService = Service.GetInstance().CreationService;
            audioService = Service.GetInstance().AudioService;

            selectedSoundType = Service.GetInstance().SelectedSoundType;
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
            await Shell.Current.GoToAsync("Main");
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
            await Shell.Current.GoToAsync("Main");
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