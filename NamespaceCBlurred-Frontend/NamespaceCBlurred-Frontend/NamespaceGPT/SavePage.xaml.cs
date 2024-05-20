using NamespaceCBlurred_Frontend.Services;
using IServiceProvider = NamespaceCBlurred_Frontend.Services.Interfaces.IServiceProvider;

namespace NamespaceCBlurred_Frontend.NamespaceGPT
{
    public partial class SavePage : ContentPage
    {
        private readonly IServiceProvider service;
        private readonly CreationService creationService;

        public SavePage(IServiceProvider service)
        {
            InitializeComponent();

            this.service = service ?? throw new ArgumentNullException(nameof(service));

            creationService = this.service.GetCreationService();
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

            MainPage mainPage = new (service);
            await Shell.Current.Navigation.PushAsync(mainPage);
        }

        private async void OnNoClicked(object sender, EventArgs e)
        {
            MainPage mainPage = new (service);
            await Shell.Current.Navigation.PushAsync(mainPage);
        }
    }
}