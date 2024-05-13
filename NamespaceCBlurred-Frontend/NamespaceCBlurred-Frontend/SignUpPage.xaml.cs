namespace NamespaceCBlurred_Frontend
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void GoFromMainToLogInPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("LogIn");
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameEntry.Text) ||
            string.IsNullOrWhiteSpace(LastNameEntry.Text) ||
            string.IsNullOrWhiteSpace(UsernameEntry.Text) ||
            string.IsNullOrWhiteSpace(PasswordEntry.Text) ||
            string.IsNullOrWhiteSpace(VerifyPasswordEntry.Text))
            {
                await DisplayAlert("Error", "All fields are required", "OK");
                return;
            }

            // Check if passwords match
            if (PasswordEntry.Text != VerifyPasswordEntry.Text)
            {
                await DisplayAlert("Error", "Passwords do not match", "OK");
                return;
            }

            // Check if password meets complexity requirements
            string password = PasswordEntry.Text;
            if (!IsPasswordComplex(password))
            {
                await DisplayAlert("Error", "Password must contain at least one uppercase letter, one lowercase letter, one special character, and be at least 6 characters long", "OK");
                return;
            }

            // Check if the radio button is checked (assuming RadioButton is a custom control)
            if (!RadioButton.IsChecked)
            {
                await DisplayAlert("Error", "You must agree to the terms and conditions", "OK");
                return;
            }

            // If all validations pass, proceed with sign up
            await Shell.Current.GoToAsync("Main");
        }

        private bool IsPasswordComplex(string password)
        {
            // Check if password contains at least one uppercase letter, one lowercase letter, one special character, and is at least 6 characters long
            return !string.IsNullOrWhiteSpace(password) &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit) &&
                   password.Any(ch => !char.IsLetterOrDigit(ch));
        }
    }
}