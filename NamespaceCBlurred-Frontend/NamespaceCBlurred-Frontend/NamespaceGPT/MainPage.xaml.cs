namespace NamespaceCBlurred_Frontend.NamespaceGPT
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            // if (sender is Button { CommandParameter: string item } && tracksListView.ItemsSource is List<string> items)
            // {
            //    items.Remove(item);
            //    int trackId = auxList.Find(x => x.getTitle() == item).getId();
            //    service.RemoveTrack(trackId);
            //    tracksListView.ItemsSource = null;
            //    tracksListView.ItemsSource = items;
            // }
        }

        private async void GoFromMainToLogInPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("LogIn");
        }

        private void GoToListenTrack(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void GoToSearchTracks(object sender, EventArgs e)
        {
            // Button button = (Button)sender;
            // string category = button.Text.ToLower();
            // service.category = category;
            await Shell.Current.GoToAsync("Search");
        }

        private async void GoFromMainToSavePage(object sender, EventArgs e)
        {
            // if (service.GetCreationTracks().Count == 0)
            // {
            //    DisplayAlert("Empty creation!", "Please select at least one track!", "OK");
            //    return;
            // }
            await Shell.Current.GoToAsync("Save");
        }

        private void PlayCreation(object sender, EventArgs e)
        {
            // if (!isButtonClicked && service.GetCreationTracks().Count() != 0)
            // {
            //    playButton.BackgroundColor = Color.FromRgb(255, 0, 0);
            //    isButtonClicked = true;
            //    service.PlayCreation();
            // }
            // else
            // {
            //    playButton.BackgroundColor = Color.FromRgb(57, 208, 71);
            //    isButtonClicked = false;
            //    service.StopCreation();
            // }
        }
    }
}
