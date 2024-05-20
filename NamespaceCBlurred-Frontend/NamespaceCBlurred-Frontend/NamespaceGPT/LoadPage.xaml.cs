using NamespaceCBlurred_Frontend.Models;
using NamespaceCBlurred_Frontend.Services;
using IServiceProvider = NamespaceCBlurred_Frontend.Services.Interfaces.IServiceProvider;

namespace NamespaceCBlurred_Frontend.NamespaceGPT
{
	public partial class LoadPage : ContentPage
	{
        private readonly IServiceProvider service;
		private readonly CreationService creationService;

        public LoadPage(IServiceProvider service)
        {
            InitializeComponent();

            this.service = service ?? throw new ArgumentNullException(nameof(service));

            creationService = this.service.GetCreationService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            CreationsListView.ItemsSource = await creationService.GetAllCreations();
        }

        private async void GoToMainPage(object sender, EventArgs e)
		{
            MainPage mainPage = new (service);
            await Shell.Current.Navigation.PushAsync(mainPage);
        }

        public async void OnCreationTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is not Creation creation)
            {
                return;
            }

            await creationService.LoadCreation(creation.Id);

            MainPage mainPage = new (service);
            await Shell.Current.Navigation.PushAsync(mainPage);
        }
    }
}