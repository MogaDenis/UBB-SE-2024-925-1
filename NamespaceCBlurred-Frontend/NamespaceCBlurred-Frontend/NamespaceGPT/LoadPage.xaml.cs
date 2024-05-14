using NamespaceCBlurred_Frontend.Models;
using NamespaceCBlurred_Frontend.Services;

namespace NamespaceCBlurred_Frontend.NamespaceGPT
{
	public partial class LoadPage : ContentPage
	{
		private readonly CreationService creationService;

		public LoadPage()
		{
			InitializeComponent();

			creationService = Service.GetInstance().CreationService;
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            CreationsListView.ItemsSource = await creationService.GetAllCreations();
        }

        private async void GoToMainPage(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("Main");
		}

        public async void OnCreationTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is not Creation creation)
            {
                return;
            }

            await creationService.LoadCreation(creation.Id);

            await Shell.Current.GoToAsync("Main");
        }
    }
}