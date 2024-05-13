using NamespaceCBlurred_Frontend.Models;
using NamespaceCBlurred_Frontend.Services;

namespace NamespaceCBlurred_Frontend.NamespaceGPT
{
    public partial class SearchPage : ContentPage
    {
        private readonly SoundService soundService;
        private readonly CreationService creationService;

        public SearchPage()
        {
            InitializeComponent();

            soundService = Service.GetInstance().SoundService;
            creationService = Service.GetInstance().CreationService;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            SoundsListView.ItemsSource = await soundService.GetAllSounds();
        }

        public async void OnSoundTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is not Sound sound)
            {
                return;
            }

            await creationService.AddSoundToCreation(sound);

            await Shell.Current.GoToAsync("Main");
        }

        public void OnPlayClicked(object sender, EventArgs e)
        {
            // TO DO
            // PLAY THE TRACK
            // service.StopAll();
            // int id = (int)((Button)sender).CommandParameter;
            // Track track = service.GetTrackById(id);
            // track.Play();
        }

        public async void GoFromSearchToMainPage(object sender, EventArgs e)
        {
            // service.StopAll();
            await Shell.Current.GoToAsync("Main");
        }

        // Method to create dynamic buttons for sentences containing the search query
        /*private void CreateButtons(string searchQuery)
        {
            ButtonsLayout.Children.Clear(); // Clear existing buttons

            foreach (Track track in tracksData)
            {
                string title = track.getTitle();
                if (title.ToLower().Contains(searchQuery.ToLower()))
                {
                    var button = new Button { Text = title };
                    button.Clicked += Button_Clicked; // Add event handler for button click
                    ButtonsLayout.Children.Add(button);

                }
            }
        }
        */
        // Event handler for the search bar's search button pressed event
        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            string searchQuery = SearchBar.Text;
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                // TracksListView.ItemsSource = service.GetTracksByType(categoryInt);
            }
            else
            {
                // TracksListView.ItemsSource = service.GetTracksByType(categoryInt).
                //    FindAll(x => x.getTitle().ToLower().Contains(searchQuery.ToLower()));
            }
        }
    }
}