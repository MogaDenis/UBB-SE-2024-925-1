using NamespaceCBlurred_Frontend.Services;

namespace NamespaceCBlurred_Frontend.NamespaceGPT
{
    public partial class SavePage : ContentPage
    {
        private readonly CreationService creationService;

        public SavePage()
        {
            InitializeComponent();

            creationService = Service.GetInstance().CreationService;
        }

        private async void OnYesClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SaveTitleEntry.Text))
            {
                await DisplayAlert("Empty title!", "Please enter a title!", "OK");
                return;
            }
            await DisplayAlert("Your masterpiece has been saved!", "We are waiting for your creative mastermind to blossom once again", "OK");

            await creationService.SaveCreation(SaveTitleEntry.Text);
            await Shell.Current.GoToAsync("Main");
        }

        private async void OnNoClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Main");
        }
    }
}