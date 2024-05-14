namespace NamespaceCBlurred_Frontend
{
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private async void OnSentRecoverButton(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UsernameEntry.Text) && UsernameEntry.Text.Contains('@'))
            {
                // UsernameEntry is not empty and contains "@", proceed with sending the code
                await DisplayAlert("Success", "Email sent", "OK");
                await Shell.Current.GoToAsync("Main");
            }
            else
            {
                // UsernameEntry is empty or does not contain "@", show an alert
                await DisplayAlert("Error", "Please enter a valid email address", "OK");
            }
        }
    }
}