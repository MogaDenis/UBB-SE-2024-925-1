using NamespaceCBlurred_Frontend.NamespaceGPT;
using NamespaceCBlurred_Frontend.Services;

namespace NamespaceCBlurred_Frontend
{
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                await DisplayAlert("Error", "Username and password are required!", "OK");
                return;
            }

            RoutingPage routingPage = new (Services.ServiceProvider.GetInstance());
            await Shell.Current.Navigation.PushAsync(routingPage);
        }

        private async void OnForgotPasswordClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ForgotPassword");
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("SignUp");
        }
    }
}