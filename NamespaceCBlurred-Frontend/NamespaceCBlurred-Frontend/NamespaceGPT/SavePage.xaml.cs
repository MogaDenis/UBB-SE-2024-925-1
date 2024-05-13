namespace NamespaceCBlurred_Frontend.NamespaceGPT
{
    public partial class SavePage : ContentPage
    {
        public SavePage()
        {
            InitializeComponent();
        }

        private void OnYesClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SaveTitleEntry.Text))
            {
                DisplayAlert("Empty title!", "Please enter a title!", "OK");
                return;
            }
            DisplayAlert("Your masterpiece has been saved!", "We are waiting for your creative mastermind to blossom once again", "OK");
            // service.SaveCreation(SaveTitleEntry.Text);
            Shell.Current.GoToAsync("Main");
        }

        private void OnNoClicked(object sender, EventArgs e)
        {
            // Handle cancel action
            // Navigate back to the main page OR exit without saving
            Shell.Current.GoToAsync("Main");
        }
    }
}